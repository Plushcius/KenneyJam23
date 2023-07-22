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

    public void ShowText(string message, float duration = 4)
    {
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
            onScreenInputUI?.SetActive(false);
            Invoke(nameof(DelayedWinGame), 2);

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
        PlayerController.I.Invoke(nameof(PlayerController.I.EndAnimation), 2);
    }
}
