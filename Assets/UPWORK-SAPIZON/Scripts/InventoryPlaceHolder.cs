using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class InventoryPlaceHolder : MonoBehaviour
{

    public InventoryItems inventoryItemType;
    
    public Transform placeHolderTranform;

    bool isEntered;

    private void OnTriggerEnter(Collider other) {
        isEntered = true;
    }

    private void OnTriggerExit(Collider other) {
        isEntered = false;
    }

}
