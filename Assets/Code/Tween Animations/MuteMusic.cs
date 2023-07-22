using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MuteMusic : MonoBehaviour
{
    public float time = 1f;
    public float toValue = 0f;

    public void MuteAudioSource()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.DOFade(toValue, time);
    }
}
