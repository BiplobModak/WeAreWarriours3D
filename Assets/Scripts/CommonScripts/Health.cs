using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generating Health System
/// 
/// </summary>
public class Health : MonoBehaviour, IHealth
{
    /// <summary>
    /// this delegate resposible for health statys
    /// </summary>
    /// <param name="health">current health</param>
    public delegate void HealthDamageFlag(float health);
    public HealthDamageFlag damageflag;

    public delegate void HealthStatus(Health selfHealth);    
    public HealthStatus death;

    /// <summary>
    /// only used in UI 
    /// </summary>
    [SerializeField]private float maxHealth;

    [SerializeField]private float health;

    /// <summary>
    /// getting maxHealth
    /// </summary>
    public float GetMaxHelath { get { return maxHealth; } }
    /// <summary>
    /// Self Health
    /// </summary>
    public float HealthValue { get => health; set { health = value; } }



    /// <summary>
    /// Getting damge From enemys
    /// </summary>
    /// <param name="damage"></param>
    public void GetDamage(float damage)
    {
        if (HealthValue > 0 && HealthValue > damage)
        {
            HealthValue -= damage;
            damageflag?.Invoke(HealthValue);
        }
        else 
        {
            HealthValue = 0;
            damageflag?.Invoke(HealthValue);
            death?.Invoke(this);
        }
    }

    /// <summary>
    /// Reseting all value 
    /// </summary>
    public void ResetALl()
    {
        HealthValue = maxHealth;
        // it will fill the health bar again
        damageflag.Invoke(HealthValue);
        
    }
}
