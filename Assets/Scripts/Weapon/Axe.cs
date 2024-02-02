using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : BaseWeapon
{
    public override void Attack(Health healthStatus)
    {
        StartCoroutine(GiveDamage(healthStatus));
    }
    IEnumerator GiveDamage(Health healthStatus)
    {
        yield return new WaitForSeconds(AttackRate);
        healthStatus.GetDamage(DamagePower);
    }
}
