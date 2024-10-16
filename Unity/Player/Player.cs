using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.TextCore.Text;

/// <summary>
/// Main player gameobject that contains all trackable information on the player.
/// Systems are initalized when the player is created and may have state management
/// implemented seperately from the game to allow for multiple player access.
/// </summary>
public class Player : MonoBehaviour, ICharacterSheetObserver
{


    public GameManager GameManager;
    [SerializeField] 
    public MenuManager MenuManager;
    
    [SerializeField] 
    public ResourceManager ResourceManager;
    public UIController UIController;
    public EquipmentManager EquipmentManager;
    public InventoryManager Inventory;
    public GameObject CharacterPanel;
    public GameObject ResourcePanel;
    public GameObject SelectedObject;

    [SerializeField]    
    public CharacterSheet characterSheet;
    public int Health;
    public int Stamina;
    public int Mana;
    public int Energy;
    public int Spirit;
    public int Experience;


    // Start is called before the first frame update
    void Start()
    {
        //Create menu manager object and render UI when game opens.
        MenuManager = new MenuManager(); 
        MenuManager.OpenMenu(ResourceLoader.Instance.MenuData[0]);
        this.UIController = this.GetComponent<UIController>(); 
        this.UIController.OpenUI(ResourceLoader.Instance.UIPrefabs[3]);
        
        characterSheet = null;

        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {   

// ********* Handle Main Player inputs ************ //

s//  *********** MAIN MENU HANDLING ************ //
    if(GameManager.Instance.state == (int)GameManager.State.MAINMENU){
        if(Input.GetButtonDown("Main Menu") && MenuManager.MenuStack.getStackCount() == 1){
            ExitApplication();
        }else if(Input.GetButtonDown("Main Menu") && MenuManager.MenuStack.getStackCount() > 1){
            MenuManager.CloseMenu();
           this.UIController.OpenUI(ResourceLoader.Instance.FindUIByName(MenuManager.MenuStack.getCurrentMenu().getPrefabName()));
        }
    //  *********** Main Game Input Handling ************ //
    }else if(GameManager.Instance.state == (int)GameManager.State.PLAYING){
        if(Input.GetButtonDown("Main Menu")){
            OpenMainMenu();
        }
        if(Input.GetButtonDown("Character Sheet")){
            UIController.OpenUI(ResourceLoader.Instance.UIPrefabs[0]);
        }        
    }


    // If the game is currently playing
    //     else if((GameManager.Instance.state != (int)GameManager.State.CHARACTERCREATION && GameManager.Instance.state != (int)GameManager.State.LOADING))
    //     {
    //     //'c' to open character sheet to view stats
    //         if(Input.GetButtonDown("Character Sheet"))
    //         {
    //             UIController.OpenUI(ResourceLoader.Instance.UIPrefabs[0]);
    //         }

    //     //'r' to open resources tab to view current resources. 
    //         if(Input.GetButtonDown("Resources"))
    //         {
    //             UIController.OpenUI(ResourceLoader.Instance.UIPrefabs[1]);
    //         }

    //         if(Input.GetButtonDown("Inventory")){
    //             UIController.OpenUI(ResourceLoader.Instance.UIPrefabs[2]);
    //         }
    

    // // Keys for testing purposes.
    //         if(Input.GetKeyDown(KeyCode.Space))
    //         {
    //            characterSheet.StatManager.statList[0].AddStatModifier(new StatModifier(2.5f, ModifierType.Multiplicative));
    //           Debug.Log(characterSheet.StatManager.statList[0].GetValue());
    //         }

    //         if(Input.GetButtonDown("LevelUp"))
    //         {
    //             Experience += (int)23 * characterSheet.Level;
    //         }

    //         if(Input.GetButtonDown("Test Equip"))
    //         {
                
    //             if(EquipmentManager.ArmourSlots[0]._item == ResourceLoader.Instance.ArmourData[0]){
    //                 EquipmentManager.ArmourSlots[0]._item = ResourceLoader.Instance.ArmourData[1];
    //             }else{
    //                 EquipmentManager.ArmourSlots[0]._item = ResourceLoader.Instance.ArmourData[0];
    //             }
    //         }
    //     }
    }

    /// <summary>
    /// Opens the main menu when the 'escape/esc' is pressed.
    /// </summary>
    public void OpenMainMenu(){
        if(MenuManager.isMenuOpen == false){
            MenuManager.OpenMenu(ResourceLoader.Instance.MenuData[0]);
            GameManager.Instance.state = (int)GameManager.State.MENUING;
            UIController.OpenUI(ResourceLoader.Instance.UIPrefabs[3]);
        }else{
            Debug.Log("Closed Main Menu.");
            MenuManager.CloseMenu();
            GameManager.Instance.state = (int)GameManager.State.PLAYING;
            UIController.OpenUI(ResourceLoader.Instance.UIPrefabs[3]);
        }
    }

    public void ExitApplication(){
        if(Application.isPlaying){
            UnityEditor.EditorApplication.isPlaying = false;
        }else{
            Application.Quit();
        }
    }

    /// <summary>
    /// Performs actions to level player up.
    /// </summary>
    public void LevelUP()
    {
        characterSheet.increaseLevel();
        characterSheet.adjustExperienceToNext();
        Debug.Log("Leveled Up");
    }

    public void ChangeClass(Class newClass)
    {
        characterSheet.ChangeClass(newClass);
    }

    public void TakeDamage(int damageTaken)
    {
        Health -= damageTaken;
        
    }

    // Character Sheet Observer methods.
    public void OnHealthChanged(int newHealth)
    {
        Health = newHealth;        
    }
    
    public void OnManaChanged(int newMana)
    {
        Mana = newMana;
    }   

    public void OnEnergyChanged(int newEnergy)
    {
        Energy = newEnergy;
    }

    public void OnStaminaChanged(int newStamina)
    {
        Stamina = newStamina;
    }        

    public void OnSpiritChanged(int newSpirit)
    {
        Spirit = newSpirit;
    }

    public void OnExperienceChanged(int newExperience)
    {
        Experience = newExperience;
    }

    /// <summary>
    /// Initalizes the players character sheet with default values.
    /// After creation subscribes the player to observe changes in information.
    /// </summary>
    public void InitalizeCharacterSheet(){
        if(characterSheet == null){
            this.characterSheet = new CharacterSheet();
            characterSheet.Subscribe(this);
        }else{
            Debug.Log("Character sheet already initalized for " + this);
        }      
}

    /// <summary>
    /// Initalizes the player's inventory manager.
    /// </summary>
    public void InitalizeInventoryManager(){
        if(Inventory == null){
            Inventory = new InventoryManager();
        }else{
            Debug.Log("Inventory already initalized for " + this);
        }
    }
    

    /// <summary>
    /// Initalizes the players equipment manager.
    /// </summary>
    public void InitalizeEquipmentManager(){
        if(EquipmentManager == null){
            EquipmentManager = new EquipmentManager();
        }else{
            Debug.Log("Equipment manager already initalized for " + this);
        }
    }

    /// <summary>
    /// Initalizes the players resouces manager.
    /// </summary>
    public void InitalizieResourceManager(){
        if(ResourceManager == null){
            ResourceManager = new ResourceManager();
        }else{
            Debug.Log("Resource manager already initalized for " + this);
        }
    }
}

