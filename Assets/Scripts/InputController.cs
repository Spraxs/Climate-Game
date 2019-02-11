using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public Action<ButtonInput> buttonInputAction;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("AButton")) buttonInputAction(ButtonInput.A);

        if (Input.GetButtonDown("BButton")) buttonInputAction(ButtonInput.B);

        if (Input.GetButtonDown("XButton")) buttonInputAction(ButtonInput.X);

        if (Input.GetButtonDown("YButton")) buttonInputAction(ButtonInput.Y);

    }

    public enum ButtonInput
    {
        A, B, X, Y
    }
}