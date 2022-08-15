using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropItem : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private DragItem slot;

    [SerializeField] private Button use;
    [SerializeField] private Button remove;

    [SerializeField] private LoadOutSlot weaponSlot;
    [SerializeField] private LoadOutSlot bowSlot;
    [SerializeField] private LoadOutSlot neckSlot;

    public TextMeshProUGUI text;
    Item item;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (slot.baseParent.GetComponent<whatSlot>().inventorySlot == true)
        { 
           var size = slot.baseParent.GetComponent<inventorySlot>().size;
            item = slot.baseParent.GetComponent<inventorySlot>().item;
            if (transform.parent.GetComponent<inventorySlot>().item != null)
            {
                use.enabled = true;
                remove.enabled = true;
                remove.image.enabled = true;

                if (size > 1)
                {
                    text.text = size.ToString();
                }
                else text.text = " ";
            }
            else 
            { 
                use.enabled = false;
                remove.enabled = false;
                remove.image.enabled = false;

            }
        }

        if (slot.baseParent.GetComponent<whatSlot>().loadoutSlot == true)
        {
            var size = slot.baseParent.GetComponent<LoadOutSlot>().size;
            item = slot.baseParent.GetComponent<LoadOutSlot>().item;
            if (transform.parent.GetComponent<LoadOutSlot>().item != null)
            {
                use.enabled = true;
                remove.enabled = true;
                remove.image.enabled = true;

                if (size > 1)
                {
                    text.text = size.ToString();
                }
                else text.text = "";
            }
            else
            {
                use.enabled = false;
                remove.enabled = false;
                remove.image.enabled = false;

            }
        }

      
    }

    public void dropItem() 
    {
        if (slot.baseParent.GetComponent<whatSlot>().inventorySlot == true)
        {
            if(item.stackable == true) 
            {
                if(slot.baseParent.GetComponent<inventorySlot>().size > 1) 
                {
                    Instantiate(item.gameObject, player.transform.position, Quaternion.identity);
                    slot.baseParent.GetComponent<inventorySlot>().item.ammount -= 1;
                }
                else 
                {
                    Instantiate(item.gameObject, player.transform.position, Quaternion.identity);
                    slot.baseParent.GetComponent<inventorySlot>().clearSlot();
                    inventory.instance.remove(item);
                }

            }
            else 
            {
                Instantiate(item.gameObject, player.transform.position, Quaternion.identity);
                slot.baseParent.GetComponent<inventorySlot>().clearSlot();
                inventory.instance.remove(item);
            }
        }

        if(slot.baseParent.GetComponent<whatSlot>().loadoutSlot == true) 
        {
            if (item.stackable == true)
            {
                if (slot.baseParent.GetComponent<LoadOutSlot>().size > 1)
                {
                    Instantiate(item.gameObject, player.transform.position, Quaternion.identity);
                    slot.baseParent.GetComponent<LoadOutSlot>().item.ammount -= 1;
                }
                else
                {
                    Instantiate(item.gameObject, player.transform.position, Quaternion.identity);
                    slot.baseParent.GetComponent<LoadOutSlot>().clearSlot();
                    
                }

            }
            else
            {
                Instantiate(item.gameObject, player.transform.position, Quaternion.identity);
                slot.baseParent.GetComponent<LoadOutSlot>().clearSlot();
                
            }
        }
        
    }

    public void useItem() 
    {
        if (slot.baseParent.GetComponent<whatSlot>().inventorySlot == true)
        {
           if(slot.baseParent.GetComponent<inventorySlot>().item.weapon == true) 
            { 
            if(weaponSlot.hasItem == false) 
                {
                    weaponSlot.addItem(slot.baseParent.GetComponent<inventorySlot>().item);
                    inventory.instance.remove(slot.baseParent.GetComponent<inventorySlot>().item);
                    slot.baseParent.GetComponent<inventorySlot>().clearSlot();   
                    
                }
            else 
                {
                    var item1 = slot.baseParent.GetComponent<inventorySlot>().item;
                    var item2 = weaponSlot.item;

                    inventory.instance.remove(item1);
                    inventory.instance.items.Add(item2);

                    weaponSlot.clearSlot();
                    slot.baseParent.GetComponent<inventorySlot>().clearSlot();

                    weaponSlot.addItem(item1);
                    slot.baseParent.GetComponent<inventorySlot>().addItem(item2);
                }
            }

          else if(slot.baseParent.GetComponent<inventorySlot>().item.bow == true) 
            {

                if (bowSlot.hasItem == false)
                {
                    bowSlot.addItem(slot.baseParent.GetComponent<inventorySlot>().item);
                    inventory.instance.remove(slot.baseParent.GetComponent<inventorySlot>().item);
                    slot.baseParent.GetComponent<inventorySlot>().clearSlot();

                }
                else
                {
                    var item1 = slot.baseParent.GetComponent<inventorySlot>().item;
                    var item2 = weaponSlot.item;

                    inventory.instance.remove(item1);
                    inventory.instance.items.Add(item2);

                    bowSlot.clearSlot();
                    slot.baseParent.GetComponent<inventorySlot>().clearSlot();

                    bowSlot.addItem(item1);
                    slot.baseParent.GetComponent<inventorySlot>().addItem(item2);
                }
            }

          else if(slot.baseParent.GetComponent<inventorySlot>().item.headGear == true) 
            {
                if (neckSlot.hasItem == false)
                {
                    neckSlot.addItem(slot.baseParent.GetComponent<inventorySlot>().item);
                    inventory.instance.remove(slot.baseParent.GetComponent<inventorySlot>().item);
                    slot.baseParent.GetComponent<inventorySlot>().clearSlot();

                }
                else
                {
                    var item1 = slot.baseParent.GetComponent<inventorySlot>().item;
                    var item2 = neckSlot.item;

                    inventory.instance.remove(item1);
                    inventory.instance.items.Add(item2);

                    neckSlot.clearSlot();
                    slot.baseParent.GetComponent<inventorySlot>().clearSlot();

                    neckSlot.addItem(item1);
                    slot.baseParent.GetComponent<inventorySlot>().addItem(item2);
                }
            }

           else if (slot.baseParent.GetComponent<inventorySlot>().item.canLoadOut == true)
            {
                if (slot.baseParent.GetComponent<inventorySlot>().item.stackable)
                {
                    if (slot.baseParent.GetComponent<inventorySlot>().size > 1)
                    {
                        if (player.GetComponent<playerHunger>().currenthealt < player.GetComponent<playerHunger>().maxHealth)
                        {
                            player.GetComponent<playerHunger>().eat(5);
                            slot.baseParent.GetComponent<inventorySlot>().item.ammount -= 1;
                        }
                    }
                    else
                    {
                        if (player.GetComponent<playerHunger>().currenthealt < player.GetComponent<playerHunger>().maxHealth)
                        {
                            player.GetComponent<playerHunger>().eat(10);
                            slot.baseParent.GetComponent<inventorySlot>().clearSlot();
                            inventory.instance.remove(item);
                        }
                    }
                }
                else
                {
                    if (player.GetComponent<playerHunger>().currenthealt < player.GetComponent<playerHunger>().maxHealth)
                    { 
                    player.GetComponent<playerHunger>().eat(10);
                    slot.baseParent.GetComponent<inventorySlot>().clearSlot();
                    inventory.instance.remove(item);
                    }
            }
            }
            Debug.Log("use");
        }

        if (slot.baseParent.GetComponent<whatSlot>().loadoutSlot == true)
        {
            if (slot.baseParent.GetComponent<LoadOutSlot>().item.canLoadOut == true)
            {
                if (slot.baseParent.GetComponent<LoadOutSlot>().item.stackable)
                {
                    if (slot.baseParent.GetComponent<LoadOutSlot>().size > 1)
                    {
                        if (player.GetComponent<playerHunger>().currenthealt < player.GetComponent<playerHunger>().maxHealth)
                        {
                            player.GetComponent<playerHunger>().eat(5);
                            slot.baseParent.GetComponent<LoadOutSlot>().item.ammount -= 1;
                        }
                    }
                    else
                    {
                        if (player.GetComponent<playerHunger>().currenthealt < player.GetComponent<playerHunger>().maxHealth)
                        {
                            player.GetComponent<playerHunger>().eat(5);
                            slot.baseParent.GetComponent<LoadOutSlot>().clearSlot();
                            inventory.instance.remove(item);
                        }
                    }
                }
                else
                {
                    if (player.GetComponent<playerHunger>().currenthealt < player.GetComponent<playerHunger>().maxHealth)
                    {
                        player.GetComponent<playerHunger>().eat(10);
                        slot.baseParent.GetComponent<LoadOutSlot>().clearSlot();
                        inventory.instance.remove(item);
                    }
                }
            }

           else if(slot.baseParent.GetComponent<LoadOutSlot>().item.headGear == true ||
                slot.baseParent.GetComponent<LoadOutSlot>().item.bow == true||
                slot.baseParent.GetComponent<LoadOutSlot>().item.weapon == true) 
            {
                inventory.instance.add(slot.baseParent.GetComponent<LoadOutSlot>().item);
                slot.baseParent.GetComponent<LoadOutSlot>().clearSlot();


            }
            Debug.Log("use");
        }
    }
}
