using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class Text_show : MonoBehaviour

{
    [SerializeField] private Weight box_weight;

    [SerializeField] private newboxweight big_box_weight;

    [SerializeField] private TextMeshProUGUI weightText;


    void Update()
    {
        Debug.Log("weight: " + box_weight.boxWeight);
        if (box_weight != null)
        {
            weightText.text = "Box Weight: " + box_weight.boxWeight.ToString("F1") + " kg";
        }
       // else if (big_box_weight != null)
       // {
       //     weightText.text = "Box Weight: " + big_box_weight.bigboxWeight.ToString("F1") + " kg";
       // } 

        // need to work on update.
    }

}
