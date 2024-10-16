

/// <summary>
/// Parameter Object created that represents Weapon specific properties.
/// </summary>
public class WeaponProperties 
{
    public int LevelRequirement{get;set;}
    public double AttackSpeed{get;}
    public int MinDamage{get;set;}
    public int MaxDamage{get;set;}
    public int RequiredHands{get;}
    public WeaponType WeaponType{get;}


/// <summary>
/// Initalizes the weapon properties parameter object with the specified level requirement,
/// attack speed, minimum damage, maxmimum damage, required hands to equip and its type.
/// </summary>
/// <param name="LevelRequirement"> Item's level when dropped. </param>
/// <param name="AttackSpeed"> The Name of the item. </param>
/// <param name="MinDamage"> General in game descrption of the object </param>
/// <param name="MinDamage"> General in game descrption of the object </param>
/// <param name="MaxDamage"> General in game descrption of the object </param>
/// <param name="RequiredHands"> General in game descrption of the object </param>
/// <param name="WeaponType"> General in game descrption of the object </param>

    public WeaponProperties(int LevelRequirement, double AttackSpeed, int MinDamage, int MaxDamage, int RequiredHands, WeaponType WeaponType){
        this.LevelRequirement = LevelRequirement;
        this.AttackSpeed = AttackSpeed;
        this.MinDamage = MinDamage;
        this.MaxDamage = MaxDamage;
        this.RequiredHands = RequiredHands;
        this.WeaponType = WeaponType;
    }


}
