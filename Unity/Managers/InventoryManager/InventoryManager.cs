using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
   
   public List<ItemSlot<ItemData>> InventorySlots{get;set;}
   public int maxCapacity = 10;
   
//    _ID, Name, Description, EquipmentType, WeaponType, AttackSpeed, MinDamage, MaxDamage, LevelRequirement,  RequiredHands - WeaponData   
   public InventoryManager()
   {
      InventorySlots = new List<ItemSlot<ItemData>>();
      
      for(int i = 0; i < maxCapacity; i++){
         InventorySlots.Add(new ItemSlot<ItemData>());
      }
}

    public void AddItem(ItemData item){
      foreach(ItemSlot<ItemData> slot in InventorySlots){
         if(slot.IsEmpty()){
            slot._item = item;
            slot.Icon = item.ItemProperties.Sprite;
            break;
         }else{
            Debug.Log("Inventory is full");
         }
      }
      
    }
}
