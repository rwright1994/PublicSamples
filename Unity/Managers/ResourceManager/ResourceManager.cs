
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResourceManager{

    public List<Resource> Resources = new List<Resource>();
  
    public ResourceManager(){
            initalizeResourceManager();
    }

    public void tickResources(){

        foreach(Resource resource in Resources){
            resource.tickResource();
        }
        Debug.Log("Resource Ticked");
    }

    private void initalizeResourceManager(){
        Resources.Add(new Resource(0, "Gold" ,6.5));
        Resources.Add(new Resource(1,"Stone", 1));
        Resources.Add(new Resource(2,"Wood", 1));
    }
}

