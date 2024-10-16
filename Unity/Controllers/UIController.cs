using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour that manages control over the different UI Elements.
/// </summary>
public class UIController : MonoBehaviour
{

    public GameObject currentMenu;
    private List<GameObject> CachedMenus = new List<GameObject>();

    void Start(){
        currentMenu = null;
    }

/// <summary>
//  When passed in a UIElement the controller checks to see if the menu has already been
//  instantiated and cached for later use to prevent unncessesary instantiation and 
// data retreival.
// <summary>
    public void OpenUI(GameObject UIElement)
    {
        
        // No menus currently cached.
        if(CachedMenus.Count == 0 || currentMenu == null)
        {  
            CreateUIElement(UIElement);
        }
        // Toggle the UI element if it the current menu.
        else if(UIElement.name == currentMenu.name )
        {
            currentMenu.SetActive(!currentMenu.activeSelf);
        }
        // If it is not the current menu then loop through cached menus.
        else if(UIElement.name != currentMenu.name && CachedMenus.Count > 0)
        {
            // Turn off currently active UI Element.
            currentMenu.SetActive(false);

            // set the current menu to the cached menu, toggle it on.
            foreach(GameObject menu in CachedMenus){
                if(menu != null && !menu.Equals(null) && UIElement.name == menu.name){
                    currentMenu = menu;
                    menu.SetActive(true);
                    return;
                }  
            }
            CreateUIElement(UIElement);
            }
        }

    public void CloseUI(){
        if(currentMenu.activeSelf == true){
            currentMenu.SetActive(false);
        }
        currentMenu = null;
    }

    // <summary>
    // private function to instantiate UIElements.
    // <summary>
    private void CreateUIElement(GameObject UIElement){
            currentMenu = GameObject.Instantiate(UIElement, new Vector3(0f,0f,0f), Quaternion.identity);
            currentMenu.name = UIElement.name;
            CachedMenus.Add(currentMenu);
            currentMenu.transform.SetParent(GameObject.Find("Canvas").transform);
            currentMenu.transform.localScale = new Vector3(1f,1f,1f);
            currentMenu.transform.Translate(0,-.5f,0);
            currentMenu.SetActive(true);   
    }

 
}
