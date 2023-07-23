using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{
    public AudioSource buttonSound;

    public void BUTTON_PlaySoundAndCloseGame()
    {
        buttonSound.Play();
        Invoke(nameof(Close), 1.5f);
    }
    
    void Close()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
