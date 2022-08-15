using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Item sword;
    public Item spear;
    public Item katana;
    public Item rock;
    public Item pumpkin;
    public Item coin;
    public Item diamond;
    public Item axe;
    public Item soup;
    public Item strNeck;
    public Item vitNeck;
    public Item lukNeck;
    public Item arcNeck;

    [SerializeField] private playerHunger healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6 && Input.GetKey(KeyCode.E))
        {

               bool wasPickedUp =  inventory.instance.add(pumpkin);

                if(wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 7 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(katana);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 8 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(sword);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 9 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(soup);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 10 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(axe);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 11 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(coin);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 12 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(diamond);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 13 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(rock);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 14 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(spear);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 15 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(strNeck);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 16 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(arcNeck);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 17 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(vitNeck);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 18 && Input.GetKey(KeyCode.E))
        {

            bool wasPickedUp = inventory.instance.add(lukNeck);

            if (wasPickedUp == true)
                Destroy(collision.gameObject);

        }
        if (collision.gameObject.layer == 19 && Input.GetKey(KeyCode.E))
        {
            if (healthBar.currenthealt < healthBar.maxHealth)
            {
                healthBar.eat(5);
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.layer == 20 && Input.GetKey(KeyCode.E))
        {
            if (healthBar.currenthealt < healthBar.maxHealth)
            {
                healthBar.eat(5);
                Destroy(collision.gameObject);
            }
        }
    }
}
