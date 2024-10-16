using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{
 
    public string Name {get;set;}
    public string Description {get;set;}
    public int ItemLevel{get;set;}
    public int LevelRequirement {get;set;}
    public List<Stat> StatRequirements{get;set;}


    public void Start(){

    }

    public void Update(){
        
    }
}
