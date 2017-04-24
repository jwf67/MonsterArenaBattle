using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class HealthScript : NetworkBehaviour
{
    //will be monster health
    public const int maxHealth = 50;

    [SyncVar]
    public int currentHealth = maxHealth;
    public RectTransform healthBar;

    public void TakeDamage(int amount)
    {
        //if it's not the server then dont do anything
        if (!isServer)
        {
            return;
        }

        //decrease health
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        //change health bar
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
}