using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    [Tooltip("Use full https links to ensure the link works on all platforms.")]
    public string url = "";


    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}

