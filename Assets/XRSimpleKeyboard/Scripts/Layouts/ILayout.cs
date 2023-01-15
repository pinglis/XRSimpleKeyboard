using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XRSimpleKeyboard;

namespace XRSimpleKeyboard
{
    internal interface ILayout
    {
        /// <summary>
        /// Keyboards are on a grid with a set width. This should represent that. Note
        /// each key is expected have a width of 1
        /// </summary>
        public int Width { get; }


        /// <summary>
        /// An array of arrays of the keys
        /// </summary>
        public KeyAndWidth[][] Keys { get; }


        /// <summary>
        /// A map of all the locale text strings for each key
        /// </summary>
        public Dictionary<int, string[]> TextMap { get; }
    }
}
