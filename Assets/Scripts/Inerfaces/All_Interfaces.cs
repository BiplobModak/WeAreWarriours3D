
/// <summary>
/// Can only apply in weapon
/// </summary>
public interface IWeapon 
{
    float DamagePower { get; }
}
/// <summary>
/// Can apply on everyting
/// soldier, hunt, player
/// </summary>
public interface IHealth
{
    public float Healths { get; protected set; }
    public void GetDamage(float damage);
}

/// <summary>
/// Basic soldier point
/// </summary>
public interface ISoldier
{
    float AttackPower { set; }
    float AttackRange { set; }
    public void SetWeapon(IWeapon weapon);    

}