using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CollectableType> collectedItems;
    public bool Won { get; private set; }

    public static GameManager I;

    public GameObject endScreenUI;
    
    void Start()
    {
        I = this;
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

    void Update()
    {
        if (!Won && collectedItems.Count == 1)
        {
            Won = true;
            print("won game, rewards: ");
            PlayerController.I.Invoke(nameof(PlayerController.I.EndAnimation), 2);

            foreach (var item in collectedItems)
            {
                print(item.ToString());
            }
        }
    }
}
