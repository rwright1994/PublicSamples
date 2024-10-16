
public class RingData: EquipmentData
{
   
   public RingProperties RingProperties{get;set;}

    public RingData(ItemProperties ItemProperties, EquipmentProperties EquipmentProperties, RingProperties RingProperties):base(ItemProperties,EquipmentProperties){

    }
}
