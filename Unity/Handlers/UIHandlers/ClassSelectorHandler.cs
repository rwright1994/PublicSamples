using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;

/// <summary>
/// Class Selection Handler used for handling character creation and class secetion.
/// </summary>
public class ClassSelectorHandler : MonoBehaviour
{

    //Primitive variables;
    private int classNum = 0;
    private int remainingStatPoints = 3;
    private Player Player;
    //GameObject references
    public GameObject classInfoPanel;  

    // Button references
    public Button LeftClassSelector;
    public Button RightClassSelector;
    // Image references
    public Image ClassIcon;

    //Text references
    public TextMeshProUGUI ClassText;
    public TextMeshProUGUI StrengthText;
    public TextMeshProUGUI ConstitutionText;
    public TextMeshProUGUI DexterityText;
    public TextMeshProUGUI CharismaText; 
    public TextMeshProUGUI WisdomText;
    public TextMeshProUGUI IntelligenceText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI StaminaText;
    public TextMeshProUGUI ManaText;
    public TextMeshProUGUI EnergyText;
    public TextMeshProUGUI SpiritText;
    public TextMeshProUGUI RemainingText;


    /// <summary>
    /// Initalizes required variables upon loading into the scene before awake.
    /// </summary>
    void Awake(){
        ResourceLoader.Instance.LoadClassResources();
        Player = GameObject.Find("Player").GetComponent<Player>();
        Player.ChangeClass(ResourceLoader.Instance.ClassData[0]);
        Player.characterSheet.RefreshStats();
       

    }

    /// <summary>
    /// Start is called before the first frame update. Used to attach OnClick Handlers
    /// for Class Selection Handling.
    /// </summary>
    void Start()
    {
        LeftClassSelector.onClick.AddListener(OnLeftChevronClick);
        RightClassSelector.onClick.AddListener(OnRightChevronClick);
    }

    // Update is called once per frame
    void Update()
    {
    
    // Updates information panels on the character creation screen
         if(Player != null){
            Debug.Log("Player Data Loaded!");

            ClassText.text = Player.characterSheet.CharacterClass.Name;
            ClassIcon.GetComponent<Image>().sprite = Player.characterSheet.CharacterClass.Icon;
            StrengthText.text = "Strength: " + Player.characterSheet.StatManager.findStat("Strength").Value;
            ConstitutionText.text = "Constitution: " + Player.characterSheet.StatManager.findStat("Constitution").Value;
            DexterityText.text = "Dexterity: " + Player.characterSheet.StatManager.findStat("Dexterity").Value;
            CharismaText.text = "Charisma: " + Player.characterSheet.StatManager.findStat("Charisma").Value;
            IntelligenceText.text = "Intelligence: " + Player.characterSheet.StatManager.findStat("Intelligence").Value;
            WisdomText.text = "Wisdom: " + Player.characterSheet.StatManager.findStat("Wisdom").Value;

            HealthText.text = "Health: " + Player.characterSheet.MaxHealth;
            StaminaText.text = "Stamina: " + Player.characterSheet.MaxStamina;
            ManaText.text = "Mana: " + Player.characterSheet.MaxMana;
            EnergyText.text = "Energy: " + Player.characterSheet.MaxEnergy;
            SpiritText.text = "Spirit: " + Player.characterSheet.MaxSpirit;

            RemainingText.text = "Remaining: " + remainingStatPoints;

    // Log a message if the data was not passed from the scene/
        }else{
            Debug.Log("Failed to load player data from the previous scene.");
        }
    }

/// <summary>
/// Left Chevron selectors for player class selection.
/// </summary>
        private void OnLeftChevronClick(){
        if(classNum == 0){
            classNum =2;
           
        }else{
            classNum--;
        }
       Player.ChangeClass(ResourceLoader.Instance.ClassData[classNum]);
 
    }

/// <summary>
/// Right Chevron selector for player class selection.
/// </summary>
    private void OnRightChevronClick(){
        if(classNum == 2){
            classNum = 0;
        }else{
            classNum++;
        }
        Player.ChangeClass(ResourceLoader.Instance.ClassData[classNum]);

    }

/// <summary>
/// Class Selection confirmation.
/// </summary>
    public void OnConfirm(){
        GameManager.Instance.ChangeState((int)GameManager.State.HUB);
        SceneManager.LoadScene((int)GameManager.Instance.state);
    }

/// <summary>
/// Increments the selected stat by 1.
/// </summary>
/// <param name="stat">Name for the stat to increase.</param>
    public void OnStatIncrease(string stat){
        if(remainingStatPoints != 0 ){
            Player.characterSheet.StatManager.findStat(stat).Value++;
            remainingStatPoints--;
            Player.characterSheet.RefreshStats();
        }
    }

/// <summary>
/// Decrements the selected stat by 1.
/// </summary>
/// <param name="stat">Name of the stat to decrease.</param>
    public void OnStatDecrease(string stat){
        if(Player.characterSheet.StatManager.findStat(stat).Value > 3){
            Player.characterSheet.StatManager.findStat(stat).Value--;  
            if(remainingStatPoints != 3){
                remainingStatPoints++;
                Player.characterSheet.RefreshStats();
            }
        }
    }


}
