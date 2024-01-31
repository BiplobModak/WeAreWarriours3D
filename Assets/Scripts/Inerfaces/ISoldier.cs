
/// <summary>
/// Solder base interface 
/// </summary>
public interface ISoldier
{
    
    //identity
    short ID { get; set; }
    /// <summary>
    /// Atached Health Status
    /// </summary>
    HealthStatus Status { get; set; }
    /// <summary>
    /// Solder type
    /// </summary>
    SolderType SolderType { get; set; }

    /// <summary>
    /// Attack enemys 
    /// </summary>
    void Attack();
    /// <summary>
    /// Move and trigger attack
    /// </summary>
    void Ditect();
    
}
/// <summary>
/// it contains meatcount and soldier type
/// </summary>
public enum SolderType 
{
    Ground =3, 
    Thrower = 5, 
    Knight=8
}