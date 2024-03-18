using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int maxHealth = 5;


    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.PICKUP_HEALTH, this.OnPickupHealth);
    }
    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.PICKUP_HEALTH, this.OnPickupHealth);
    }
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
            Messenger.Broadcast(GameEvent.PLAYER_DEAD);
        }
        else
        {
            float healthPercentage = (float)health / maxHealth;
            Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercentage);
        }
    }
    public void OnPickupHealth(int healthAdded)
    {
        health += healthAdded;
        if(health > maxHealth) {
            health = maxHealth;
        }
        float healthPercent = ((float)health) / maxHealth;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercent);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
