using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewHandler : MonoBehaviour
{


    public Scrollbar scrollbar;
    public TextMeshProUGUI scrollableText;
    // Start is called before the first frame update
    void Start()
    {
        scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    private void OnScrollbarValueChanged(float value){
        Debug.Log("Scrollbar value changed to: " + value);
        RectTransform rectTransform = scrollableText.GetComponent<RectTransform>();
        UnityEngine.Vector2 currPosition = rectTransform.anchoredPosition;
        currPosition.y = (400 - (400*value));

        rectTransform.anchoredPosition = currPosition;
    }

}
