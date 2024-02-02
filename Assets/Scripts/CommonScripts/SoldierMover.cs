using Sirenix.OdinInspector;
using TreeEditor;
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


    public void MoveTo(Vector3 destination)
    {
        // Move the player to the specified destination
        movepoint = destination;
        Debug.Log(navMeshAgent);
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(destination);
        animControler.Move();
    }

    public void StopMovement()
    {
        // Stop the player's movement
        navMeshAgent.isStopped = true;
        animControler.Idel();
    }

    public void PlayeAttackAnimation() 
    {
        animControler.Attack();
    }


    public void ResumeMovement()
    {
        if (!navMeshAgent.enabled) return;
        // Resume the player's movement
        navMeshAgent.isStopped = false;
        MoveTo(movepoint);
    }
}

