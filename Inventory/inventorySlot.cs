using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class inventorySlot : MonoBehaviour,IDropHandler
{
    
    public Item item;
    public Image icon;
    public int slotPos;
    public bool hasItem = false;

    public int size = 0;
    private void Start()
    {
       slotPos = transform.GetSiblingIndex();
    }

    private void Update()
    {
        if(item != null)
        size = item.ammount;
        else size = 0;
    }
    public void addItem(Item newItem) 
    {
        
        item = newItem;
        item.ammount = newItem.ammount;
        icon.sprite = item.icon;
        icon.enabled = true;
        hasItem = true;
        icon.preserveAspect = true;

    }

    public void clearSlot() 
    {
        
        size = 0;
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        hasItem = false;
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null) 
        {
            if (hasItem == false)
            {
                if (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<whatSlot>().inventorySlot == true)
                {
                    addItem(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<Transform>().SetSiblingIndex
                        (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().slotPos);
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().clearSlot();
                    eventData.pointerDrag.GetComponent<Transform>().position =
                    eventData.pointerDrag.GetComponent<Transform>().parent.position;
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponentInChildren<DropItem>().text.text = "";
                    Debug.Log("Work");
                }

                if (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<whatSlot>().loadoutSlot == true) 
                {
                    addItem(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<LoadOutSlot>().item);
                    inventory.instance.items.Add(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<LoadOutSlot>().item);
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<LoadOutSlot>().clearSlot();
                    eventData.pointerDrag.GetComponent<Transform>().position =
                    eventData.pointerDrag.GetComponent<Transform>().parent.position;
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponentInChildren<DropItem>().text.text = "";
                    Debug.Log("Work");
                }
            }
            else if(item.stackable == true)
            {
                if (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<whatSlot>().inventorySlot == true) 
                {
                    item.ammount += eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item.ammount;
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<Transform>().SetSiblingIndex
                        (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().slotPos);
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().clearSlot();
                    eventData.pointerDrag.GetComponent<Transform>().position =
                    eventData.pointerDrag.GetComponent<Transform>().parent.position;
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponentInChildren<DropItem>().text.text = "";
                }
                if (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<whatSlot>().loadoutSlot == true) 
                {
                    item.ammount += eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<LoadOutSlot>().item.ammount;
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<LoadOutSlot>().clearSlot();
                    eventData.pointerDrag.GetComponent<Transform>().position =
                    eventData.pointerDrag.GetComponent<Transform>().parent.position;
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponentInChildren<DropItem>().text.text = "";
                }

            }
        }
    }

}
