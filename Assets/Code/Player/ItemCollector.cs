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
                    GameManager.I.ShowText(item.ToString() + " text");
                    AcceptItem(item, collision);
                    break;
                case CollectableType.CoffeePot:
                    GameManager.I.ShowText(item.ToString() + " text");
                    AcceptItem(item, collision);
                    break;
                case CollectableType.FryingPan:
                    GameManager.I.ShowText(item.ToString() + " text");
                    AcceptItem(item, collision);
                    break;
                case CollectableType.GameController:
                    GameManager.I.ShowText(item.ToString() + " text");
                    AcceptItem(item, collision);
                    break;
                case CollectableType.PaintRoller:
                    GameManager.I.ShowText(item.ToString() + " text");
                    AcceptItem(item, collision);
                    break;
                case CollectableType.PaintBucket:
                    GameManager.I.ShowText(item.ToString() + " text");
                    AcceptItem(item, collision);
                    break;
                case CollectableType.USBStick:
                    GameManager.I.ShowText(item.ToString() + " text");
                    collision.GetComponent<Collectable>().DropItem();
                    break;
                case CollectableType.Cash:
                    GameManager.I.ShowText(item.ToString() + " text");
                    AcceptItem(item, collision);
                    break;
                case CollectableType.Book:
                    GameManager.I.ShowText(item.ToString() + " text");
                    AcceptItem(item, collision);
                    break;
                case CollectableType.Saw:
                    GameManager.I.ShowText(item.ToString() + " text");
                    collision.GetComponent<Collectable>().DropItem();
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
        Destroy(collision.gameObject);
    }
}
