using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharacterSheet 
{


    public List<Passive> Passives;
    //Managers
    public StatManager StatManager{get;set;}
    
    //EquipmentManager
    //PassiveSkillTreeManager

    public Class CharacterClass;

    public int Level = 1;
    private int FLAT_HEALTH = 25;
    private int FLAT_STAMINA = 15;
    private int FLAT_MANA = 15;
    private int FLAT_ENERGY = 15;
    private int FLAT_SPIRIT = 15;
    private int STARTING_EXP_TO_NEXT = 1000;
    private int BASE_HEALTH_PER_LEVEL = 2;
    private int BASE_MANA_PER_LEVEL= 2;
    private int BASE_STAMINA_PER_LEVEL = 1;
    private int BASE_ENERGY_PER_LEVEL = 1;
    private int BASE_SPIRIT_PER_LEVEL = 1;
    // Observers

    private List<ICharacterSheetObserver> Observers = new List<ICharacterSheetObserver>();

    // Health 
    private int health;

    public int Health
    {
        get
        { 
        return health;
        }
        set
        {
            if(value != health)
            {
                health = value;
                NotifyHealthChanged();
            }
        }
    }
    public int MaxHealth{get;set;}

    // Stamina.
    private int stamina;
    public int Stamina
    {
        get
        { 
            return stamina;
        }
        set
        {
            if(value != stamina)
            {
                stamina = value;
                NotifyStaminaChanged();
            }
        }
    }
    public int MaxStamina{get;set;}

    // Mana.
    private int mana;
    public int Mana
    {
        get
        {
             return mana;
        }
        set
        {
            if(value != mana)
            {
                mana = value;
                NotifyManaChanged();
            }
        }
    }
    
    public int MaxMana{get;set;}
     // Energy.
    private int energy;
    public int Energy{
        get
        { 
            return energy;
        }
        set
        {
            if(value != energy)
            {
                energy = value;
                NotifyEnergyChanged();
            }
        }
    }
    public int MaxEnergy{get;set;}
    
     // Spirit.
    private int spirit;
    public int Spirit{
        get
        { 
            return spirit;
        }
        set
        {
            if (value != spirit)
            {
                spirit = value;
                NotifySpiritChanged();
            }
        }
    }
    public int MaxSpirit{get;set;}

    // Experience.
    private int experience;
    public int Experience
    {
        get
        { 
            return experience;
        }
        set
        {
            if(value != experience)
            {
                experience = value;
                NotifyExpereienceChanged();
            }
        }
    }
    public int toNextLevel{get;set;}

    
    // Character Sheet Constructor.
    public CharacterSheet(){
        StatManager = new StatManager();
        this.Level = 1;
        this.Health = FLAT_HEALTH;
        this.MaxHealth = Health + (BASE_HEALTH_PER_LEVEL * Level);
        this.Stamina= FLAT_STAMINA;
        this.MaxStamina = Stamina;
        this.Mana = FLAT_MANA;
        this.MaxMana = Mana + (BASE_MANA_PER_LEVEL * Level);
        this.Energy = FLAT_ENERGY;
        this.MaxEnergy = Energy;
        this.Spirit = FLAT_SPIRIT;
        this.MaxSpirit = Spirit;
        CharacterClass = null;
        this.Experience = 0;
        this.toNextLevel = STARTING_EXP_TO_NEXT;
    }

    private int CalcMaxHP(){
       return this.MaxHealth = FLAT_HEALTH + GetStatBonus(1) + (BASE_HEALTH_PER_LEVEL * Level) + (CharacterClass.BaseHealth * Level) ;
    }

    private int CalcMaxMP(){
         return this.MaxMana = FLAT_MANA + GetStatBonus(4) + (BASE_MANA_PER_LEVEL * Level) + (CharacterClass.BaseMana * Level) ;
    }

    private int CalcMaxStamina(){
        return this.MaxStamina = FLAT_STAMINA + GetStatBonus(1) + (BASE_STAMINA_PER_LEVEL * Level) + (CharacterClass.BaseStamina * Level);
    }
   
    // Returns stat increases based on stat type passed in.
    private int GetStatBonus(int t){
        int val = 0;
        switch(t){
            //HP Increase from Consititution.
            case 1: 
                val += (int)Mathf.Floor(this.StatManager.statList[t].Value/3);
                break;
            
            // MP Increase from Intelligence.
            case 4:
                val += (int)Mathf.Floor(this.StatManager.statList[t].Value/2);
                break;
            default:
                val = 0;
                break;
        }
           return val;
        }


    // <summary>
    // When called, will refresh the players character sheet information that only needs updating when
    // stats are increased.
    // <summary>
    public void RefreshStats(){
       
        Health = FLAT_HEALTH + (BASE_HEALTH_PER_LEVEL * Level) + (CharacterClass.BaseHealth * Level);
        MaxHealth = CalcMaxHP();
        Stamina = 15 + (BASE_STAMINA_PER_LEVEL * Level) + (CharacterClass.BaseStamina * Level);
        MaxStamina = CalcMaxStamina();
        Mana = 15 + (BASE_MANA_PER_LEVEL * Level) + (CharacterClass.BaseMana * Level);
        MaxMana = CalcMaxMP();
        Energy = 15 + (BASE_ENERGY_PER_LEVEL * Level) + (CharacterClass.BaseEnergy * Level);
        Spirit = 15 + (BASE_SPIRIT_PER_LEVEL * Level) + (CharacterClass.BaseSpirit * Level);
    }

    public void ChangeClass(Class newClass){        
        CharacterClass = newClass;
        RefreshStats();
    }

    public void ChangeHealth(int newValue)
    {
        this.Health = newValue;
    }

    public void increaseLevel()
    {
        this.Level++;
        RefreshStats();
        
    }

    public void decreaseLevel()
    {
        this.Level--;
    }

   

    public void adjustExperienceToNext()
    {
        this.toNextLevel += ((1000*Level)+(400*Level)+(65*Level));
    }

// Observer Methods
    public void Subscribe(ICharacterSheetObserver observer)
    {
        Observers.Add(observer);
    }

    public void Unsubscribe(ICharacterSheetObserver observer)
    {
        Observers.Remove(observer);
    }

    public void NotifyHealthChanged()
    {
        if(Observers.Count != 0)
        {
            foreach(var observer in Observers)
            {
                observer.OnHealthChanged(health);
            }
        }
        else
        { 
                Debug.Log("Inital Health Established!");
        }
    }

    private void NotifyStaminaChanged()
    {
        if(Observers.Count !=0)
        {
            foreach(var observer in Observers)
            {
                observer.OnStaminaChanged(stamina);
            }
        }
    }

    private void NotifyManaChanged(){
        if(Observers.Count !=0)
        {
            foreach(var observer in Observers)
            {
                observer.OnManaChanged(mana);
            }
        }
    }

    private void NotifyEnergyChanged()
    {
        if(Observers.Count !=0)
        {
            foreach(var observer in Observers)
            {
                observer.OnEnergyChanged(energy);
            }
        }
    }

    private void NotifySpiritChanged()
    {
         if(Observers.Count !=0)
         {
            foreach(var observer in Observers)
            {
                observer.OnSpiritChanged(spirit);
            }
         }
    }

    private void NotifyExpereienceChanged()
    {
         if(Observers.Count !=0)
         {
            foreach(var observer in Observers)
            {
                observer.OnExperienceChanged(experience);
            }
         }
    }
}
