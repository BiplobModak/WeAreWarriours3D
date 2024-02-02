using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/// <summary>
/// this class only for holding base behaviours and functionalaties
/// </summary>
public abstract class SoldierBaseClass : MonoBehaviour, ISoldier
{
    /// <summary>
    /// id only for debug
    /// </summary>
    [BoxGroup("Runtime")]
    [SerializeField, BoxGroup("Runtime")] protected int id;
    [SerializeField,BoxGroup("Runtime")] protected Health healthStatus;
    [SerializeField, BoxGroup("Runtime")] protected SolderType type;
    [SerializeField, BoxGroup("Runtime")] protected float rangeRadious;
    [SerializeField, BoxGroup("Runtime")] protected BaseWeapon weapon;
    [SerializeField, BoxGroup("Runtime")] protected SphereCollider attackRangeCollider;
    public int ID { get => id; set { id = value; } }

    public Health Status { get => healthStatus; set => healthStatus = value; }
    public SolderType Type { get => type; set => type = value; }

    /// <summary>
    /// Attack Functionalites
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// Detecting Functionaties
    /// </summary>
    public abstract void Detect();

    /// <summary>
    /// on death 
    /// </summary>
    public abstract void SelfDeath();

    /// <summary>
    /// getting usefull informations on enabled
    /// </summary>
    protected virtual void OnEnable()
    {
        healthStatus = GetComponent<Health>();
        weapon = GetComponentInChildren<BaseWeapon>();
        attackRangeCollider = GetComponentInChildren<SphereCollider>();
        if (attackRangeCollider != null) 
        {
            attackRangeCollider.radius = weapon.Range;
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }
}
