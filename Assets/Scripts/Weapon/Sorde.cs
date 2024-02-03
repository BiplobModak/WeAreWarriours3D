using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A type of weapon High damage low radius
/// </summary>
public class Sorde : BaseWeapon
{
    /// <summary>
    /// Main attacking happening here
    /// </summary>
    /// <param name="healthStatus"></param>
    public override void Attack(Health healthStatus)
    {
        if (healthStatus == null) return;
        if(!gameObject.activeInHierarchy) return;

        StartCoroutine(GiveDamage(healthStatus));
    }
    IEnumerator GiveDamage(Health healthStatus)
    {
        yield return new WaitForSeconds(AttackRate);
        healthStatus.GetDamage(DamagePower);
    }
}
