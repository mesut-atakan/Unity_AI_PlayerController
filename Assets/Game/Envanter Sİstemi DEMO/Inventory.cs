using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SCInventory playerInverntory;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Item")) //bu kodlama şekli mobil platformlar da daha stabil çalışır.
        {
            playerInverntory.AddItem(other.gameObject.GetComponent<Item>().item);
            Destroy(other.gameObject);
        }
    }
}
