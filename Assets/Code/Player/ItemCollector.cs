using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            print("Collected: " + collision.gameObject.name);
            var item = collision.GetComponent<Collectable>().ItemType;

            switch (item)
            {
                case CollectableType.Toothbrush:
                    GameManager.I.ShowText("");
                    GameManager.I.AddToCollectedItems(item);
                    PlayerController.I.DoVictorySpin();

                    break;
                case CollectableType.CoffeePot:
                    GameManager.I.ShowText("");
                    GameManager.I.AddToCollectedItems(item);
                    PlayerController.I.DoVictorySpin();
                    break;
                case CollectableType.FryingPan:
                    GameManager.I.ShowText("");
                    GameManager.I.AddToCollectedItems(item);
                    PlayerController.I.DoVictorySpin();
                    break;
                case CollectableType.GameController:
                    GameManager.I.ShowText("");
                    GameManager.I.AddToCollectedItems(item);
                    PlayerController.I.DoVictorySpin();
                    break;
                case CollectableType.PaintRoller:
                    GameManager.I.ShowText("");
                    GameManager.I.AddToCollectedItems(item);
                    PlayerController.I.DoVictorySpin();
                    break;
                case CollectableType.PaintBucket:
                    GameManager.I.ShowText("");
                    GameManager.I.AddToCollectedItems(item);
                    PlayerController.I.DoVictorySpin();
                    break;
                case CollectableType.USBStick:
                    GameManager.I.ShowText("");
                    // drop

                    break;
                case CollectableType.Cash:
                    GameManager.I.ShowText("");
                    GameManager.I.AddToCollectedItems(item);
                    PlayerController.I.DoVictorySpin();
                    break;
                case CollectableType.Book:
                    GameManager.I.ShowText("");
                    GameManager.I.AddToCollectedItems(item);
                    PlayerController.I.DoVictorySpin();
                    break;
                case CollectableType.Saw:
                    GameManager.I.ShowText("");
                    // drop
                    break;
                default:
                    break;
            }
            
            
        }
    }

    void AcceptItem(CollectableType type, Collider2D collision)
    {
        GameManager.I.AddToCollectedItems(type);
        PlayerController.I.DoVictorySpin();
    }
}
