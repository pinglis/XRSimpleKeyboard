using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRSimpleKeyboard
{
    /// <summary>
    /// The type of the key. Note, default keys (such as a 'A' key) will have a type 
    /// af 'Normal'
    /// </summary>
    public enum KeyType
    {
        Normal,
        Caps,
        Return,
        Shift,
        LeftCtrl,
        LeftAlt,
        RightCtrl,
        RightAlt,
        DownArrow,
        UpArrow,
        LeftArrow,
        BackSpace,
        Menu,
        Del,
        OS,
        Tab
    }
}
