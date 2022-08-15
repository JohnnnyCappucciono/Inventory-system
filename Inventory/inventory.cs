using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventory : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject invetoryUI;
    public inventorySlot[] slots;
    public Image noSpace;
    public TextMeshProUGUI text;
    public static inventory instance;
    bool itemPlaced = false;
    private void Awake()
    {
        instance = this;
    }


    public List<Item> items = new List<Item>();
    public int space = 20;

    void Start()
    {

        invetoryUI.SetActive(false);
        slots = itemsParent.GetComponentsInChildren<inventorySlot>();
        noSpace.enabled = false;
        text.enabled = false;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            invetoryUI.SetActive(!invetoryUI.activeSelf);
          
        }
        if (items.Count >= space)
        {
            noSpace.enabled = true;
            text.enabled = true;
        }

        if (items.Count < space)
        {
            noSpace.enabled = false;
            text.enabled = false;
        }

    }
    public bool add(Item item) 
    {
        var clone = Instantiate(item);
        if (items.Count >= space)
        {

            Debug.Log("No Space");
            
            return false;
        }


            int i = 0;
        while(itemPlaced == false) 
        {
            if (clone.stackable == true) 
            {
                bool alreadyHaveItem = false;
            foreach(inventorySlot inventoryItem in slots) 
                {
                    if (inventoryItem.GetComponent<inventorySlot>().item != null)
                    {
                        if (inventoryItem.GetComponent<inventorySlot>().item.name == clone.name)
                        {
                            inventoryItem.GetComponent<inventorySlot>().item.ammount += item.ammount;
                            alreadyHaveItem = true;
                            itemPlaced = true;
                        }
                    }
                }
            if(alreadyHaveItem == false) 
                {
                    if (slots[i].hasItem == false)
                    {
                        items.Add(clone);
                        slots[i].addItem(clone);
                        itemPlaced = true;
                    }
                }
            }
            else
            {
                if (slots[i].hasItem == false)
                {
                    items.Add(clone);
                    slots[i].addItem(clone);
                    itemPlaced = true;
                }
            }
            i++;
        
        }
        itemPlaced = false;
            return true;
        
    
    }

    public void remove(Item item) 
    {
        items.Remove(item);
    }
}
