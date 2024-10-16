using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the current game instance.
public class GameManager : MonoBehaviour
{

// Singleton setup for the Game Maanger.
    private static GameManager _instance;
    public static GameManager Instance{
        get
        {
            if (_instance == null){
                Debug.Log("Gamemanager Broken");
                
            }
          
            return _instance;
        }   
    }
    public float elapsedTime;
// Avilable states in the game.
    public enum State{
        MAINMENU = 0,
        CHARACTERCREATION = 1,
        HUB = 2,
        BUILDING = 3,
        MENUING = 4,
        LOADING = 99,
        PLAYING = 98
    }

// Tracks the current state
    public int state;

// Player reference
    public GameObject Player;
    private StateManager StateManager;

    // Start is called before the first frame update

    public void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        this.state = (int)State.MAINMENU;
   
    }

    public void Start()
    {
        elapsedTime = 0f;
        
    }

    public void Update(){

        if(state != (int)State.LOADING && state != (int)State.CHARACTERCREATION && state != (int)State.MAINMENU && state != (int) State.MENUING ){
            elapsedTime += Time.deltaTime;
        
            if(elapsedTime >= 5){
                Player.GetComponent<Player>().ResourceManager.tickResources();
                elapsedTime = 0f;
            }
            
        }else if(Player.GetComponent<Player>().MenuManager.isMenuOpen && state == (int)State.MENUING ){
            Debug.Log("Game paused by main menu.");
        }
    }

// Change the game state.
    public void ChangeState(int state){
        this.state = state;
    }


}
