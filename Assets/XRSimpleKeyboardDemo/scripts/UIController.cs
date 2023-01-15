using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using XRSimpleKeyboard;

namespace XRSimpleKeyboardDemo
{
    /// <summary>
    /// Test class for binding the keyboard to a some UI fields
    /// </summary>
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private Keyboard keyboard;

        [SerializeField]
        private TMP_InputField[] textFields;

        private bool shiftPressed;
        private bool capsDown;

        private int currentField;

        private void Start()
        {
            keyboard.OnKeyDown.AddListener(KeyDown);
            keyboard.OnKeyUp.AddListener(KeyUp);
        }

        private void KeyUp(Key key)
        {
            switch (key.KeyType)
            {
                case KeyType.Shift:
                    shiftPressed = false;
                    break;
            }
        }

        private void KeyDown(Key key)
        {
            switch (key.KeyType)
            {
                case KeyType.Shift:
                    shiftPressed = true;
                    break;
                case KeyType.Normal:
                    string k = keyboard.GetKeyTextInCurrentLocale(key.KeyNo, shiftPressed | capsDown);
                    textFields[currentField].text += k;
                    break;
                case KeyType.Return or KeyType.Tab:
                    currentField++;

                    if (currentField >= textFields.Length)
                    {
                        currentField = 0;
                    }
                    break;
                case KeyType.Del or KeyType.BackSpace:
                    if (textFields[currentField].text.Length > 0)
                    {
                        textFields[currentField].text = textFields[currentField].text.Remove(textFields[currentField].text.Length - 1, 1);
                    }
                    break;
                case KeyType.Caps:
                    capsDown = !capsDown;
                    break;
            }
        }
    }
}
