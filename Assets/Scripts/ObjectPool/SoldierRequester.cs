using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRequester : MonoBehaviour
{
    [SerializeField] Queue<ISoldier> soldiers = new Queue<ISoldier>();
    
    [SerializeField, BoxGroup("Runtime")] SoldierPool pool;
    [SerializeField,BoxGroup("Runtime")] PlayerSpawnManager playerBase;


    private void OnEnable()
    {
        playerBase = GameManager.Instance.GetPlayerBase;
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
    public void ReleaseSoldier()
    {
        ISoldier soldier = soldiers.Dequeue();
        pool.ReleaseSoldier(soldier);
    }

    private void ActivateSolder(ISoldier soldier) 
    {
        if (soldier is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(true);
            monoBehaviour.transform.position = transform.position;
            monoBehaviour.GetComponent<SoldierMover>().MoveTo(playerBase.transform.position);
            soldiers.Enqueue(soldier);
        }
    }
}
