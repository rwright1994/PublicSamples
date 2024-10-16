using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponData : EquipmentData, IEquipable
{
 
    public WeaponProperties WeaponProperties;
  
    public Sprite Icon;
    


    public WeaponData(ItemProperties ItemProperties, EquipmentProperties EquipmentProperties, WeaponProperties WeaponProperties):base(ItemProperties, EquipmentProperties)
    {
        this.WeaponProperties = WeaponProperties;

    }

    public override string ToString(){
        return "Attack Speed:" + WeaponProperties.AttackSpeed + "\n" + "Damage:" + WeaponProperties.MinDamage + "-" + WeaponProperties.MaxDamage + "\n" + "Required Level:" + WeaponProperties.LevelRequirement + "\n" + WeaponProperties. WeaponType.ToString()  + "\n" + "Required Hands:" + WeaponProperties.RequiredHands + "\n" + Icon;
    }

    public void OnEquip(Player player){
      
    } 
}
