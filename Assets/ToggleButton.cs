using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{

    Image img;
    public Color Deactivated_Color = Color.grey;
    public Color Active_Color = Color.yellow;

    void Awake()
    {
        img = GetComponent<Image>();
    }

    public void Toggle(bool b)
    {
        if (b) img.color = Active_Color;
        else img.color = Deactivated_Color;//
    }

}
