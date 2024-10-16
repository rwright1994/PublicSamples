

/// <summary>
/// Parameter Object created that represents equipment specific properties.
/// </summary>
[System.Serializable]
public class EquipmentProperties 
{
 
    public EquipmentType Type {get;set;}
    public int LevelRequirement{get;set;}
    public int Durability{get;set;}
    public Rarity Rarity{get;set;}


/// <summary>
/// Initalizes the item properties parameter object with the specified item type,
/// level requirement, durability and rarity.
/// </summary>
/// <param name="Type">The given item type.</param>
/// <param name="LevelRequirement">Level requirement for the equipable item.</param>
/// <param name="Durability">The items durability before breaking.</param>
/// /// <param name="Rarity">Rarity level of the item.</param>

    public EquipmentProperties(EquipmentType Type, int LevelRequirement, int Durability, Rarity Rarity){
        this.Type = Type;
        this.LevelRequirement = LevelRequirement;
        this.Durability = Durability;
        this.Rarity = Rarity;
    }
}
