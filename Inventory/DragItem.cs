using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class DragItem : MonoBehaviour,IBeginDragHandler,IEndDragHandler, IDragHandler, IPointerEnterHandler,IPointerExitHandler
{
    private CanvasGroup canvasGroup;
    public Transform baseParent;
    public Image floor;
    public Image desc;
    public TextMeshProUGUI text;



    private void Start()
    {
        baseParent = transform.parent;
        canvasGroup = GetComponent<CanvasGroup>();
        desc.enabled = false;
        text.enabled = false;
    }

    private void Update()
    {
        
        if(baseParent.GetComponent<whatSlot>().inventorySlot == true) 
        {
            if (baseParent.GetComponent<inventorySlot>().item != null)
            { 
                text.text = baseParent.GetComponent<inventorySlot>().item.description; 
            }
            else 
            {
                desc.enabled = false;
                text.enabled = false;
            }
        }

        if (baseParent.GetComponent<whatSlot>().loadoutSlot == true)
        {
            if (baseParent.GetComponent<LoadOutSlot>().item != null)
            { text.text = baseParent.GetComponent<LoadOutSlot>().item.description;
            }
            else 
            {
                desc.enabled = false;
                text.enabled = false;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        baseParent.SetAsLastSibling();
        baseParent.parent.parent.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
        floor.raycastTarget = true;

    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
            transform.position = Input.mousePosition;
        desc.enabled = false;
        text.enabled = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        floor.raycastTarget = false;
        transform.position = baseParent.transform.position;
    }

    public void updateParent() 
    {
        baseParent = transform.parent;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (baseParent.GetComponent<whatSlot>().inventorySlot == true)
        {
            if (baseParent.GetComponent<inventorySlot>().item != null)
            {
                baseParent.SetAsLastSibling();
                baseParent.parent.parent.SetAsLastSibling();
                desc.enabled = true;
                text.enabled = true;
            }
            else { desc.enabled = false;
                text.enabled = false;
            }
        }

        if (baseParent.GetComponent<whatSlot>().loadoutSlot == true)
        {
            if (baseParent.GetComponent<LoadOutSlot>().item != null)
            {
                baseParent.SetAsLastSibling();
                baseParent.parent.parent.SetAsLastSibling(); 
                desc.enabled = true;
                text.enabled = true;
            }
            else { desc.enabled = false;
                text.enabled = false;
            }
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        desc.enabled = false;
        text.enabled = false;
    }
}
