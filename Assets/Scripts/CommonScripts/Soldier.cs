using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoldierType 
{
    None, Player, Enemy
}

[RequireComponent(typeof(SphereCollider), typeof(HealthStatus))]
public class Soldier : MonoBehaviour, ISoldier
{
    [SerializeField] private float attactPower;
    [SerializeField] private float attackRange;
    [SerializeField] private IWeapon curretnWeapon;


    public delegate void TargetStatue(Soldier s);
    public TargetStatue TargetInRange;
    public TargetStatue StartMoving;

    private Soldier target = null;

    /// <summary>
    /// it's define which type of soldier player on enemy
    /// </summary>
    [SerializeField] SoldierType selfType = SoldierType.None;

    /// <summary>
    /// Returing self type
    /// </summary>
    public SoldierType GetType => selfType;

    /// <summary>
    /// Self attack power
    /// </summary>
    public float AttackPower { set { attactPower = value; } }
    /// <summary>
    /// Self attack Rancge depents Sphear colider collider
    /// </summary>
    public float AttackRange { set { attackRange = value; } }



    /// <summary>
    /// Player Helath system
    /// </summary>
    private HealthStatus healthStatus;
    /// <summary>
    /// Getter Health Status
    /// </summary>
    /// <returns>returing Helath status</returns>
    public HealthStatus GetHealthStatus() { return healthStatus; }

    /// <summary>
    /// Setting weapon
    /// </summary>
    /// <param name="weapon"></param>
    public virtual void SetWeapon(IWeapon weapon)
    {
        curretnWeapon = weapon;
    }


    protected virtual void OnEnable() 
    { 
        healthStatus = GetComponent<HealthStatus>();
    }

    protected virtual void GetDamage() 
    {
        healthStatus.GetDamage(attackRange);
    }





    /// <summary>
    /// Whean player is triggring
    /// </summary>
    /// <param name="other"></param>
    protected virtual void OnTriggerEnter(Collider other)
    {
        Soldier currentTarget = other.GetComponent<Soldier>();

        if (target == null && currentTarget?.GetType != selfType) 
        {
            target = other.GetComponent<Soldier>(); 
        }
        
    }
    protected virtual void OnTriggerExit(Collider other) 
    {

    }






}
