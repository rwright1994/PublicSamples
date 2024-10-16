using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[Serializable]
public class StatManager{

  
   
    public List<Stat> statList;
    

    public StatManager(){
  
        statList = new List<Stat>
        {
            new Stat("Strength", "All brawn, no brain!", 3, 0),
            new Stat("Constitution", "A Marthon awaits!", 3, 1),
            new Stat("Dexterity", "You thieving magpie!", 3, 2),
            new Stat("Charisma", "Pride before the fall.", 3, 3),
            new Stat("Intelligence", "Too many books, get some sun!", 3, 4),
            new Stat("Wisdom", "It's always good to learn from mistakes...", 3, 5),
        };

  

    }


    
    public void addStat(Stat newStat){
        this.statList.Add(newStat);
    }

    public Stat findStat(string statName){
        foreach(Stat stat in statList){
            if(stat.Name.Equals(statName)){
                return stat;
            }
        }
        return null;
    }


    // Player takes damage when hit.

    public void printAllStats(){
        
        foreach(Stat stat in statList){
            Debug.Log("Stat Name: " + stat.Name + " Stat Description: "+stat.getDescription());
        }
    }
   
}
