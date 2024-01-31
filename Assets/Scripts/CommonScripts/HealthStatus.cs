using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatus : MonoBehaviour
{
    /// <summary>
    /// this delegate resposible for health statys
    /// </summary>
    /// <param name="health">current health</param>
    public delegate void HealthStatusFlag(float health);
    public HealthStatusFlag damage;
    public HealthStatusFlag death;

    [SerializeField]private float health, maxHealth;

    /// <summary>
    /// getting maxHealth
    /// </summary>
    public float GetMaxHelath { get { return maxHealth; } }
    /// <summary>
    /// Self Health
    /// </summary>
    public float Health { get => health; protected set { health = value; } }

    

    /// <summary>
    /// Getting damge From enemys
    /// </summary>
    /// <param name="damage"></param>
    public void GetDamage(float damage)
    {
        if (health > 0 && health > damage)
        {
            health -= damage;
            this.damage.Invoke(health);
        }
        else 
        {
            health = 0;
            death.Invoke(health);
        }
    }

}
