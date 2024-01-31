using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPool : MonoBehaviour
{
    private Dictionary<SolderType, Queue<ISoldier>> poolDictionary = new Dictionary<SolderType, Queue<ISoldier>>();
    private ISoldierFactory groundSoldierFactory, thorwerFactory, knightFactory;

    /// <summary>
    /// getting all soldier factory referacne 
    /// </summary>
    private void Start()
    {
        //multiple soldier will be called here
        groundSoldierFactory = GetComponent<GroundSoliderFactory>();
        thorwerFactory = GetComponent<ThrowingSoldierFactory>();
        knightFactory = GetComponent<KnightFactory>();
    }

    /// <summary>
    /// Generating the loop for soldies, if it has the soldier it will return but if it don't have any it will create 
    /// </summary>
    /// <param name="soldierType">enum which can prefer as soldier type</param>
    /// <returns>Isolder interface</returns>
    /// <exception cref="System.NullReferenceException"></exception>
    public ISoldier GetSoldier(SolderType soldierType)
    {
        if (!poolDictionary.ContainsKey(soldierType))
        {
            poolDictionary[soldierType] = new Queue<ISoldier>();
        }

        if (poolDictionary[soldierType].Count == 0)
        {
            Debug.Log($"Creating a new {soldierType} instance.");
            switch (soldierType)
            {
                case SolderType.Ground:
                    { 
                        ISoldier groundSoldier = groundSoldierFactory.CreateSoldier(SolderType.Ground, poolDictionary[soldierType].Count);
                        return groundSoldier;
                    }
                case SolderType.Thrower:
                {
                    ISoldier thrwingsoldier = thorwerFactory.CreateSoldier(SolderType.Thrower, poolDictionary[soldierType].Count);
                    return thrwingsoldier;
                }
                case SolderType.Knight:
                    { 
                        ISoldier soldier = knightFactory.CreateSoldier(SolderType.Knight, poolDictionary[soldierType].Count);
                        return soldier;
                    }
                default:
                    {
#if UNITY_EDITOR
                        Debug.Log("No in Factory Scope");
                        throw new System.NullReferenceException();
#endif
                    }
            }
            
        }
        else
        {
            Debug.Log($"Reusing an existing {soldierType} instance.");
            ISoldier soldier = poolDictionary[soldierType].Dequeue();
            return soldier;
        }
    }

    

    /// <summary>
    /// activating the soldier form the pool
    /// </summary>
    /// <param name="soldier"></param>
    public void ReleaseSoldier(ISoldier soldier)
    {
        if (soldier is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
        }
        
        poolDictionary[soldier.SolderType].Enqueue(soldier);
    }

}
