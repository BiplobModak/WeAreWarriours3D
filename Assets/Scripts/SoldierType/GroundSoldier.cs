using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// Base solder short attack Range and low type
/// this script respocibility is to detact and attack and control all components
/// </summary>
public class GroundSoldier : SoldierBaseClass
{
    [SerializeField] List<Health> currentEnemysInRange;
    [SerializeField] Health currentTarget;
    [SerializeField] SoldierMover mover;
    protected override void OnEnable()
    {
        //got the weaopn and self health
        base.OnEnable();
        mover = GetComponent<SoldierMover>();
        currentEnemysInRange = new List<Health>();
        healthStatus.death += SelfDeath;

    }
    public override void Attack()
    {
        if (!currentTarget.gameObject.activeInHierarchy) return;

        Debug.Log("Attacking");
        transform.DOLookAt(currentTarget.transform.position, .1f).OnComplete(() => { 
            weapon.Attack(currentTarget);
            mover.PlayeAttackAnimation();
        
        });
        
        if(gameObject.activeInHierarchy)
            StartCoroutine(AttackRipiter());

    }

    IEnumerator AttackRipiter()
    {
        yield return new WaitForSeconds(weapon.AttackRate);
        Attack();

    }

    public override void SelfDeath(Health h)
    {
        gameObject.SetActive(false);        
    }
    /// <summary>
    /// 
    /// </summary>
    public override void Detect()
    {
        if (currentEnemysInRange.Count > 0)
        {
            currentTarget = currentEnemysInRange[0];

            InvokeRepeating(nameof(CheckDistacne), .1f, .1f);
        }
        else 
        {
            mover.ResumeMovement();
        }
    }

    private void CheckDistacne() 
    {
        float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
        if (distance < weapon.Range) 
        {
            Debug.Log("Detacting");
            //stop cheaking distace
            CancelInvoke(nameof(CheckDistacne));
            //moveer stop movement
            mover.StopMovement();
            //weapon start attaking
            Attack();
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
            CurretnTargetDeth();
        }
    }

    private void CurretnTargetDeth() 
    {
        
        Debug.Log("Enemy is Death");
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
                Detect();
            }
        }
    }
}
