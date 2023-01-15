using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRSimpleKeyboard
{
    /// <summary>
    /// Abstract key object that represend a key. It has a KeyNo which uniquely identifies it in its layout and a type 
    /// </summary>
    public abstract class Key
    {
        /// <summary>
        /// Unique identifier for a key in its layout
        /// </summary>
        public int KeyNo { get; protected set; }

        /// <summary>
        /// The type of key that it is
        /// </summary>
        public KeyType KeyType { get; protected set; }

    }
}
