using UnityEngine;

/// <summary>
/// Data class that contains Armour data.
/// </summary>
[System.Serializable]
public class ArmourData : EquipmentData
{
    public ArmourProperties ArmourProperties {get;}


/// <summary>
/// Initalizes armour information for in game armours.
/// </summary>
/// <param name="ItemProperties">The item properties, see item properties for details.</param>
/// <param name="EquipmentProperties">The item's equipment properties, see equipment properties for detils.</param>

    public ArmourData(ItemProperties ItemProperties, EquipmentProperties EquipmentProperties, ArmourProperties ArmourProperties) : base(ItemProperties, EquipmentProperties){
        this.ArmourProperties = ArmourProperties;
    }

}
