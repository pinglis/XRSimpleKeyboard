using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRSimpleKeyboard.Layouts
{
    /// <summary>
    /// A layout for a british standard english keyboard
    /// </summary>
    internal class EnGbLayout : ILayout
    {
        /// <summary>
        /// The number of keys in a row (this is the same for each row taking into account blank spaces.
        /// </summary>
        public int Width
        {
            get
            {
                return 15;
            }
        }

        /// <summary>
        /// The map of keys
        /// </summary>
        public KeyAndWidth[][] Keys
        {
            get
            {
                return new KeyAndWidth[][] {
                        new KeyAndWidth[]
                        {
                            new KeyAndWidth(1, KeyWidth.Key1_0 ),
                            new KeyAndWidth(2, KeyWidth.Key1_0 ),
                            new KeyAndWidth(3, KeyWidth.Key1_0 ),
                            new KeyAndWidth(4, KeyWidth.Key1_0 ),
                            new KeyAndWidth(5, KeyWidth.Key1_0 ),
                            new KeyAndWidth(6, KeyWidth.Key1_0 ),
                            new KeyAndWidth(7, KeyWidth.Key1_0 ),
                            new KeyAndWidth(8, KeyWidth.Key1_0 ),
                            new KeyAndWidth(9, KeyWidth.Key1_0 ),
                            new KeyAndWidth(10, KeyWidth.Key1_0 ),
                            new KeyAndWidth(11, KeyWidth.Key1_0 ),
                            new KeyAndWidth(12, KeyWidth.Key1_0 ),
                            new KeyAndWidth(13, KeyWidth.Key1_0 ),
                            new KeyAndWidth(14, KeyWidth.Key2_0, KeyType.BackSpace )
                        },
                        new KeyAndWidth[]
                        {
                            new KeyAndWidth(15, KeyWidth.Key1_5, KeyType.Tab ),
                            new KeyAndWidth(16, KeyWidth.Key1_0),
                            new KeyAndWidth(17, KeyWidth.Key1_0 ),
                            new KeyAndWidth(18, KeyWidth.Key1_0 ),
                            new KeyAndWidth(19, KeyWidth.Key1_0 ),
                            new KeyAndWidth(20, KeyWidth.Key1_0 ),
                            new KeyAndWidth(21, KeyWidth.Key1_0 ),
                            new KeyAndWidth(22, KeyWidth.Key1_0 ),
                            new KeyAndWidth(23, KeyWidth.Key1_0 ),
                            new KeyAndWidth(24, KeyWidth.Key1_0 ),
                            new KeyAndWidth(25, KeyWidth.Key1_0 ),
                            new KeyAndWidth(26, KeyWidth.Key1_0 ),
                            new KeyAndWidth(27, KeyWidth.Key1_0 ),
                            new KeyAndWidth(28, KeyWidth.keyL1, KeyType.Return),
                        },
                        new KeyAndWidth[]
                        {
                            new KeyAndWidth(29, KeyWidth.Key1_75, KeyType.Caps ),
                            new KeyAndWidth(30, KeyWidth.Key1_0 ),
                            new KeyAndWidth(31, KeyWidth.Key1_0 ),
                            new KeyAndWidth(32, KeyWidth.Key1_0 ),
                            new KeyAndWidth(33, KeyWidth.Key1_0 ),
                            new KeyAndWidth(34, KeyWidth.Key1_0 ),
                            new KeyAndWidth(35, KeyWidth.Key1_0 ),
                            new KeyAndWidth(36, KeyWidth.Key1_0 ),
                            new KeyAndWidth(37, KeyWidth.Key1_0 ),
                            new KeyAndWidth(38, KeyWidth.Key1_0 ),
                            new KeyAndWidth(39, KeyWidth.Key1_0 ),
                            new KeyAndWidth(40, KeyWidth.Key1_0 ),
                            new KeyAndWidth(41, KeyWidth.Key1_0 )
                        },
                        new KeyAndWidth[]
                        {
                            new KeyAndWidth(42, KeyWidth.Key1_25, KeyType.Shift ),
                            new KeyAndWidth(43, KeyWidth.Key1_0 ),
                            new KeyAndWidth(44, KeyWidth.Key1_0 ),
                            new KeyAndWidth(45, KeyWidth.Key1_0 ),
                            new KeyAndWidth(46, KeyWidth.Key1_0 ),
                            new KeyAndWidth(47, KeyWidth.Key1_0 ),
                            new KeyAndWidth(48, KeyWidth.Key1_0 ),
                            new KeyAndWidth(49, KeyWidth.Key1_0 ),
                            new KeyAndWidth(50, KeyWidth.Key1_0 ),
                            new KeyAndWidth(51, KeyWidth.Key1_0 ),
                            new KeyAndWidth(52, KeyWidth.Key1_0 ),
                            new KeyAndWidth(53, KeyWidth.Key1_0 ),
                            new KeyAndWidth(54, KeyWidth.Key2_75, KeyType.Shift )
                        },
                        new KeyAndWidth[]
                        {
                            new KeyAndWidth(55, KeyWidth.Key1_25, KeyType.LeftCtrl ),
                            new KeyAndWidth(56, KeyWidth.Key1_25, KeyType.OS ),
                            new KeyAndWidth(57, KeyWidth.Key1_25, KeyType.LeftAlt ),
                            new KeyAndWidth(58, KeyWidth.Key6_25 ),
                            new KeyAndWidth(59, KeyWidth.Key1_25, KeyType.RightCtrl ),
                            new KeyAndWidth(60, KeyWidth.Key1_25, KeyType.OS ),
                            new KeyAndWidth(61, KeyWidth.Key1_25, KeyType.Menu ),
                            new KeyAndWidth(62, KeyWidth.Key1_25, KeyType.RightCtrl )
                        }
                    };
            }
        }

        /// <summary>
        /// The map of key no's to lower and uppercase values
        /// </summary>
        public Dictionary<int, string[]> TextMap { 
            get
            {
                return new Dictionary<int, string[]>()
                {
                    // ignore 1
                    {2, new [] {"1", "!"} },
                    {3, new [] {"2", "\""} },
                    {4, new [] {"3", "£"} },
                    {5, new [] {"4", "$"} },
                    {6, new [] {"5", "%"} },
                    {7, new [] {"6", "^"} },
                    {8, new [] {"7", "&"} },
                    {9, new [] {"8", "*"} },
                    {10, new [] {"9", "("} },
                    {11, new [] {"0", ")"} },
                    {12, new [] {"-", "_"} },
                    {13, new [] {"=", "+"} },
                    {14, new [] {"BACK"} },

                    {15, new [] {"TAB"} },
                    {16, new [] {"Q"} },
                    {17, new [] {"W"} },
                    {18, new [] {"E"} },
                    {19, new [] {"R"} },
                    {20, new [] {"T"} },
                    {21, new [] {"Y"} },
                    {22, new [] {"U"} },
                    {23, new [] {"I"} },
                    {24, new [] {"O"} },
                    {25, new [] {"P"} },
                    {26, new [] {"[", "{"} },
                    {27, new [] {"]", "}"} },
                    {28, new [] {"RETURN"} },

                    {29, new [] {"CAPS"} },
                    {30, new [] {"A"} },
                    {31, new [] {"S"} },
                    {32, new [] {"D"} },
                    {33, new [] {"F"} },
                    {34, new [] {"G"} },
                    {35, new [] {"H"} },
                    {36, new [] {"J"} },
                    {37, new [] {"K"} },
                    {38, new [] {"L"} },
                    {39, new [] {";", ":"} },
                    {40, new [] {"'", "@"} },
                    {41, new [] {"#", "~"} },

                    {42, new [] {"SHIFT"} },
                    {43, new [] {"\\", "|"} },
                    {44, new [] {"Z"} },
                    {45, new [] {"X"} },
                    {46, new [] {"C"} },
                    {47, new [] {"V"} },
                    {48, new [] {"B"} },
                    {49, new [] {"N"} },
                    {50, new [] {"M"} },
                    {51, new [] {",", "<"} },
                    {52, new [] {".", ">"} },
                    {53, new [] {"/", "?"} },
                    {54, new [] {"SHIFT"} },

                    {55, new [] {"CTRL"} },
                    {56, new [] {"OS"} },
                    {57, new [] {"ALT"} },
                    {58, new [] {" "} },
                    {59, new [] {"ALT GR"} },
                    {60, new [] {"OS"} },
                    {61, new [] {"MENU"} },
                    {62, new [] {"CTRL"} }
                };
            }
        }
    }
}
