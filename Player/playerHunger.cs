using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHunger : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;

    public int maxHealth = 100;
    public int currenthealt = 0;

    float hunger = 5;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);
        currenthealt = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hunger -= Time.deltaTime;

        if(hunger < 0) 
        {
            takeHunger(5);
            hunger = 6;
            
        }
    }

    public void takeHunger(int hunger) 
    {
        currenthealt -= hunger;
        healthBar.SetHealth(currenthealt);
    
    }

    public void eat(int food) 
    {
        currenthealt += food;
        healthBar.SetHealth(currenthealt);
    }
}
