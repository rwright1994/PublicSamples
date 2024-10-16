using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotUIHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{

    
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData  ptr){

    }
    

    public void OnPointerUp(PointerEventData ptr){
        
    }

    public void OnDrag(PointerEventData ptr){
        rectTransform.anchoredPosition += ptr.delta / canvas.scaleFactor; // Move the UI element with the mouse cursor
    
    }

    public void OnPointerEnter(PointerEventData ptr)
    {
      Debug.Log("Entering: " + ptr.pointerEnter);
    }

    public void OnPointerExit(PointerEventData ptr)
    {
        Debug.Log("Exiting: " + ptr.hovered); 
    }
}
