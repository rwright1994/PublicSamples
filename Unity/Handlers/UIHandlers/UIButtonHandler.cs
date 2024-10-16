using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHandler : MonoBehaviour
{
    [SerializeField]
    private UIController UIController;


    // Start is called before the first frame update
    void Start()
    {
        UIController = GameObject.Find("Player").GetComponent<Player>().UIController;
    }

    public void OnCofirm(GameObject UIElement){
        UIController.OpenUI(UIElement);
    }
}

