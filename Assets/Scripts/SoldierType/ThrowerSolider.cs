using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Long Range SOlider with low life
/// May Use in projectile in future
/// </summary>
public class ThrowerSolider : SoldierBaseClass
{
    /// <summary>
    /// All refinance enemy that's are closed
    /// </summary>
    [SerializeField, BoxGroup("Runtime"), ReadOnly] List<Health> currentEnemysInRange;
    /// <summary>
    /// Target enemy health
    /// </summary>
    [SerializeField, BoxGroup("Runtime"), ReadOnly] Health currentTarget, tempTarget;
    /// <summary>
    /// Soldier mover
    /// </summary>
    [SerializeField, BoxGroup("Runtime"), ReadOnly] SoldierMover mover;

    /// <summary>
    /// Getting components and 
    /// </summary>
    protected override void OnEnable()
    {
        //got the weapon and self health
        base.OnEnable();
        mover = GetComponent<SoldierMover>();
        currentEnemysInRange = new List<Health>();
        healthStatus.death += SelfDeath;

    }
    /// <summary>
    /// Attacking the enemy and playing animation
    /// </summary>
    public override void Attack()
    {
        if ( currentTarget == null ||!currentTarget.gameObject.activeInHierarchy) return;

        Debug.Log("Attacking");
        //transform.DOLookAt(currentTarget.transform.position, .1f).OnComplete(() => {

        //});
            weapon.Attack(currentTarget);
            mover.PlayeAttackAnimation();
        // stopping coroutine if object is disable
        if (gameObject.activeInHierarchy)
            StartCoroutine(AttackRipiter());

    }

    /// <summary>
    /// Using for delay and loop
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackRipiter()
    {
        yield return new WaitForSeconds(weapon.AttackRate);
        Attack();

    }

    /// <summary>
    /// Whend self death
    /// It may Not need soldiers will collected by Object pool
    /// </summary>
    /// <param name="h"></param>
    public override void SelfDeath(Health h)
    {
        gameObject.SetActive(false);
    }
    /// <summary>
    /// detecting enemys based on record
    /// </summary>
    public override void Detect()
    {
        if (currentTarget != null) return;
        if (currentEnemysInRange.Count > 0)
        {
            tempTarget = currentEnemysInRange[0];
            currentEnemysInRange.RemoveAt(0);
            InvokeRepeating(nameof(CheckDistacne), Time.fixedDeltaTime, Time.fixedDeltaTime);
        }
        else
        {
            //continueing movement again
            mover.ResumeMovement();
        }
    }

    /// <summary>
    /// Checkeing distance by InvokRepeting
    /// </summary>
    private void CheckDistacne()
    {
        float distance = Vector3.Distance(transform.position, tempTarget.transform.position);
        if (distance < weapon.Range+5f)
        {
            Debug.Log("Detacting");
            currentTarget = tempTarget;
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
        CurretnTargetDeth();
        if (currentEnemysInRange.Contains(deathEnemy))
        {
            currentEnemysInRange.Remove(deathEnemy);            
        }
    }

    /// <summary>
    /// Calling wehnd enemy curretn enemy is death
    /// </summary>
    private void CurretnTargetDeth()
    {
        currentTarget = null;
        tempTarget = null;
        Debug.Log("Enemy is Death");
        Detect();
    }



    /// <summary>
    /// Decting colution based on trigger inter
    /// </summary>
    /// <param name="other"></param>
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
