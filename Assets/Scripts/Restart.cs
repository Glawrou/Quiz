using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    private Button MyButton;
    private Image MyImage;

    private void Start()
    {
        MyButton = GetComponent<Button>();
        MyImage = GetComponent<Image>();
    }

    public void InShowMe()
    {
        MyButton.enabled = true;
        MyImage.enabled = true;
    }

    public void OutShowMe()
    {
        MyButton.enabled = false;
        MyImage.enabled = false;
    }

}
