using UnityEngine;

/// <summary>
/// Creating Knight solder her
/// </summary>
public class KnightFactory : MonoBehaviour, ISoldierFactory 
{
    [SerializeField] GameObject soldierPrefab;
    public SoldierBaseClass CreateSoldier(SolderType type, int id)
    {
        GameObject soldier = Instantiate(soldierPrefab, transform.position, transform.rotation);

        soldier.name = type.ToString() + "_" + id.ToString();

        SoldierBaseClass instance = soldier.GetComponent<SoldierBaseClass>();
        if (instance == null)
        {
            Knight knight =  soldier.AddComponent<Knight>();
            knight.Type = type;
            knight.ID = id;
            return knight;
        }
        return instance;
    }
}
