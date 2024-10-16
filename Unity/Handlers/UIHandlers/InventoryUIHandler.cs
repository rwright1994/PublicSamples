using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUIHandler : MonoBehaviour
{
    private Player player;
    
     [SerializeField]
    private GameObject slotPrefab;
    private List<GameObject> slots = new List<GameObject>();

    public void Start()
    {
        this.player = GameObject.Find("Player").GetComponent<Player>();

        int row = 0;
        int col = 0;

        for(int i = 0; i < player.Inventory.maxCapacity; i++)
        {
            
                GameObject obj = GameObject.Instantiate(slotPrefab,GameObject.Find("InventoryPanel").transform, false);
                
                obj.transform.Translate(1.2f+(0.9f*col),7f+(-.9f*row),0);
                obj.SetActive(true);
                slots.Add(obj);
                col++;  
                if(col % 6 == 0 )
                {
                    row++;
                    col = 0;
                }
            }
            player.Inventory.AddItem(ResourceLoader.Instance.ArmourData[0]);
            player.Inventory.AddItem(ResourceLoader.Instance.ArmourData[1]);
         
        }

    public void Update()
    {
        RenderInventory();
    }


    public void RenderInventory()
    {
        if(player.Inventory.InventorySlots != null){
            int slotNum = 0;
            foreach(GameObject slot in slots){
                if(slotNum < player.Inventory.maxCapacity && !player.Inventory.InventorySlots[slotNum].IsEmpty()){
                    // slots[slotNum].GetComponent<Image>().sprite = player.Inventory.InventorySlots[slotNum].Icon;
                }
                    slotNum++;
            }
        }
    }

    
}
