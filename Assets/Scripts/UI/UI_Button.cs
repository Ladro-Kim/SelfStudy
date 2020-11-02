using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    public Text text;
    public InputField inputText;

    public void OnButtonClicked()
    {
        text.text = inputText.text;
    }

}
