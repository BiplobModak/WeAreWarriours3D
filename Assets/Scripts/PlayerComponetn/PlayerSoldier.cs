using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoldier : Soldier
{
    [SerializeField] CharecterMover charecterMover;
    [SerializeField] Transform target_ransform;
    public override void SetWeapon(IWeapon weapon)
    {
        base.SetWeapon(weapon);
    }

    [ContextMenu("Hit")]
    protected override void GetDamage()
    {
        base.GetDamage();
    }

    [ContextMenu("Move")]
    public void MoveCharecter() 
    {
        charecterMover.GOtoThePlayer(target_ransform.position);
    }



    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
}
