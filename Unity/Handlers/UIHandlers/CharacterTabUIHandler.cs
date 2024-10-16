using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class CharacterTabUIHandler : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private GameObject CharacterPanelPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void ToggleCharacterSheet(){
        
    }
}
