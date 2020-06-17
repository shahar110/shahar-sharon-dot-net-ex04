using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class MenuTester
    {
        public static void TestInterfacesMenu()
        {
            MainMenu mainMenu = new MainMenu("Main");
            mainMenu.AddSubItem("Version and Digits");
            mainMenu.SubItem("Version and Digits").AddSubItem("Count Capitals", new ActionableItems.CountCapitals());
            mainMenu.SubItem("Version and Digits").AddSubItem("Show Version", new ActionableItems.ShowVersion());

            mainMenu.AddSubItem("Show Date/Time");
            mainMenu.SubItem("Show Date/Time").AddSubItem("Show Time", new ActionableItems.ShowTime());
            mainMenu.SubItem("Show Date/Time").AddSubItem("Show Date", new ActionableItems.ShowDate());

            mainMenu.Show();
        }

        public static void TestDelegatesMenu()
        {
        }
    }      
}
