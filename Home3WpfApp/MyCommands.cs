using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Home3WpfApp
{
    class MyCommands
    {
        public static RoutedUICommand Exit { get; set; }
        public static RoutedCommand Red { get; set; }
        public static RoutedCommand Black { get; set; }
        public static RoutedCommand Underline { get; set; }
        public static RoutedCommand Italic { get; set; }
        public static RoutedCommand Bold { get; set; }       
        static MyCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
            Exit = new RoutedUICommand("Выход","Exit", typeof(MyCommands), inputs);
            Red = new RoutedCommand();
            Black = new RoutedCommand();
            Underline = new RoutedCommand();
            Italic = new RoutedCommand();
            Bold = new RoutedCommand();            
        }
    }
}
