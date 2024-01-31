
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
    
}
public enum SolderType 
{
    Ground, Thrower, Knight
}