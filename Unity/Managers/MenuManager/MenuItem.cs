using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem {

    private Menu menu;
    private string prefabName;
    public List<Menu> subMenus;

    public MenuItem(Menu menu, string prefabName, List<Menu> subMenus){
        this.menu = menu;
        if(prefabName != null){
            this.prefabName = prefabName;
        }else{
            this.prefabName = null;
        }
        
        if(subMenus != null){
            this.subMenus = subMenus;
        }else{
            this.subMenus = null;
        }
    }

    public Menu getMenu(){
        return menu;
    }

    public string getPrefabName(){
        return prefabName;
    }

        
}
