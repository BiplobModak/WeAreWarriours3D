using TreeEditor;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// this script will control movement and animation
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class SoldierMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    [SerializeField] private Animator animator;
    [SerializeField] AnimationClip attackClip, idelclip, walkClip;

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
    }

    public void StopMovement()
    {
        // Stop the player's movement
        navMeshAgent.isStopped = true;
    }

    public void ResumeMovement()
    {
        // Resume the player's movement
        navMeshAgent.isStopped = false;
    }
}

