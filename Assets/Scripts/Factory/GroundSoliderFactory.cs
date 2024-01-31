using UnityEngine;

/// <summary>
/// Gorund Factory
/// </summary>
public class GroundSoliderFactory : MonoBehaviour, ISoldierFactory
{
    [SerializeField] GameObject soldierPrefab;
    public ISoldier CreateSoldier(SolderType type, int id)
    {
        GameObject soldier = Instantiate(soldierPrefab, transform.position, transform.rotation);

        soldier.name = type.ToString() + "_" + id.ToString();

        ISoldier instance = soldier.GetComponent<ISoldier>();
        if (instance == null)
        {
            soldier.AddComponent<GroundSolder>();
        }
        return instance;
    }
}
