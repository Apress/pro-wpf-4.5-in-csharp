using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomControls
{

    [TemplatePart(Name="PART_RedSlider", Type=typeof(RangeBase))]
    [TemplatePart(Name="PART_BlueSlider", Type=typeof(RangeBase))]
    [TemplatePart(Name="PART_GreenSlider", Type=typeof(RangeBase))]
    [TemplatePart(Name="PART_PreviewBrush", Type=typeof(SolidColorBrush))]
    public class ColorPicker : System.Windows.Controls.Control
    {
        static ColorPicker()
        {
            //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
            //This style is defined in themes\generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));

                ColorProperty =  DependencyProperty.Register("Color", typeof(Color),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorChanged)));
                        
            RedProperty = DependencyProperty.Register("Red", typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            
            GreenProperty = DependencyProperty.Register("Green", typeof(byte),
                typeof(ColorPicker),
                    new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            BlueProperty = DependencyProperty.Register("Blue", typeof(byte),
                typeof(ColorPicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));            
        }

        public ColorPicker()
        {
            //InitializeComponent();
            SetUpCommands();  
        }

        private void SetUpCommands()
        {            
            // Set up command bindings.
            CommandBinding binding = new CommandBinding(ApplicationCommands.Undo, 
             UndoCommand_Executed, UndoCommand_CanExecute);

            this.CommandBindings.Add(binding);
        }

        private Color? previousColor;
        private void UndoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = previousColor.HasValue;
        }
        private void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Use simple reverse-or-redo Undo (like Notepad).
            this.Color = (Color)previousColor;
        }
        
        
        public static DependencyProperty ColorProperty;
        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;

        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {           
            ColorPicker colorPicker = (ColorPicker)sender;

            Color oldColor = (Color)e.OldValue;
            Color newColor = (Color)e.NewValue;
            colorPicker.Red = newColor.R;
            colorPicker.Green = newColor.G;
            colorPicker.Blue = newColor.B;

            colorPicker.previousColor = oldColor;
            colorPicker.OnColorChanged(oldColor, newColor);
        }
        
        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {           
            ColorPicker colorPicker = (ColorPicker)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;
            
            colorPicker.Color = color;
        }

        public static readonly RoutedEvent ColorChangedEvent =
           EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
               typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        private void OnColorChanged(Color oldValue, Color newValue)
        {
            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
            args.RoutedEvent = ColorPicker.ColorChangedEvent;
            RaiseEvent(args);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            RangeBase slider = GetTemplateChild("PART_RedSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding("Red");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(RangeBase.ValueProperty, binding);
            }
            slider = GetTemplateChild("PART_GreenSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding("Green");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(RangeBase.ValueProperty, binding);
            }
            slider = GetTemplateChild("PART_BlueSlider") as RangeBase;
            if (slider != null)
            {
                Binding binding = new Binding("Blue");
                binding.Source = this;
                binding.Mode = BindingMode.TwoWay;
                slider.SetBinding(RangeBase.ValueProperty, binding);
            }

            SolidColorBrush brush = GetTemplateChild("PART_PreviewBrush") as SolidColorBrush;
            if (brush != null)
            {
                Binding binding = new Binding("Color");
                binding.Source = brush;
                binding.Mode = BindingMode.OneWayToSource;
                this.SetBinding(ColorPicker.ColorProperty, binding);
            }  
        }
    }
}
