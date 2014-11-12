using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CardTool
{
    public static class CustomCommands
    {

        public static readonly RoutedUICommand Exit = new RoutedUICommand
                        (
                                "Exit",
                                "Exit",
                                typeof(CustomCommands),
                                new InputGestureCollection()
                                {
                                    new KeyGesture(Key.Q, ModifierKeys.Control)
                                }
                        );


        public static readonly RoutedUICommand AddCard = new RoutedUICommand
                         (
                                 "AddCard",
                                 "AddCard",
                                 typeof(CustomCommands)
                         );

        public static readonly RoutedUICommand EditCard = new RoutedUICommand
                         (
                                 "EditCard",
                                 "EditCard",
                                 typeof(CustomCommands)
                         );


        public static readonly RoutedUICommand DeleteCard = new RoutedUICommand
                         (
                                 "DeleteCard",
                                 "DeleteCard",
                                 typeof(CustomCommands)
                         );

        public static readonly RoutedUICommand ClearDeck = new RoutedUICommand
                         (
                                 "ClearDeck",
                                 "ClearDeck",
                                 typeof(CustomCommands)
                         );

        public static readonly RoutedUICommand AddImage = new RoutedUICommand
                        (
                                "AddImage",
                                "AddImage",
                                typeof(CustomCommands)
                        );
    
    }  
}
