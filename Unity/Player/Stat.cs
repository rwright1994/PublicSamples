using System;
using System.Collections.Generic;

///<summary>
/// Class that contains stat details.
///</summary>

[Serializable]
public class Stat{

   
    public string Name{get;set;}

    public int Value;

    private string description;
    private int type;
    private List<StatModifier> modifiers;
   
    /// <summary>
    /// Constructor that creates a new <b>Stat</b> to be applied to a character.
    /// (Ex: Strength, Constitution...,etc.);
    /// </summary>
    /// <param name="Name"> Item's ID</param>
    /// <param name="description">Breif description or anticdote for the given stat.</param>
    /// <param name="Value">The value.</param>
    /// <param name="modifier">Contains a list of all currently applied stat modifiers for the given Stat.</param>
    public Stat(string Name, string description, int Value, int type){
        this.Name = Name;
        this.Value = Value;
        this.description = description;
        this.type = type;
        modifiers = new List<StatModifier>();
    }
    
///<summary>
/// Accessor method to return stats description.
///</summary>
///<returns>Returns the stats description or anticdote.</returns>

    public string getDescription(){
        return this.description;
    }
    ///<summary>
/// Mutator method to set stats description.
///</summary>
///<returns>Returns the stats description or anticdote.</returns>
    public void setDescription(string descript){
        this.description = descript;
    }

///<summary>
///Accessor method to return stats type.
///</summary>
///<returns>Returns the stat's type as a int.</returns>
    public int getType(){
        return this.type;
    }

///<summary>
///Mutator method to set stat type. (May get removed)
///</summary>
///<returns>Returns the stats description or anticdote.</returns>
    public void setType(int newType){
        this.type = newType;
    }

///<summary>
/// Calculates the stat's value based on all currently applied StatModifiers.
///</summary>
///<returns></returns>
    public float GetValue(){
        
        float calcedValue = Value;
        float additveModifer = 0f;
        float multiplicativeModifer = 1f;

// Loop through each mod.
        foreach( StatModifier mod in modifiers)
        {
              // If there are mods to calculate
            if(mod != null)
            {
                
                switch(mod.ModifierType)
                {
                    //If additive stat add to value.
                    case ModifierType.Additive:
                    additveModifer = mod.Value;
                    break;
                    //If multiplicative add to temp value.
                    case ModifierType.Multiplicative:
                    multiplicativeModifer = mod.Value;
                    break;
                }
            }
        }
        // Calculate the additve, then multiplicative modifiers.
        calcedValue += additveModifer;
        calcedValue *= multiplicativeModifer;

        return (float) calcedValue;
    }

///<summary>
/// Adds a stat modifier for the given stat.
///<summary>
    public void AddStatModifier(StatModifier newModifiers){
        this.modifiers.Add(newModifiers);        
    }
 

}


