

public interface IWeapon 
{
    /// <summary>
    /// Ariea of attack
    /// </summary>
    float Range { get; set; }

    /// <summary>
    /// diduction of life from enemy
    /// </summary>
    float DamagePower { get; set; }

    /// <summary>
    /// attack firquency
    /// </summary>
    float AttackRate { get; set; }
}
