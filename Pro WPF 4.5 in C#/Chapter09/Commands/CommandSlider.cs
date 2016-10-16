using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Commands
{
    public class CommandSlider : Slider, ICommandSource
    {
        public CommandSlider()
            : base()
        {

        }

        //ICommand Interface Memembers
        //make Command a dependency property so it can be DataBound
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(CommandSlider),
                new PropertyMetadata((ICommand)null,
                new PropertyChangedCallback(CommandChanged)));

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }
        //make CommandTarget a dependency property so it can be DataBound
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register(
                "CommandTarget",
                typeof(IInputElement),
                typeof(CommandSlider),
                new PropertyMetadata((IInputElement)null));

        public IInputElement CommandTarget
        {
            get
            {
                return (IInputElement)GetValue(CommandTargetProperty);
            }
            set
            {
                SetValue(CommandTargetProperty, value);
            }
        }

        //make CommandParameter a dependency property so it can be DataBound
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                "CommandParameter",
                typeof(object),
                typeof(CommandSlider),
                new PropertyMetadata((object)null));

        public object CommandParameter
        {
            get
            {
                return (object)GetValue(CommandParameterProperty);
            }
            set
            {
                SetValue(CommandParameterProperty, value);
            }
        }

        // Command dependency property change callback
        private static void CommandChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            CommandSlider cs = (CommandSlider)d;
            cs.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }
        // Add a new command to the Command Property
        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            //if oldCommand is not null, then we need to remove the handlers
            if (oldCommand != null)
            {
                RemoveCommand(oldCommand, newCommand);
            }
            AddCommand(oldCommand, newCommand);
        }

        // Remove an old command from the Command Property
        private void RemoveCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = CanExecuteChanged;
            oldCommand.CanExecuteChanged -= handler;
        }

        // add the command
        private void AddCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = new EventHandler(CanExecuteChanged);
            canExecuteChangedHandler = handler;
            if (newCommand != null)
            {
                newCommand.CanExecuteChanged += canExecuteChangedHandler;
            }
        }
        private void CanExecuteChanged(object sender, EventArgs e)
        {

            if (this.Command != null)
            {
                RoutedCommand command = this.Command as RoutedCommand;

                // if RoutedCommand
                if (command != null)
                {
                    if (command.CanExecute(CommandParameter, CommandTarget))
                    {
                        this.IsEnabled = true;
                    }
                    else
                    {
                        this.IsEnabled = false;
                    }
                }
                // if not RoutedCommand
                else
                {
                    if (Command.CanExecute(CommandParameter))
                    {
                        this.IsEnabled = true;
                    }
                    else
                    {
                        this.IsEnabled = false;
                    }
                }
            }
        }

        //if Command is defined, then moving the slider will invoke the command;
        //otherwise, the silder will behave normally
        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);

            if (this.Command != null)
            {
                RoutedCommand command = Command as RoutedCommand;

                if (command != null)
                {
                    command.Execute(CommandParameter, CommandTarget);
                }
                else
                {
                    ((ICommand)Command).Execute(CommandParameter);
                }
            }
        }

        //keep a copy of the handler so it doesn't get garbage collected
        private static EventHandler canExecuteChangedHandler;
    }
}
