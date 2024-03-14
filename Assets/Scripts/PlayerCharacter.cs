using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int maxHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void Hit()
    {
        
        health -= 1;
        Debug.Log("Health: " + health);
        if(health == 0)
        {
            Debug.Break();
        }
        else
        {
            float healthPercentage = (float)health / maxHealth;
            Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercentage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
