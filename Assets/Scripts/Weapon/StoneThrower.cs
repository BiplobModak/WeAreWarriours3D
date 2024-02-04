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

    //[SerializeField, Required] Transform trowpoint;
    /// <summary>
    /// Stone pool
    /// </summary>
    [SerializeField] Queue<Transform> stones = new Queue<Transform>();

    

    /// <summary>
    /// other soldier, it's Change based on detection
    /// </summary>
    [SerializeField] Health currentTarget;
    public override void Attack(Health enemyHealth)
    {
        //transform.GetChild(0).gameObject.SetActive(true);
        ///hitting 
        currentTarget = enemyHealth;
        ThrowObject();
        //StartCoroutine(TrowStone());
    }
    /// <summary>
    /// delay for animation
    /// </summary>
    /// <returns></returns>
    IEnumerator TrowStone() 
    {
        yield return new WaitForSeconds(AttackRate);
        
        //transform.GetChild(0).gameObject.SetActive(false);
    }

    /// <summary>
    /// Creating object and storing into a queue
    /// </summary>
    //private Transform GetObject()
    //{
    //    //GameObject stone = Instantiate(throwObject, transform.position, transform.rotation, transform.GetChild(0));
    //    //stone.transform.DOMove(currentTarget.transform.position, 1f, false).OnComplete(() => {
    //    //    currentTarget.GetDamage(DamagePower);
    //    //    Destroy(stone, .1f);
    //    //});
    //    //return stone.transform;
    //}
    /// <summary>
    /// only for show projectile
    /// </summary>
    private void ThrowObject() 
    {
        if (!currentTarget.gameObject.activeInHierarchy) {
            currentTarget = null;
            return;
        }
        GameObject stone = Instantiate(throwObject, transform.position, transform.rotation, transform.GetChild(0));
        currentTarget.GetDamage(DamagePower);
        Vector3 point = currentTarget.transform.position;
        stone.transform.DOMove(point, .5f, false).OnComplete(() => {
            Destroy(stone, .1f);
        });

        //stone.DOJump(trowpoint.position, 1f, 1, .25f, false).SetEase(Ease.Linear).OnComplete(() => {
        //});
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
