
/// <summary>
/// Solder base interface 
/// </summary>
public interface ISoldier
{
    
    //identity
    int ID { get; set; }
    /// <summary>
    /// Atached Health Status
    /// </summary>
    Health Status { get; set; }
    /// <summary>
    /// Solder type
    /// </summary>
    SolderType Type { get; set; }   
    
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