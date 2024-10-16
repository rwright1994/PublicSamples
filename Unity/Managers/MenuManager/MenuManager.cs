using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Menu manager class that holds a reference to a menu stack for the games main
/// menu. 
/// </summary>
/// 
[System.Serializable]
public class MenuManager {

    public bool isMenuOpen;
    public MenuStack MenuStack;
    public MenuManager(){
        isMenuOpen = false;
        MenuStack = new MenuStack();
    }

    /// <summary>
    /// Opens the given MenuItem and toggles on menu.
    /// </summary>
    /// <param name="menu"></param>
    public void OpenMenu(MenuItem menu){
        MenuStack.Push(menu);
        isMenuOpen = true;
    }


    public void CloseMenu(){
        MenuStack.Pop();
        if(MenuStack.getStackCount() == 0){
            this.isMenuOpen = false;
            Debug.Log("Stack is now empty");
        }
    }

    
    
}
