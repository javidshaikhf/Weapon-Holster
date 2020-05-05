using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryItems
{
    Gun,
    Axe

}

public class InventoryItem : MonoBehaviour
{

    public bool isEntered;
    public InventoryItems inventoryItemType;

    public Transform inventoryPlaceHolderTransfrom, inLeftHandTransfrom, inRightHandTransfrom;

    public OVRGrabbable oVRGrabbable;

    private void OnEnable()
    {
        Debug.Log("Enabled");

        oVRGrabbable.onGrabBegin += OnBeginGrab;
        oVRGrabbable.onGrabEnd += OnBeginEnd;
    }

    private void OnDestroy()
    {
        oVRGrabbable.onGrabBegin -= OnBeginGrab;
        oVRGrabbable.onGrabEnd -= OnBeginEnd;
    }

    public void OnBeginGrab(OVRGrabber oVRGrabber)
    {

        if (oVRGrabber.m_controller == OVRInput.Controller.LTouch)
        {
            if (inLeftHandTransfrom)
            {
                transform.position = inLeftHandTransfrom.position;
                transform.rotation = inLeftHandTransfrom.rotation;
            }

        }
        else
        {
            if (inRightHandTransfrom)
            {
                transform.position = inRightHandTransfrom.position;
                transform.rotation = inRightHandTransfrom.rotation;

            }
        }

    }

    public void OnBeginEnd()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " Entering  " + other.gameObject.name);

        if (other.gameObject.tag.Equals("InventoryPlaceHolder"))
        {
            InventoryPlaceHolder inventoryPlaceHolder = other.gameObject.GetComponent<InventoryPlaceHolder>();
            if (inventoryPlaceHolder && inventoryPlaceHolder.inventoryItemType == inventoryItemType)
            {
                isEntered = true;
                inventoryPlaceHolderTransfrom = inventoryPlaceHolder.placeHolderTranform;
                SetPos();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(gameObject.name + " Exiting  " + other.gameObject.name);

        if (other.gameObject.tag.Equals("InventoryPlaceHolder"))
        {
            InventoryPlaceHolder inventoryPlaceHolder = other.gameObject.GetComponent<InventoryPlaceHolder>();
            if (inventoryPlaceHolder && inventoryPlaceHolder.inventoryItemType == inventoryItemType)
            {
                isEntered = false;
            }
        }
    }


    private void SetPos()
    {

        GetComponent<Rigidbody>().isKinematic = true;

        transform.localPosition = inventoryPlaceHolderTransfrom.localPosition;
        transform.rotation = inventoryPlaceHolderTransfrom.rotation;
        transform.localScale = inventoryPlaceHolderTransfrom.localScale;
    }

}
