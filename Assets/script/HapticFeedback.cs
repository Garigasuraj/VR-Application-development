using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    public XRBaseController controller;
    public float hapticIntensity = 0.5f;
    public float duration = 0.2f;

    public void TriggerHapticFeedback()
    {
        if (controller != null)
        {
            controller.SendHapticImpulse(hapticIntensity, duration);
        }
    }
}