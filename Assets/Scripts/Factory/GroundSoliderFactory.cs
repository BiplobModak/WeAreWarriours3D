using UnityEngine;

/// <summary>
/// Gorund Factory
/// </summary>
public class GroundSoliderFactory : MonoBehaviour, ISoldierFactory
{
    [SerializeField] GameObject soldierPrefab;
    public SoldierBaseClass CreateSoldier(SolderType type, int id)
    {
        GameObject soldier = Instantiate(soldierPrefab, transform.position, transform.rotation);

        soldier.name = type.ToString() + "_" + id.ToString();

        SoldierBaseClass instance = soldier.GetComponent<SoldierBaseClass>();
        if (instance == null)
        {
            GroundSoldier groundSoldier = soldier.AddComponent<GroundSoldier>();
            groundSoldier.ID = id;
            groundSoldier.Type = type;
            return groundSoldier;
        }
        return instance;
    }
}
