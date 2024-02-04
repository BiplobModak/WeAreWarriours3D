using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPool : MonoBehaviour
{
    private Dictionary<SolderType, Queue<ISoldier>> poolDictionary = new Dictionary<SolderType, Queue<ISoldier>>();
    private ISoldierFactory groundSoldierFactory, thorwerFactory, knightFactory;

    /// <summary>
    /// getting all soldier factory reference 
    /// </summary>
    private void Start()
    {
        //multiple soldier will be called here
        groundSoldierFactory = GetComponent<GroundSoliderFactory>();
        thorwerFactory = GetComponent<ThrowingSoldierFactory>();
        knightFactory = GetComponent<KnightFactory>();
    }
    //Need to change here ================================================================
    /// <summary>
    /// Generating the loop for soldiers, if it has the soldier it will return but if it don't have any it will create 
    /// </summary>
    /// <param name="soldierType">enum which can prefer as soldier type</param>
    /// <returns>Isolde interface</returns>
    /// <exception cref="System.NullReferenceException"></exception>
    public ISoldier GetSoldier(SolderType soldierType)
    {
        if (!poolDictionary.ContainsKey(soldierType))
        {
            poolDictionary[soldierType] = new Queue<ISoldier>();
            //Debug.Log("Pool Created"+ poolDictionary[soldierType].Count);
        }

        if (poolDictionary[soldierType].Count <= 0)
        {
            //Debug.Log($"Creating a new {soldierType} instance.");
            switch (soldierType)
            {
                case SolderType.Ground:
                    {
                        SoldierBaseClass groundSoldier = groundSoldierFactory.CreateSoldier(SolderType.Ground, poolDictionary[soldierType].Count);

                        Debug.Log(groundSoldier);
                        return groundSoldier;
                    }
                case SolderType.Thrower:
                    {
                        SoldierBaseClass thrwingsoldier = thorwerFactory.CreateSoldier(SolderType.Thrower, poolDictionary[soldierType].Count);
                        Debug.Log(thrwingsoldier);
                        return thrwingsoldier;
                    }
                case SolderType.Knight:
                    {
                        SoldierBaseClass knight = knightFactory.CreateSoldier(SolderType.Knight, poolDictionary[soldierType].Count);
                        Debug.Log(knight);
                        return knight;
                    }
                default:
                    {
                        Debug.Log("No in Factory Scope");
                        return null;
                    }
            }
        }
        else
        {
            //Debug.Log($"Reusing an existing {soldierType} instance.");
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
        Debug.Log(soldier);
        poolDictionary[soldier.Type].Enqueue(soldier);

        if (soldier is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.GetComponent<SphereCollider>().enabled = true;
            monoBehaviour.gameObject.SetActive(false);
            monoBehaviour.transform.position = transform.position;
        }
    }

}
