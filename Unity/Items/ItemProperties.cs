using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Parameter Object created that represents item specific properties.
/// </summary>
[System.Serializable]
public class ItemProperties {

    public int _ID{get;set;}

    public int ItemLevel{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public string SpriteURL{get;set;}
    public Sprite Sprite{get;set;}

    
    
/// <summary>
/// Initalizes the item properties parameter object with the specified item level,
/// name and description.
/// </summary>
/// <param name="_ID"> ID of the specified item.</param>
/// <param name="ItemLevel"> Item's level when dropped.</param>
/// <param name="Name"> The Name of the item.</param>
/// <param name="Description"> General in game descrption of the object.</param>
    public ItemProperties(int _ID, int ItemLevel, string Name, string Description, string SpriteURL){
        this._ID=_ID;
        this.ItemLevel = ItemLevel;
        this.Name = Name;  
        this.Description = Description;
        this.SpriteURL = SpriteURL;
    }


}
