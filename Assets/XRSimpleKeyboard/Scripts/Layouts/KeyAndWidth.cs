using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XRSimpleKeyboard;

namespace XRSimpleKeyboard
{
    // A utility class that allow us to store the width of a key along with its definition
    internal class KeyAndWidth: Key
    {
        /// <summary>
        /// The width of the key. Most keys are 1.
        /// </summary>
        public KeyWidth KeyWidth { get; private set; }

        /// <summary>
        /// The key data plus width for layout purposes
        /// </summary>
        /// <param name="keyNo">Unique identifier for the key</param>
        /// <param name="size">The size of the key</param>
        public KeyAndWidth(int keyNo, KeyWidth size): this(keyNo, size, KeyType.Normal) 
        {

        }

        /// <summary>
        /// The key data plus width for layout purposes
        /// </summary>
        /// <param name="keyNo">Unique identifier for the key</param>
        /// <param name="size">The size of the key</param>
        /// <param name="keyType">The type of the key</param>
        public KeyAndWidth(int keyNo, KeyWidth size, KeyType keyType)
        {
            base.KeyNo = keyNo;
            base.KeyType = keyType;

            KeyWidth = size;
        }
    }
}
