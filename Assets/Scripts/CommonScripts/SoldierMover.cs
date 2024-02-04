using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// this script will control movement and animation
/// </summary>
[RequireComponent(typeof(NavMeshAgent), typeof(AnimationControler))]
public class SoldierMover : MonoBehaviour
{
    [SerializeField, Required] private NavMeshAgent navMeshAgent;
    [SerializeField, Required] private AnimationControler animControler;
    [SerializeField] Vector3 movepoint;
    

    private void OnEnable()
    { 
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    private void OnDisable()
    {
        
    }

    /// <summary>
    /// Moving towards target
    /// </summary>
    /// <param name="destination"></param>
    public void MoveTo(Vector3 destination)
    {
        // Move the player to the specified destination
        movepoint = destination;
        Debug.Log(navMeshAgent);
        animControler.Move();
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(destination);
    }

    /// <summary>
    /// Stop movement and Playing idle animation
    /// </summary>
    public void StopMovement()
    {
        // Stop the player's movement
        navMeshAgent.isStopped = true;
        animControler.Idel();
    }
    /// <summary>
    /// I know it's dumb
    /// just playing animation
    /// </summary>
    public void PlayeAttackAnimation() 
    {
        animControler.Attack();
    }

    /// <summary>
    /// Rersuming movement
    /// </summary>
    public void ResumeMovement()
    {
        if (!navMeshAgent.enabled) return;
        // Resume the player's movement
        if (!navMeshAgent.isOnNavMesh) return;
        

        navMeshAgent.isStopped = false;
        MoveTo(movepoint);
    }
}

