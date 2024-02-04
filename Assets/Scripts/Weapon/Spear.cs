using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : BaseWeapon
{
    //it could be throwable TODO
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
