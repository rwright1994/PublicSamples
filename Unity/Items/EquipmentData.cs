using UnityEngine;

/// <summary>
/// Data class that contains equipment data.
/// </summary>
/// 
[System.Serializable]
public abstract class EquipmentData : ItemData 
{

    public EquipmentProperties EquipmentProperties;
    

    /// <summary>
    /// Abstract base Eqiupment data constructor that takes in inherited perameter from the
    /// inherited class ItemData.
    /// </summary>
    /// <param name="_ID"> Item's ID</param>
    /// <param name="ItemProperties">Item Properties object that contains important item specfic data.</param>
    /// <param name="LevelRequirement">All equipable item's have a level requirement.</param>
    /// <param name="EquipType">Equipment classification.</param>
    public EquipmentData(ItemProperties ItemProperties, EquipmentProperties EquipmentProperties):base(ItemProperties){
        this.EquipmentProperties = EquipmentProperties;
    }

    /// <summary>
    /// Overrides the ToString method of the ItemData class and prints out
    /// all the item & equipment information.
    /// </summary>
    /// <returns>A string with all the equipment properties.</returns>
    public override string ToString(){
        return this.ItemProperties.Name + this.ItemProperties.Description + this.EquipmentProperties.Type.ToString() + this.EquipmentProperties.LevelRequirement;
    }
    
    
}
