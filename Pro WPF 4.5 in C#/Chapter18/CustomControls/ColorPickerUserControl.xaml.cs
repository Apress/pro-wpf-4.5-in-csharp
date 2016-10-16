using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for ColorPickerUserControl.xaml
    /// </summary>

    public partial class ColorPickerUserControl : System.Windows.Controls.UserControl
    {
        public ColorPickerUserControl()
        {
            InitializeComponent();
            SetUpCommands();
        }

        private void SetUpCommands()
        {            
            // Set up command bindings.
            //CommandBinding binding = new CommandBinding(ApplicationCommands.Undo, 
            // UndoCommand_Executed, UndoCommand_CanExecute);

           // this.CommandBindings.Add(binding);
        }

        private Color? previousColor;
        private static void UndoCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ColorPickerUserControl colorPicker = (ColorPickerUserControl)sender;
            e.CanExecute = colorPicker.previousColor.HasValue;
        }
        private static void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Use simple reverse-or-redo Undo (like Notepad).
            ColorPickerUserControl colorPicker = (ColorPickerUserControl)sender;            
            colorPicker.Color = (Color)colorPicker.previousColor;
        }

        static ColorPickerUserControl()
        {
            ColorProperty =  DependencyProperty.Register("Color", typeof(Color),
                typeof(ColorPickerUserControl),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
                        
            RedProperty = DependencyProperty.Register("Red", typeof(byte),
                typeof(ColorPickerUserControl),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            
            GreenProperty = DependencyProperty.Register("Green", typeof(byte),
                typeof(ColorPickerUserControl),
                    new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            BlueProperty = DependencyProperty.Register("Blue", typeof(byte),
                typeof(ColorPickerUserControl),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));            
            
            CommandManager.RegisterClassCommandBinding(typeof(ColorPickerUserControl),
                new CommandBinding(ApplicationCommands.Undo,
                UndoCommand_Executed, UndoCommand_CanExecute));
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
            ColorPickerUserControl colorPicker = (ColorPickerUserControl)sender;

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
            ColorPickerUserControl colorPicker = (ColorPickerUserControl)sender;
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
               typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPickerUserControl));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        private void OnColorChanged(Color oldValue, Color newValue)
        {
            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
            args.RoutedEvent = ColorPickerUserControl.ColorChangedEvent;
            RaiseEvent(args);
        }
    }
}