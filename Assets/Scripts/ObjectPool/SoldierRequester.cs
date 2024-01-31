using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRequester : MonoBehaviour
{
    [SerializeField] SoldierPool pool;
    [SerializeField] int requestCount = 0;
    List<ISoldier> requestsSolder;
    private void OnEnable()
    {
        requestsSolder = new List<ISoldier>();
    }

    [ContextMenu("Create Ground")]
    public void GetSoldier() 
    {
        ISoldier solider = pool.GetSoldier(SolderType.Ground);
        requestsSolder.Add(solider);
        //pool.ReleaseSoldier(solider);

    }
    [ContextMenu("Create Thrower")]
    public void GetThrower()
    {
        ISoldier solider = pool.GetSoldier(SolderType.Thrower);
        //pool.ReleaseSoldier(solider);
        requestsSolder.Add(solider);

    }
    [ContextMenu("Create Kning")]
    public void GetKnight()
    {
        ISoldier solider = pool.GetSoldier(SolderType.Knight);
        //pool.ReleaseSoldier(solider);
        requestsSolder.Add(solider);

    }
    [ContextMenu("Realise Soldier")]
    public void ReleaseSoldier()
    {
        if (requestCount >= requestsSolder.Count)
            return;

        pool.ReleaseSoldier(requestsSolder[requestCount]);
        requestCount++;
    }
}
