using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;


public class LoadOutSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Stats stats;

    public Item item;
    public Image icon;
    public bool canWeapon = false;
    public bool canBow = false;
    public bool canHead = false;
    public bool canCarry = false;
    public bool hasItem = false;
    public int size = 0;

    private void Update()
    {
        if (item != null) size = item.ammount;
        else size = 0;
    }
    public void addItem(Item newItem)
    {
        item = newItem;
        stats.updateStats(item);
        item.ammount = newItem.ammount;
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.preserveAspect = true;
        hasItem = true;
    }

    public void clearSlot()
    {
        size = 0;
        stats.removeStats(item);
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        hasItem = false;
    }


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<whatSlot>().inventorySlot == true)
            {
                if (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item.weapon == true && canWeapon == true)
                {
                    addItem(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                    inventory.instance.remove(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<Transform>().SetSiblingIndex
                        (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().slotPos);
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().clearSlot();
                    eventData.pointerDrag.GetComponent<Transform>().position =
                    eventData.pointerDrag.GetComponent<Transform>().parent.position;
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponentInChildren<DropItem>().text.text = "";
                }
                else if (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item.bow == true && canBow == true)
                {
                    addItem(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                    inventory.instance.remove(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<Transform>().SetSiblingIndex
                        (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().slotPos);
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().clearSlot();
                    eventData.pointerDrag.GetComponent<Transform>().position =
                    eventData.pointerDrag.GetComponent<Transform>().parent.position;
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponentInChildren<DropItem>().text.text = "";
                }
                else if (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item.headGear == true && canHead == true)
                {
                    addItem(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                    inventory.instance.remove(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<Transform>().SetSiblingIndex
                        (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().slotPos);
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().clearSlot();
                    eventData.pointerDrag.GetComponent<Transform>().position =
                    eventData.pointerDrag.GetComponent<Transform>().parent.position;
                    eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponentInChildren<DropItem>().text.text = "";
                }

                else if (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item.canLoadOut == true && canCarry == true)
                {
                    if (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item.stackable == false)
                    {
                        addItem(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                        inventory.instance.remove(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                        eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<Transform>().SetSiblingIndex
                            (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().slotPos);
                        eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().clearSlot();
                        eventData.pointerDrag.GetComponent<Transform>().position =
                        eventData.pointerDrag.GetComponent<Transform>().parent.position;
                        eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponentInChildren<DropItem>().text.text = "";
                    }

                   else if(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item.stackable && hasItem == true) 
                    {
                        inventory.instance.remove(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                        item.ammount += eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item.ammount;
                        eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().clearSlot();
                        eventData.pointerDrag.GetComponent<Transform>().position =
                        eventData.pointerDrag.GetComponent<Transform>().parent.position;
                        eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponentInChildren<DropItem>().text.text = "";
                    }
                    else if(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item.stackable && hasItem == false) 
                    {
                        addItem(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                        inventory.instance.remove(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().item);
                        eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<Transform>().SetSiblingIndex
                            (eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().slotPos);
                        eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<inventorySlot>().clearSlot();
                        eventData.pointerDrag.GetComponent<Transform>().position =
                        eventData.pointerDrag.GetComponent<Transform>().parent.position;
                        eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponentInChildren<DropItem>().text.text = "";

                    }

                }
                else
                {
                    eventData.pointerDrag.GetComponent<Transform>().position =
                    eventData.pointerDrag.GetComponent<Transform>().parent.position;

                }
            }

            if(eventData.pointerDrag.GetComponent<DragItem>().baseParent.GetComponent<whatSlot>().loadoutSlot == true) 
            {

                eventData.pointerDrag.GetComponent<Transform>().position =
                eventData.pointerDrag.GetComponent<Transform>().parent.position;
            }
        }
    }

}
