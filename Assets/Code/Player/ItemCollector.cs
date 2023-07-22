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
            GameManager.I.AddToCollectedItems(collision.GetComponent<Collectable>().ItemType);
            PlayerController.I.DoVictorySpin();
            Destroy(collision.gameObject);        
        }
    }
}
