
using UnityEngine;

public class inventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform itemsParent;
    public GameObject invetoryUI;
   public inventorySlot[] slots;
    inventory Inventory;
    public void updateUI() 
    {
        Debug.Log("update ui");

        for (int i = 0; i < slots.Length; i++)
        {
            if(i < Inventory.items.Count) 
            {
                slots[i].addItem(Inventory.items[i]);
                Debug.Log(slots[i]);
            }
            else 
            {
                slots[i].clearSlot();
            }
        }
    }
}
