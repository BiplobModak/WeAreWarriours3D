using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoldierBaseType 
{
    Player,
    Enemy
}
public class SoldierRequester : MonoBehaviour
{
    [SerializeField] Queue<ISoldier> soldiers = new Queue<ISoldier>();
    
    [SerializeField, BoxGroup("Runtime")] SoldierPool pool;
    [SerializeField,BoxGroup("Runtime")] SpawnManager soldierBase;
    [SerializeField, BoxGroup("EditTime")] SoldierBaseType selfBaseType = SoldierBaseType.Player; 

    private void OnEnable()
    {
        
        
    }

    [Button]
    public void GetSoldier() 
    {
        ISoldier soldier = pool.GetSoldier(SolderType.Ground);
        
        ActivateSolder(soldier);
    }

    [Button]
    public void GetThrower()
    {
        ISoldier soldier = pool.GetSoldier(SolderType.Thrower);
        ActivateSolder(soldier);
    }

    [Button]
    public void GetKnight()
    {
        ISoldier soldier = pool.GetSoldier(SolderType.Knight);
        ActivateSolder(soldier);
    }

    [Button]
    public void ReleaseSoldier(Health health)
    {
        ISoldier soldier = health.GetComponent<ISoldier>();
        pool.ReleaseSoldier(soldier); ;
    }
    /// <summary>
    /// Activating and setting target for more
    /// </summary>
    /// <param name="soldier"></param>
    private void ActivateSolder(ISoldier soldier) 
    {
        if (soldier is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(true);
            ///setting tags
            
            monoBehaviour.tag = transform.tag;
            monoBehaviour.transform.position = transform.position;
            monoBehaviour.GetComponent<SoldierMover>().MoveTo(soldierBase.transform.position);
            // upper level relies
            monoBehaviour.GetComponent<Health>().death += ReleaseSoldier;
            soldiers.Enqueue(soldier);
        }
    }
}
