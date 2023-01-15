using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XRSimpleKeyboard.Layouts;

namespace XRSimpleKeyboard
{
    /// <summary>
    /// The layout manager holds the different type of keyboards and their locale bindings. 
    /// This class is really just a placeholder, you are expected to add your own bindings
    /// for your own locale.
    /// 
    /// Ideally, in the future this will read all of this dynamically from json files.
    /// </summary>
    internal class LayoutManager
    {
        private static ILayout defaultLayout = new EnGbLayout();

        private static Dictionary<string, ILayout> layoutMap = new Dictionary<string, ILayout>()
        {
            { "en-GB",  defaultLayout }
        }; 


        /// <summary>
        /// Returns the correct layout for the specified locale
        /// </summary>
        /// <param name="locale">locale to create the correct keyboard layout and keybindings for</param>
        /// <returns>ILayout describing the keyboard to create</returns>
        public ILayout GetLayout(string locale)
        {
            ILayout layout;
            
            if ( !layoutMap.TryGetValue(locale, out layout) )
            {
                layout = defaultLayout;
            }

            return layout;
        }
    }
}
