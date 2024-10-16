using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuHandler : MonoBehaviour
{

    private Player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
    }


public void LoadCharacterCreation(){
    if(Player.characterSheet == null){
       SceneLoader sceneManager = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
       Player.UIController.currentMenu = null;
       sceneManager.LoadScene("LoadingScreen");

    }
}

/// <summary>
/// Selects a given menu item for the UI Controller to render.
/// </summary>
/// <param name="name">Specified menun to openm</param>
    public void SelectMenuItem(string name){
        //Attempt to prase
        try{
            Menu menu = (Menu)Enum.Parse(typeof(Menu), name,true);
            foreach(MenuItem menuItem in ResourceLoader.Instance.MenuData){
                if(menuItem.getMenu() == menu){
                    Player.MenuManager.OpenMenu(menuItem);
                    Player.UIController.OpenUI(ResourceLoader.Instance.FindUIByName(menuItem.getPrefabName()));
                    Debug.Log("Opened: "+ name);
                }
            }
        }catch(ArgumentException err){
            Debug.Log("An error occured while casting menu to enum: " + name + " as a valid Menu Enum.");
        }
    }

/// <summary>
/// Checks to see if the Unity editor is playing, if it is then set it to false.
/// If the game is acutally running then close the application.
/// </summary>
    public void ExitGame(){
        if(Application.isPlaying){
            UnityEditor.EditorApplication.isPlaying = false;
        }else{
            Application.Quit();
        }
    }
}
