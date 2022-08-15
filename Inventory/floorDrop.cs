using UnityEngine.EventSystems;
using UnityEngine;


public class floorDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<DropItem>().dropItem();
    }

}
