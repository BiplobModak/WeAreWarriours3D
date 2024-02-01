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
    [SerializeField,BoxGroup("Runtime")] protected HealthStatus healthStatus;
    [SerializeField, BoxGroup("Runtime")] protected SolderType type;
    [SerializeField, BoxGroup("Runtime")] protected float rangeRadious;
    public int ID { get => id; set { id = value; } }

    public HealthStatus Status { get => healthStatus; set => healthStatus = value; }
    public SolderType Type { get => type; set => type = value; }

    /// <summary>
    /// Attack Functionalites
    /// </summary>
    public abstract void Attack();
    
    /// <summary>
    /// ditected Functionaties
    /// </summary>
    public abstract void Ditect();

    /// <summary>
    /// on death 
    /// </summary>
    public abstract void Death();

    private void OnEnable()
    {
        healthStatus = GetComponent<HealthStatus>();
    }

}
