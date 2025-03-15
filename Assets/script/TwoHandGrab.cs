using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandGrab : XRGrabInteractable
{
    public Transform secondHandAttach;
    private bool isTwoHanded = false;

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if (!isTwoHanded && interactor.name == "SecondHand") // Assign the second hand
        {
            isTwoHanded = true;
        }
        else if (isTwoHanded)
        {
            base.OnSelectEntered(interactor);
        }
    }
}

