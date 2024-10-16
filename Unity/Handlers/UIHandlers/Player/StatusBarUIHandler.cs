using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatusBarUIHandler : MonoBehaviour
{

    private Player player;
    public Slider experienceBar;
    public Slider healthBar;
    public Slider manaBar;
    public TextMeshProUGUI experienceBarText;
    public TextMeshProUGUI healthBarText;
    public TextMeshProUGUI manaBarText;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player").GetComponent<Player>();
      experienceBar.minValue = player.Experience;
      experienceBar.maxValue = player.characterSheet.toNextLevel;
      healthBar.minValue = 0;
      healthBar.maxValue = player.characterSheet.MaxHealth;
      manaBar.minValue = 0;
      manaBar.maxValue = player.characterSheet.MaxMana;


    }

    // Update is called once per frame
    void Update()
    {
      
      RefreshHealth();
      RefreshMana();
      RefreshExperience();
    }


    public void RefreshHealth(){

      healthBar.value = player.Health;
      if(player.Health != 0){
        healthBarText.text = player.Health + " / " + player.characterSheet.MaxHealth;
      }else{
        healthBarText.text = "You've Perished.";
      }

      
    }

    public void RefreshMana(){
      manaBar.value = player.Mana;  
      manaBarText.text = player.Mana + " / " + player.characterSheet.MaxMana; 
    }

    public void RefreshExperience(){
      experienceBar.value = player.Experience;
      if(player.Experience >= player.characterSheet.toNextLevel){
        player.LevelUP();
        experienceBar.maxValue = player.characterSheet.toNextLevel;
      }
      experienceBarText.text = player.Experience + " / " + player.characterSheet.toNextLevel; 
    }

    
}
