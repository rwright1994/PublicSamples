using UnityEngine;

[System.Serializable]
public class Class {
    
    public int _ID{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public string SpriteURL{get;set;}
    public Sprite Icon{get;set;}
    public int Level{get;set;}
    public int BaseHealth{get;set;}
    public int BaseStamina{get;set;}
    public int BaseMana{get;set;}
    public int BaseEnergy{get;set;}
    public int BaseSpirit{get;set;}
    
 
    public Class(int _ID, string Name, string Description,int BaseHealth, int BaseStamina, int BaseMana, int BaseEnergy, int BaseSpirit, string SpriteURL){
        this._ID = _ID;
        this.Name = Name;
        this.Description = Description;
        this.BaseHealth= BaseHealth;
        this.BaseStamina = BaseStamina;
        this.BaseMana = BaseMana;
        this.BaseEnergy = BaseEnergy;
        this.BaseSpirit = BaseSpirit;
        this.Level = 1;
        this.SpriteURL = SpriteURL;
        this.Icon = Resources.Load<Sprite>(SpriteURL);
    }

    

}
