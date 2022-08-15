using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField] private GameObject stats;
    public TextMeshProUGUI str;
    public TextMeshProUGUI vit;
    public TextMeshProUGUI luck;
    public TextMeshProUGUI arc;

    public Transform itemsParent;
    public LoadOutSlot[] slots;

    int strNum = 0;
    int vitNum = 0;
    int luckNum = 0;
    int arcNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        stats.SetActive(false);
        slots = itemsParent.GetComponentsInChildren<LoadOutSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stats.SetActive(!stats.activeInHierarchy);
        }

        str.text = "STRENGHT = " + strNum;
        vit.text = "VITALITY = " + vitNum;
        luck.text = "LUCK = " + luckNum;
        arc.text = "ARCHERY = " + arcNum;


    }

    public void updateStats(Item item) 
    {
        strNum += item.str;
        vitNum += item.vit;
        luckNum += item.luck;
        arcNum += item.arc;
    }

    public void removeStats(Item item) 
    {
        strNum -= item.str;
        vitNum -= item.vit;
        luckNum -= item.luck;
        arcNum -= item.arc;
    }
}
