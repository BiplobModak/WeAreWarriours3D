using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : BaseWeapon
{
    /// <summary>
    /// Main attacking hapning here
    /// plaing for extra feature but not now    //ToDO trhoable and Rebounce
    /// </summary>
    /// <param name="healthStatus"></param>
    public override void Attack(Health healthStatus)
    {
        if (healthStatus == null) return;
        if (!gameObject.activeInHierarchy) return;

        StartCoroutine(GiveDamage(healthStatus));
    }
    IEnumerator GiveDamage(Health healthStatus)
    {
        yield return new WaitForSeconds(AttackRate);
        healthStatus.GetDamage(DamagePower);
    }
}
