using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioTweens : MonoBehaviour
{
    AudioSource audioSource;
    Sequence sequence;

    public float raiseLowerHighVol = 0.5f, raiseLowerHighTime = 1f, raiseLowerStayTime = 1f, raiseLowerLowVol = 0.2f, raiseLowerLowTime = 2f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TWEEN_RaiseAndLowerVolume()
    {
        sequence.Append(audioSource.DOFade(raiseLowerHighVol, raiseLowerHighTime))
            .AppendInterval(raiseLowerStayTime)
            .Append(audioSource.DOFade(raiseLowerLowVol, raiseLowerLowTime));
    }

    public void TWEEN_VolumeTo(float value, float time)
    {
        audioSource.DOFade(value, time);
    }
}
