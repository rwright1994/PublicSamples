using System;

/// <summary>
/// Abstract class used for inheritance purposes. Contains an object reference
/// to the general properties required for each item.
/// </summary>
[System.Serializable]
public abstract class ItemData {

    public ItemProperties ItemProperties{get;set;}
    

/// <summary>
/// Inializes the Item Data object with the specified ItemProperties object.
/// </summary>
/// <param name="ItemProperties">Top-level basic item information.(ex: _ID, Name, Desc...)</param>
    public ItemData( ItemProperties ItemProperties){
        this.ItemProperties = ItemProperties;
    }
}
