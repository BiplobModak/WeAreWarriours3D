using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent),typeof(Soldier))]
public class CharecterMover : MonoBehaviour
{
    public delegate void MovementStatus();
    public MovementStatus moveing;
    public MovementStatus standing;
    

    [SerializeField]private NavMeshAgent self_agent;
    [SerializeField] private Soldier self_soldier;


    private void OnEnable()
    {
        self_agent = GetComponent<NavMeshAgent>();
        self_soldier = GetComponent<Soldier>();
        //speed

        self_soldier.TargetInRange += StopMoving;
        self_soldier.StartMoving += StartMoving; 
    }
    private void OnDisable()
    {

        //removing subscription of movement
        self_soldier.TargetInRange -= StopMoving;
        self_soldier.StartMoving -= StartMoving; 
    }
    /// <summary>
    /// Start movemtn when target is death
    /// </summary>
    /// <param name="s"></param>
    private void StartMoving(Soldier s) 
    {
        if (self_soldier.GetHealthStatus().Health <= 0)
            return;

        self_agent.Move(s.transform.position);
    }
    /// <summary>
    /// stop movement and start attaking 
    /// </summary>
    /// <param name="s"></param>
    private void StopMoving(Soldier s)
    {
        self_agent.Stop();
    }

    public void GOtoThePlayer(Vector3 poit) 
    {
        self_agent.Move(poit);
    }
   



    private void Reset()
    {
        
    }
}
