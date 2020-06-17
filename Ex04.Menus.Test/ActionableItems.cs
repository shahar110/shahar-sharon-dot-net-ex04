using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ActionableItems
    {
        internal class CountCapitals : IActionable
        {
            public void Invoke()
            {
                Console.WriteLine("Please enter a sentence");
                string userInput = Console.ReadLine();
                int capitalCounter = 0;
                foreach (char character in userInput)
                {
                    if (char.IsUpper(character))
                    {
                        capitalCounter++;
                    }
                }

                Console.WriteLine(string.Format("Number of capitals in the sentence: {0}", capitalCounter));
            }
        }

        internal class ShowVersion : IActionable
        {
            public void Invoke()
            {
                Console.WriteLine("30620.4.2.20: Version");
            }
        }

        internal class ShowTime : IActionable
        {
            public void Invoke()
            {
                Console.WriteLine(string.Format("Current hour is: {0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute));
            }
        }

        internal class ShowDate : IActionable
        {
            public void Invoke()
            {
                Console.WriteLine(string.Format("Today's date is: {0}", DateTime.Now.Date.ToShortDateString()));
            }
        }
    }
}
