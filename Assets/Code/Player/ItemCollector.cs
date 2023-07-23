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
                    GameManager.I.ShowText("Well, this in somekind of cleaning tool. Oh! They use it for their teeth. What?! Humans have teeth?", 8);
                    AcceptItem(item, collision);
                    break;
                case CollectableType.CoffeePot:
                    GameManager.I.ShowText("My scanner says this is drug used by humans to stay awake, especially in gamejams.", 7);
                    AcceptItem(item, collision);
                    break;
                case CollectableType.FryingPan:
                    GameManager.I.ShowText("You can fry food with this one. Or use it as a weapon. Winner winner chicken dinner it is.", 8);
                    AcceptItem(item, collision);
                    break;
                case CollectableType.GameController:
                    GameManager.I.ShowText("Humans like to consume blue light. This device is for moving yourself on the screen. Why they don't just use their brain for it?", 8);
                    AcceptItem(item, collision);
                    break;
                case CollectableType.PaintRoller:
                    GameManager.I.ShowText("You can decorate your home base with this!", 6);
                    AcceptItem(item, collision);
                    break;
                case CollectableType.PaintBucket:
                    GameManager.I.ShowText("Humans can do something called art. You can use brushes to put paint to canvas... Eh.. What?", 8);
                    AcceptItem(item, collision);
                    break;
                case CollectableType.USBStick:
                    GameManager.I.ShowText("Oh! Here is visual footage called video. Let's see what's inside! *inserts it to ship computer* ewww... I think I'm not allowed to see that... Let's put it back...", 11);
                    GameManager.I.PlayAlienHmmSound();
                    collision.GetComponent<Collectable>().DropItem();
                    break;
                case CollectableType.Cash:
                    GameManager.I.ShowText("This rules whole humanworld.. Just a piece of paper", 6);
                    AcceptItem(item, collision);
                    break;
                case CollectableType.Book:
                    GameManager.I.ShowText("I like this one! My scanne rsays you can consume information with this by reading it.", 8);
                    AcceptItem(item, collision);
                    break;
                case CollectableType.Saw:
                    GameManager.I.ShowText("Ouch, this is sharp! You can cut trees with this. We don't do that in our planet. I just put it back where I found it.", 9);
                    GameManager.I.PlayAlienHmmSound();
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
        GameManager.I.PlayCollectSound();
    }
}
