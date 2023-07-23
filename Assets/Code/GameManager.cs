using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<CollectableType> collectedItems;
    public bool Won { get; private set; }

    public static GameManager I;

    public GameObject endScreenUI;
    public GameObject onScreenInputUI;
    public TMP_Text dialogueText;

    public AudioSource momShipArrival;

    private void Awake()
    {
        I = this;
        ClearText();
    }

    void Start()
    {
        onScreenInputUI?.SetActive(false);
    }

    public void AddToCollectedItems(CollectableType collectable)
    {
        collectedItems.Add(collectable);
    }

    public void ShowEndScreen()
    {
        if (endScreenUI != null)
        {
            endScreenUI.SetActive(true);
        }
    }

    public void ShowText(string message, float duration = 6)
    {
        CancelInvoke(nameof(ClearText));
        dialogueText.text = message;
        Invoke(nameof(ClearText), duration);
    }


    void ClearText()
    {
        dialogueText.text = "";
    }

    void Update()
    {
        if (!Won && collectedItems.Count == 8)
        {
            Won = true;            
            momShipArrival.Play();
            Invoke(nameof(DelayedWinGame), 7); // need time to show final message

            //foreach (var item in collectedItems)
            //{
            //    print(item.ToString());
            //}
        }
    }

    [ContextMenu("WinGame")]
    void DelayedWinGame()
    {
        ShowText("Home calling... Oh, I'm late! WOOOOOOOOOO!");
        onScreenInputUI?.SetActive(false);
        PlayerController.I.Invoke(nameof(PlayerController.I.EndAnimation), 2);
    }
}
