using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class ActionItem : MenuItem
    {
        private readonly IActionable m_InvokeableObject;

        internal ActionItem(string i_Name, IActionable i_InvokedAction) : base(i_Name)
        {
            m_InvokeableObject = i_InvokedAction;
        }
    
        public void Invoke()
        {
            m_InvokeableObject.Invoke();
        }
    }
}
