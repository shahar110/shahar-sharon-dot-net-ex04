using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly string m_ItemName;
        private readonly List<MenuItem> m_SubMenuItemsList;
        private readonly Dictionary<string, int> m_MappedSubMenuItems;
        private MenuItem m_FatherItem = null;

        internal MenuItem(string i_Name)
        {
            m_ItemName = i_Name;
            m_SubMenuItemsList = new List<MenuItem>();
            m_MappedSubMenuItems = new Dictionary<string, int>();
        }

        internal List<MenuItem> SubItems
        {
            get { return m_SubMenuItemsList; }
        }

        public string Name
        {
            get { return m_ItemName; }
        }

        public MenuItem FatherItem
        {
            get { return m_FatherItem; }
            set
            {
                if (value is MenuItem)
                {
                    m_FatherItem = value;
                }
            }
        }

        public void AddSubItem(string i_Name)
        {
            m_SubMenuItemsList.Add(new MenuItem(i_Name));
            m_MappedSubMenuItems.Add(i_Name, m_SubMenuItemsList.Count - 1);
            m_SubMenuItemsList.Last().FatherItem = this;
        }

        public void AddSubItem(string i_Name, IActionable i_InvokeableObject)
        {
            m_SubMenuItemsList.Add(new ActionItem(i_Name, i_InvokeableObject));
            m_MappedSubMenuItems.Add(i_Name, m_SubMenuItemsList.Count - 1);
            m_SubMenuItemsList.Last().FatherItem = this;
        }

        public MenuItem SubItem(string i_ItemName)
        {
            int itemIndex = m_MappedSubMenuItems[i_ItemName];
            return m_SubMenuItemsList[itemIndex];
        }

        public MenuItem SubItem(int i_ItemIndex)
        {
            return m_SubMenuItemsList[i_ItemIndex];
        }
    }
}
