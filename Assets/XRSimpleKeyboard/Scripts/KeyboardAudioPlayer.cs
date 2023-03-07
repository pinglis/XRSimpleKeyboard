using UnityEngine;
using XRSimpleKeyboard;

/// <summary>
/// Example class you can add to a object to play audio when a key is pressed
/// </summary>
public class KeyboardAudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip keyDownAudioClip;

    [SerializeField]
    private Keyboard keyboard;

    private void Start()
    {
        if (keyboard != null)
        {
            keyboard.OnKeyDown.AddListener(PlayAudio);
        }
    }

    private void PlayAudio(Key k)
    {
        if (audioSource != null && keyDownAudioClip != null)
        {
            audioSource.PlayOneShot(keyDownAudioClip);
        }
    }
}
