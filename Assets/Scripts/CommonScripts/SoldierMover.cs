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
        Debug.Log(navMeshAgent);
        navMeshAgent.SetDestination(destination);
        animControler.Move();
    }

    public void StopMovement()
    {
        // Stop the player's movement
        navMeshAgent.isStopped = true;
        animControler.Attack();
    }

    public void ResumeMovement()
    {
        // Resume the player's movement
        navMeshAgent.isStopped = false;
    }
}

