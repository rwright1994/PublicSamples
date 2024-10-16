using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ResourcePanelUIHandler : MonoBehaviour
{
    private Player player;

    public List<TextMeshProUGUI>TrackerUIElements = new List<TextMeshProUGUI>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        RenderResources();
    }

    private void RenderResources(){
        foreach(Resource resource in player.ResourceManager.Resources){
            TrackerUIElements[resource._id].text = resource.getName() + ": " + resource.amount.ToString();
        }
    }
}
