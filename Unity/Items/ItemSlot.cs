
using UnityEngine;
using UnityEngine.UI;

// <summary>
// Item Slot object that takes in a generic type where the type has to
// be of ItemData allowing them to be set at instantiation.
// <summary
[System.Serializable]
public class ItemSlot<T> where T : ItemData {
    public T _item;
    public Sprite Icon;

    // Intialize the item slot to be empty.
    public ItemSlot (){
        _item = null;
    }

    public T Item
    {
        get{return _item;}
        set{_item = value;}
    }

    // Check to see if the item slot is already occupied.
    public bool IsEmpty(){
        return _item == null;
    }
}
