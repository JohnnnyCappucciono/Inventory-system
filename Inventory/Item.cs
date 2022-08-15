
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "inventory/item")]
public class Item : ScriptableObject
{
   new public string name = "new name";
    public string description = "a item";
    public Sprite icon = null;
    public bool weapon = false;
    public bool bow = false;
    public bool headGear = false;
    public bool canLoadOut = false;
    public bool stackable = false;
    public GameObject gameObject;

    public int str = 0;
    public int arc = 0;
    public int luck = 0;
    public int vit = 0;
    public int ammount = 1;

}
