using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base solder short attack Range and low type
/// this script respocibility is to detact and attack and control all components
/// </summary>
public class GroundSoldier : SoldierBaseClass
{
    [SerializeField] List<Health> currentEnemysInRange;
    [SerializeField] Health currentTarget;
    protected override void OnEnable()
    {
        //got the weaopn and self health
        base.OnEnable();
        currentEnemysInRange = new List<Health>();

    }
    public override void Attack()
    {
        
    }

    public override void SelfDeath()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    public override void Detect()
    {
        if (currentEnemysInRange.Count > 0) 
        {
            currentTarget = currentEnemysInRange[0];
        }

    }

    /// <summary>
    /// Removing from the list after death
    /// </summary>
    /// <param name="deathEnemy"></param>
    private void RemoveFromList(Health deathEnemy) 
    {
        if (currentEnemysInRange.Contains(deathEnemy)) 
        {
            currentEnemysInRange.Remove(deathEnemy);
        }
    }

    private void CurretnTargetDeth(Health target) 
    {
        Detect();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        //nothing is doing in base class
        base.OnTriggerEnter(other);
        if (other.tag != transform.tag)
        {
            Health currentEnemy = other.GetComponent<Health>();
            if (currentEnemy != null)
            {
                currentEnemysInRange.Add(currentEnemy);

                currentEnemy.death += RemoveFromList;
            }
        }
    }
}
