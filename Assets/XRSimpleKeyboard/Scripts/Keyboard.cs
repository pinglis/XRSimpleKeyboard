using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace XRSimpleKeyboard
{
    public class Keyboard : MonoBehaviour
    {

        [Header("Events")]
        public UnityEvent<Key> OnKeyDown;
        public UnityEvent<Key> OnKeyUp;

        [Header("Prefabs")]
        [SerializeField]
        private GameObject key_1_00Prefab;

        [SerializeField]
        private GameObject key1_25Prefab;

        [SerializeField]
        private GameObject key1_50Prefab;

        [SerializeField]
        private GameObject key1_75Prefab;

        [SerializeField]
        private GameObject key2_00Prefab;

        [SerializeField]
        private GameObject key2_25Prefab;

        [SerializeField]
        private GameObject key2_75Prefab;

        [SerializeField]
        private GameObject key6_25Prefab;

        [SerializeField]
        private GameObject keyL1Prefab;

        [Header("Locale")]
        public string locale = "en-GB";

        [Header("UI")]
        [SerializeField]
        private Camera worldCamera;

        [Header("Audio & Haptics")]
        public AudioClip KeyClickAudio;

        [SerializeField]
        public Material KeyUpMaterial;

        [SerializeField]
        public Material KeyDownMaterial;

        private LayoutManager layoutManger = new LayoutManager();
        private Dictionary<GameObject, Key> keyMap = new Dictionary<GameObject, Key>();
        private ILayout layout;


        /// <summary>
        /// Perform a layout of the keyboard and add its keys to the parent gameobject
        /// </summary>
        public void Start()
        {             
            float z = 0;

            // Get the correct layout for our locale
            layout = layoutManger.GetLayout(locale);            

            // Create a parent rows empty gameobject that scales its children to 1 
            // and starts in the far left corner of the keyboard with the center in the middle
            // of the keyboard.
            // Note all keys have a height of 1 and a width of KeyWidth
            GameObject parent = InstantiateEmpty("rows", new Vector3(-0.5f, 0, 0.5f), new Vector3(1.0f / layout.Width, 1, 1.0f / layout.Keys.Length), transform);

            // Use an int to keep track of which row we are on
            int r = 0;

            // For each row starting in the far left
            // Note: the grid is now the number of rows * the number of keys (taking into account key width)
            foreach (KeyAndWidth[] row in layout.Keys)
            { 
                // Create a row object for the keys and start it in the correct place on the left
                GameObject rowObj = InstantiateEmpty("row_" +r, new Vector3(0, 0, z-0.5f), Vector3.one, parent.transform);
                
                // Move z a key height
                z -= 1f;


                float x = 0f;
                foreach (KeyAndWidth k in row)
                {
                    // Get the current text for the key in the correct locale
                    string[] cs = GetKeyTextInCurrentLocale(k.KeyNo);

                    // Move on half the width of the key
                    x += GetWidth(k.KeyWidth) / 2f;

                    // Get the prefab for the key width
                    GameObject prefab = GetPrefab(k.KeyWidth);

                    // Create the key at this location 
                    GameObject obj = InstantiateKey("key_" + k.KeyNo, prefab, cs, new Vector3(x, 0, 0), rowObj.transform);

                    // Move on half the width of the key
                    x += GetWidth(k.KeyWidth) / 2f;

                    // Store the key for later use
                    keyMap.Add(obj, k);
                }

                // move on to next row
                r++;
            }
        }

        /// <summary>
        /// Create a new empty Gameobject
        /// </summary>
        /// <param name="name">Name to give the gameobject</param>
        /// <param name="position">Vector3 local position</param>
        /// <param name="scale">Vector3 local scale</param>
        /// <param name="parent">The parent of the gameobject</param>
        /// <returns></returns>
        private GameObject InstantiateEmpty(string name, Vector3 position, Vector3 scale, Transform parent)
        {
            var go = new GameObject(name);

            if (parent != null)
            {
                go.transform.parent = parent;
            }

            // Initialise its local transform
            go.transform.localScale = scale;
            go.transform.localEulerAngles = Vector3.zero;
            go.transform.localPosition = position;

            return go;
        }

        /// <summary>
        /// Create a new gameobject for a key
        /// </summary>
        /// <param name="name">Name to give the gameobject</param>
        /// <param name="prefab">The prefab to use to create the key</param>
        /// <param name="strs">The locale aware strings to use to put text on the key</param>
        /// <param name="position">Vector3 local position</param>
        /// <param name="parent">The parent of the gameobject</param>
        /// <returns></returns>
        private GameObject InstantiateKey(string name, GameObject prefab, string[] strs, Vector3 position, Transform parent)
        {
            // Create a new gameobject
            var go = Instantiate(prefab, parent);
            go.name = name;

            // Initialise its local transform
            go.transform.localEulerAngles = Vector3.zero;
            go.transform.localPosition = position;
            go.transform.localScale = prefab.transform.localScale;

            // Get the KeyBehaviour on the script and initialize its parameters
            var script = go.GetComponent<KeyBehaviour>();

            // Initialise the text strings
            string keyValue = null;
            string keyShiftValue = null;
            if (strs != null)
            {
                keyValue = strs[0];

                if (strs.Length > 1)
                {
                    keyShiftValue = strs[1];
                }
            }
            script.KeyValue = keyValue;
            script.KeyShiftValue = keyShiftValue;

            // Confirm the key press travel height
            script.KeyPressHeight = 0.1f;

            // And listen to key pressed events
            script.OnKeyDown += HandleKeyDown;
            script.OnKeyUp += HandleKeyUp;

            // The world camera should not be null for performance!
            script.WorldCamera = worldCamera;

            // Set materials to use
            script.KeyDownMaterial = this.KeyDownMaterial;
            script.KeyUpMaterial = this.KeyUpMaterial;

            return go;
        }

        /// <summary>
        /// Get the locale aware text for a given key
        /// </summary>
        /// <param name="keyNo">The identifier for the key</param>
        /// <param name="shiftPressed">Whether to return the shift pressed verison of the key or not</param>
        /// <returns>string</returns>
        public string GetKeyTextInCurrentLocale(int keyNo, bool shiftPressed)
        {
            string[] values = null;

            layout.TextMap.TryGetValue(keyNo, out values);

            if ( values != null )
            {
                if (shiftPressed)
                {
                    return values[values.Length-1];
                }
                else
                {
                    return values[0].ToLower();
                }
            }

            return null;
        }

        /// <summary>
        /// Get the locale aware text values for a given key
        /// </summary>
        /// <param name="keyNo">The identifier for the ke</param>
        /// <returns>string[]</returns>
        private string[] GetKeyTextInCurrentLocale(int keyNo)
        {
            string[] values;

            layout.TextMap.TryGetValue(keyNo, out values);

            return values;
        }

        /// <summary>
        /// Get the prefab that has the specified width
        /// </summary>
        /// <param name="width">Key width</param>
        /// <returns></returns>
        private GameObject GetPrefab(KeyWidth width)
        {
            GameObject prefab;
            switch (width)
            {
                case KeyWidth.Key1_25:
                    prefab = this.key1_25Prefab;
                    break;
                case KeyWidth.Key1_5:
                    prefab = this.key1_50Prefab;
                    break;
                case KeyWidth.Key1_75:
                    prefab = this.key1_75Prefab;
                    break;
                case KeyWidth.Key2_0:
                    prefab = this.key2_00Prefab;
                    break;
                case KeyWidth.Key2_25:
                    prefab = this.key2_25Prefab;
                    break;
                case KeyWidth.Key2_75:
                    prefab = this.key2_75Prefab;
                    break;
                case KeyWidth.Key6_25:
                    prefab = this.key6_25Prefab;
                    break;
                case KeyWidth.Key1_0:
                    prefab = this.key_1_00Prefab;
                    break;
                case KeyWidth.keyL1:
                    prefab = this.keyL1Prefab;
                    break;
                default:
                    Debug.LogError("Unknown size: " + width);
                    prefab = null;
                    break;
            }
            return prefab;
        }

        /// <summary>
        /// Get the width of a key where the default key width is 1
        /// </summary>
        /// <param name="width">Key width</param>
        /// <returns></returns>
        private float GetWidth(KeyWidth width)
        {
            float f;
            switch (width)
            {
                case KeyWidth.Key1_25:
                    f = 1.25f;
                    break;
                case KeyWidth.Key1_5:
                    f = 1.5f;
                    break;
                case KeyWidth.Key1_75:
                    f = 1.75f;
                    break;
                case KeyWidth.Key2_0:
                    f = 2.0f;
                    break;
                case KeyWidth.Key2_25:
                    f = 2.25f;
                    break;
                case KeyWidth.Key2_75:
                    f = 2.75f;
                    break;
                case KeyWidth.Key6_25:
                    f = 6.25f;
                    break;
                case KeyWidth.Key1_0:
                    f = 1f;
                    break;
                case KeyWidth.keyL1:
                    f = 1.5f;
                        break;
                default:
                    Debug.LogError("Unknown size: " + width);
                    f = 1f;
                    break;
            }
            return f;
        }

        private void HandleKeyDown(KeyBehaviour behaviour)
        {
            OnKeyDown.Invoke(keyMap[behaviour.gameObject]);
        }

        private void HandleKeyUp(KeyBehaviour behaviour)
        {
            OnKeyUp.Invoke(keyMap[behaviour.gameObject]);
        }
    }
}




