using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holding basic Inaformation and basic component for Weapon
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
        // Set the color for Gizmos
        Gizmos.color = Color.green;

        // Draw a sphere Gizmo at the GameObject's position
        Gizmos.DrawWireSphere(transform.root.position, range);        
    }

    private void OnDrawGizmosSelected()
    {
        // Set a different color for Gizmos when the GameObject is selected
        Gizmos.color = Color.black;

        // Draw a wire cube Gizmo at the GameObject's position
        //Gizmos.DrawWireCube(transform.root.position, Vector3.one * range);
    }
    #endregion
}
