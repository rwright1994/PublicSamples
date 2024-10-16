using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CharacterSheetHandler : MonoBehaviour
{

    private Player player;
    public TextMeshProUGUI CharacterInformationText;
    [SerializeField]
    private GameObject[] ArmourSlots = new GameObject[7];
    [SerializeField]
    private  GameObject[] WeaponSlots = new GameObject[2];
    [SerializeField]
    private  GameObject[] RingSlots = new GameObject[2];
    private GameObject AccessorySlot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.characterSheet.StatManager.statList[0].GetValue();
    }

    // Update is called once per frame
    void Update()
    {

        CharacterInformationText.text = "Basic Information\n\nHealth: " + player.Health  +"\nStamina: " + player.Stamina + "\nMana: " + player.Mana +  "\nEnergy: " + player.Energy + "\nSpirit: " + player.Spirit 
        +  "\n\nBase Statistics\n\n" + DisplayStatistics() + DisplayResourceStatistics();
        // RenderEquipmentPanel();
    
    }

// Display players base attributes.
     private string DisplayStatistics(){
        string str = "";

            foreach(Stat stat in player.characterSheet.StatManager.statList){
                str += stat.Name + ": " + stat.Value + "\n";
            }
        return str;
        }

// Builds players resources stats string.
    private string DisplayResourceStatistics(){
        string str = "";
    if(player.ResourceManager.Resources !=null){
        foreach(Resource resource in player.ResourceManager.Resources){
            Debug.Log(resource.getName());
            str += resource.getName() + ": " + resource.amount + "\n"; 
        }
    }else{
        str += " Gold/sec: 0\n" + "Wood/sec: 0\n" + "Stone/sec: 0";
       
    }
     return str;
    }

    private void RenderEquipmentPanel(){
        int slotNum = 0;
        foreach(GameObject slot in ArmourSlots){
         if(player.EquipmentManager.ArmourSlots[slotNum].IsEmpty() == false){
            slot.GetComponent<Image>().sprite = Resources.Load<Sprite>(player.EquipmentManager.ArmourSlots[slotNum]._item.ItemProperties.SpriteURL);
            break;
         }
      }
    }
}
