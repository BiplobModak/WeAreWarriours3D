using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

/// <summary>
/// Only for show projectile and visual
/// </summary>
public class StoneThrower : BaseWeapon
{
    /// <summary>
    /// Prefex From Editor
    /// </summary>
    [SerializeField, Required] GameObject throwObject;

    [SerializeField, Required] Transform trowpoint;
    [SerializeField] float trowDelay = 1f;
    [SerializeField] float trowPower = 1f;
    /// <summary>
    /// Stone pool
    /// </summary>
    [SerializeField] Queue<Transform> stones = new Queue<Transform>();

    

    /// <summary>
    /// Oposit soldier, it's Change based on ditection
    /// </summary>
    [SerializeField] Health currentTarget;
    public override void Attack(Health enemyHealth)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        ///hitting 
        currentTarget = enemyHealth;
        StartCoroutine(TrowStone());
    }
    /// <summary>
    /// delay for animation
    /// </summary>
    /// <returns></returns>
    IEnumerator TrowStone() 
    {
        yield return new WaitForSeconds(trowDelay);
        ThrowObject(GetObject());
        transform.GetChild(0).gameObject.SetActive(false);
    }

    /// <summary>
    /// Createing object and storing into a que
    /// </summary>
    private Transform GetObject()
    {
        if (stones.Count <= 0)
        {
            GameObject stone = Instantiate(throwObject, transform.position, transform.rotation, transform.GetChild(0));
            return stone.transform;
        }
        else 
        {
            return stones.Dequeue();
        }
    }
    /// <summary>
    /// only for show projectile
    /// </summary>
    private void ThrowObject(Transform stone) 
    {
        stone.DOJump(trowpoint.position, 1f, 1, .25f, false).SetEase(Ease.Linear).OnComplete(() => {
            currentTarget.GetDamage(DamagePower);
            ResetOnDeath(stone);
        });
    }

    /// <summary>
    /// Reseting after projectile
    /// </summary>
    /// <param name="gameObject"></param>
    private void ResetOnDeath(Transform stone)
    {
        stone.gameObject.SetActive(false);
        stone.parent = this.transform;
        stone.transform.localPosition = Vector3.zero;
        stones.Enqueue(stone);
        
    }
}
