using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ClassManager{

    [SerializeField]
    public Class Class;

    public ClassManager(){
        this.Class = null;
    }

    public Class getCurrentClass(){
        return this.Class;
    }

    public void setClass(Class newClass){
        this.Class = newClass;
    }


    public void printClass(){
        if(this.Class!=null){
            Debug.Log("Class Name: " + this.Class.Name + "\nClass Description: " + this.Class.Description + "\nClass Number: " + this.Class._ID);
        }
        
    }
}
