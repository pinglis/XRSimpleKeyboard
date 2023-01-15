using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace XRSimpleKeyboard
{
    /// <summary>
    /// Behaviour script that should be added to every key prefab
    /// </summary>
    public class KeyBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Delegate used in events
        /// </summary>
        /// <param name="data"></param>
        public delegate void Pressed(KeyBehaviour data);

        /// <summary>
        /// True if the key is currently pressed
        /// </summary>
        public bool IsPressed { get; private set; }

        /// <summary>
        /// Event to call when the key is released
        /// </summary>
        public event Pressed OnKeyDown;

        /// <summary>
        /// Event called when the key is pressed
        /// </summary>
        public event Pressed OnKeyUp;

        /// <summary>
        /// The text to display in the middle indicate the lowercase version of the key. Can be null.
        /// </summary>
        public string KeyValue;

        /// <summary>
        /// The text to display in the top right to indicate the shifted version of the key. Can be null.
        /// </summary>
        public string KeyShiftValue;
       

        /// <summary>
        /// The amount of momement a key does when you press it
        /// </summary>
        public float KeyPressHeight = 1f;

        /// <summary>
        /// The mesh of the key
        /// </summary>
        [SerializeField]
        private GameObject keyOffset;

        /// <summary>
        /// The label that shows the non-shifted key text
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI keyLabel;

        /// <summary>
        /// The label that shows the shifted key text
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI keyShiftLabel;

        /// <summary>
        /// The world camera. This should be set for efficency. Not setting this still
        /// works but it comes for a big performance impact.
        /// </summary>
        public Camera WorldCamera;

        /// <summary>
        /// The material to apply to the key
        /// </summary>
        public Material KeyMaterial;

        /// <summary>
        /// The color of the key text
        /// </summary>
        public Color KeyTextColor;

        /// <summary>
        /// A list of colliders that are current pushing on this button
        /// </summary>
        private HashSet<Collider> pressingColliders = new HashSet<Collider>();

        /// <summary>
        /// Initialize the key
        /// </summary>
        private void Start()
        {
            keyLabel.text = KeyValue;
            keyShiftLabel.text = KeyShiftValue;


            if (Application.IsPlaying(gameObject))
            {
                GetComponentInChildren<Canvas>().worldCamera = WorldCamera;
            }
        }

        /// <summary>
        /// Handle the key being pressed. Note, the user can press
        /// the key with both hands but we only want to register key exit
        /// when both hands are off the key.
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            // Ignore when in editor
            if (Application.IsPlaying(gameObject))
            {
                // Store this collider
                pressingColliders.Add(other);

                // If the key isn't already pressed
                if (!IsPressed)
                {
                    // Record that the key is pressed
                    IsPressed = true;

                    // Move the mesh down the required amount to that
                    // the user can tell it is pressed
                    MoveMesh();                  

                    // If someone has registered a listener, then notify them
                    if (OnKeyDown != null)
                    {
                        OnKeyDown(this);
                    }
                }
            }
        }

        /// <summary>
        /// Handle the key being released.Note, the user can press
        /// the key with both hands but we only want to register key exit
        /// when both hands are off the key.
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerExit(Collider other)
        {
            // Ignore when in editor
            if (Application.IsPlaying(gameObject))
            {
                // Remove this collider from the list of pressing colliders on this key
                pressingColliders.Remove(other);

                // If there are no more coliders on the key
                if (!pressingColliders.Any())
                {
                    // nothing is pressing on the collider anymore so lets raise the button
                    IsPressed = false;

                    // Move the mesh up the required amount to that
                    // the user can tell it is no longer pressed
                    MoveMesh();

                    // If someone has registered a listener, then notify them
                    if (OnKeyUp != null)
                    {
                        OnKeyUp(this);
                    }
                }
            }
        }

        /// <summary>
        /// Move the mesh gameobject up or down by KeyPressHeight in localspace
        /// </summary>
        private void MoveMesh()
        {
            float y;
            if (IsPressed)
            {
                y = keyOffset.transform.localPosition.y - KeyPressHeight;
            }
            else
            {
                y = keyOffset.transform.localPosition.y + KeyPressHeight;
            }
            keyOffset.transform.localPosition = new Vector3(keyOffset.transform.localPosition.x, y, keyOffset.transform.localPosition.z);
        }
    }
}
