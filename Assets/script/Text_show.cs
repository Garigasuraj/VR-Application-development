using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class Text_show : MonoBehaviour

{
    [SerializeField] private Weight box_weight;

    [SerializeField] private TextMeshProUGUI weightText;


    void Update()
    {
        if (box_weight != null)
        {
            weightText.text = "Box Weight: " + box_weight.boxWeight.ToString("F1") + " kg";
        }
    }

}
