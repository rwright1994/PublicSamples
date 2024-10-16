
/// <summary>
/// Parameter Object created that represents Armour specific properties.
/// </summary>
[System.Serializable]
public class ArmourProperties 
{


    public int Armour{get;set;}
    public ArmourType Type{get;}
    public double DurabilityDegradation{get;set;}

/// <summary>
/// Initalizes the item properties parameter object with the specified armour value,
/// type and durability degradation.
/// </summary>
/// <param name="Armour">Armours defensive value.</param>
/// <param name="Type">Armours type.</param>
/// <param name="DurabilityDegradation">How fast the items durability degrades.</param>
    public ArmourProperties(int Armour, ArmourType Type, double DurabilityDegradation){
        this.Armour = Armour;
        this.Type = Type;
        this.DurabilityDegradation = DurabilityDegradation;
    }


}
