
// **--------------------------------Imports-----------------------------------------------------** //

using UnityEngine;


/// <summary> 
/// General equipment manager used to track an entites equipment, mostly individual players.
/// </summary>
public class EquipmentManager {



// **--------------------------------Variables----------------------------------------------------** //
    public ItemSlot<ArmourData>[] ArmourSlots = new ItemSlot<ArmourData>[8];
    public ItemSlot<WeaponData>[] WeaponSlots = new ItemSlot<WeaponData>[2];
    public ItemSlot<AmuletData> AmuletSlot;
    public ItemSlot<RingData>[] RingSlots = new ItemSlot<RingData>[2];
 
/// <summary>
/// Default constructor that inializes a new equipment manager to be attached to a player
/// </summary>
    public EquipmentManager()
    {
        AmuletSlot = new ItemSlot<AmuletData>();
        initalizeArmourSlots();
        initalizeWeaponSlots();
        inializeRingSlots();
        
    }

// **--------------------------------Public Functions------------------------------------------------** //


// **--------------------------------Private Functions-----------------------------------------------** //
/// <summary>
/// Initalizes Armour slots for useage.
/// </summary>
 
    private void initalizeArmourSlots(){
       int i = 0;
       foreach(ItemSlot<ArmourData> slot in ArmourSlots){
            ArmourSlots[i] = new ItemSlot<ArmourData>();
            i++;
       }
    }

    
/// <summary>
/// Initalizes Armour slots for useage.
/// </summary>

    private void initalizeWeaponSlots(){
        int i = 0;
        foreach(ItemSlot<WeaponData> slot in WeaponSlots){
            WeaponSlots[i] = new ItemSlot<WeaponData>();
            i++;
       }
    }



/// <summary>
/// Initalizes Armour slots for useage.
/// </summary>
    private void inializeRingSlots(){
        int i = 0;
        foreach(ItemSlot<RingData> slot in RingSlots){
            RingSlots[i] = new ItemSlot<RingData>();
            i++;
       }
    }

}
