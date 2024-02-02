using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holding basic Information and basic component for Weapon
/// </summary>
public abstract class BaseWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] float range;
    [SerializeField] float damagePower;
    [SerializeField] float attackrate;
    public float Range { get { return range; } set { range = value; } }
    public float DamagePower { get { return damagePower; } set { damagePower = value; } }
    public float AttackRate { get { return attackrate; } set { attackrate = value; } }

    public abstract void Attack(Health healthStatus);

    #region Gizmos
    private void OnDrawGizmos()
    {
        // Set the color for Gizmo's
        Gizmos.color = Color.green;

        // Draw a sphere Gizmo's at the GameObject's position
        Gizmos.DrawWireSphere(transform.root.position, range); 

        transform.root.GetComponent<SphereCollider>().radius = range;
    }

    private void OnDrawGizmosSelected()
    {
        // Set a different color for Gizmo's when the GameObject is selected
        Gizmos.color = Color.black;

        // Draw a wire cube Gizmo's at the GameObject's position
        //Gizmos.DrawWireCube(transform.root.position, Vector3.one * range);
    }
    #endregion
}
