using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WriteInParts : MonoBehaviour
{
    public float delay = 0f, timeBetweenLetters = 0.1f, randomVariance = 0.05f;

    TMP_Text tmpText;
    string fullString;

    // game specific
    public GameObject credits;
    
    [ContextMenu("Write")]
    IEnumerator Start()
    {
        tmpText = GetComponent<TMP_Text>();
        fullString = tmpText.text;
        tmpText.text = "";

        yield return new WaitForSeconds(delay);

        for (int i = 0; i < fullString.Length; i++)
        {
            tmpText.text = fullString.Substring(0, i + 1);
            yield return new WaitForSeconds(timeBetweenLetters + Random.Range(0f, randomVariance));
        }

        DoStuffAfterText();
    }
    
    void DoStuffAfterText()
    {
        credits.SetActive(true);
    }
}
