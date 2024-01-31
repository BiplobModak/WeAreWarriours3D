using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 3rd SOldider type with high life value
/// </summary>
public class Knight : MonoBehaviour, ISoldier
{
   
    [SerializeField] private short id;
    [SerializeField] HealthStatus healthStatus;
    [SerializeField] SolderType type;
    [SerializeField] float rangeRadious;
    public short ID { get => id; set { id = value; } }

    public HealthStatus Status { get => healthStatus; set => healthStatus = value; }
    public SolderType SolderType { get => type; set => type = value; }

    public void Attack()
    {
        // to do
        throw new System.NotImplementedException();
    }

    public void Ditect()
    {
        // todo
        throw new System.NotImplementedException();
    }
}
