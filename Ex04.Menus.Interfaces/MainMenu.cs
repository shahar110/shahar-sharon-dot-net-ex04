using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex02.ConsoleUtils;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItem
    {
        public MainMenu(string i_MenuTitle) : base(i_MenuTitle)
        {
            FatherItem = null;
        }

        public void Show()
        {
            e_MenuNavigationOption menuNavigationOption;
            MenuItem selectedMenuItem = this;

            bool isValid = true;
            while (isValid)
            {
                int selectedUserIndex = getUserMenuSelection(selectedMenuItem, out menuNavigationOption);
                Screen.Clear();
                switch (menuNavigationOption)
                {
                    case e_MenuNavigationOption.Continue:
                        selectedMenuItem = selectedMenuItem.SubItems[selectedUserIndex];
                        if (selectedMenuItem is ActionItem)
                        {
                            (selectedMenuItem as ActionItem).Invoke();
                            selectedMenuItem = selectedMenuItem.FatherItem;
                        }

                        break;

                    case e_MenuNavigationOption.BackToPrevious:
                        if (selectedMenuItem.FatherItem != null)
                        {
                            selectedMenuItem = selectedMenuItem.FatherItem;
                        }

                        break;

                    case e_MenuNavigationOption.InvalidUserInput:
                        Console.WriteLine(string.Format("Invalid input entered!{0}Please select a valid menu item number.", Environment.NewLine));
                        break;

                    case e_MenuNavigationOption.IllegalNumberSelection:
                        Console.WriteLine(string.Format("Illegal number entered!{0}Please select a menu item within range.", Environment.NewLine));
                        break;

                    case e_MenuNavigationOption.Exit:
                        isValid = false;
                        break;
                }
            }

            Console.WriteLine("Good Bye...");
        }

        private void printSubMenuItems(MenuItem i_MenuItem)
        {
            Console.WriteLine(string.Format("{0} {1}", Environment.NewLine, i_MenuItem.Name));
            Console.WriteLine("-------------------------");
            int itemIndex = 1;
            StringBuilder menuItemList = new StringBuilder();
            foreach (var subMenuItem in i_MenuItem.SubItems)
            {
                menuItemList.AppendLine(string.Format("{0} : {1}", itemIndex, subMenuItem.Name));
                itemIndex++;
            }

            if (i_MenuItem.FatherItem != null)
            {
                menuItemList.AppendLine(string.Format("0 : Back", Environment.NewLine));
            }
            else
            {
                menuItemList.AppendLine(string.Format("0 : Exit", Environment.NewLine));
            }
                    
            Console.WriteLine(menuItemList);
        }

        private int getUserMenuSelection(MenuItem i_MenuItem, out e_MenuNavigationOption o_MenuNavigation)
        {
            printSubMenuItems(i_MenuItem);
            int selectedIndex;
            o_MenuNavigation = e_MenuNavigationOption.Continue;

            Console.WriteLine(string.Format("{0}Please select one of the above items", Environment.NewLine));
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out selectedIndex))
            {
                o_MenuNavigation = e_MenuNavigationOption.InvalidUserInput;
            }
            else if (selectedIndex < 0 || selectedIndex > i_MenuItem.SubItems.Count)
            {
                o_MenuNavigation = e_MenuNavigationOption.IllegalNumberSelection;
            }
            else if(selectedIndex == 0 && i_MenuItem.FatherItem == null)
            {
                o_MenuNavigation = e_MenuNavigationOption.Exit;
            }
            else if (selectedIndex == 0 && i_MenuItem.FatherItem != null)
            {
                o_MenuNavigation = e_MenuNavigationOption.BackToPrevious;
            }
   
            return selectedIndex - 1;
        }

        private enum e_MenuNavigationOption
        {
            Continue,
            Exit,
            BackToPrevious,
            InvalidUserInput,
            IllegalNumberSelection,
        }
    }
}
