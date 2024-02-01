using UnityEngine;

/// <summary>
/// Generating trwing Soldier
/// </summary>
public class ThrowingSoldierFactory : MonoBehaviour,ISoldierFactory
{
    [SerializeField] GameObject soldierPrefab;
    public SoldierBaseClass CreateSoldier(SolderType type, int id)
    {
        GameObject soldier = Instantiate(soldierPrefab, transform.position, transform.rotation);

        soldier.name = type.ToString() + "_" + id.ToString();

        SoldierBaseClass instance = soldier.GetComponent<SoldierBaseClass>();
        if (instance == null)
        {
            ThrowerSolider soldier_t = soldier.AddComponent<ThrowerSolider>();
            soldier_t.Type = type;
            soldier_t.ID = id;
            return soldier_t;
        }
        return instance;
    }
}
