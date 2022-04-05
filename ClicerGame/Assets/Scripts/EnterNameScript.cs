using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterNameScript : MonoBehaviour
{

    public GameObject background;
    [SerializeField] private GameObject inputField;
    [SerializeField] private GameObject assepted;
    [SerializeField] private Text text;
    [SerializeField] private bool isCliced = false;
    

    public void SetStartName()
    {
        background.SetActive(true);
        inputField.SetActive(true);
        assepted.SetActive(false);
    }

    public void AsseptButton()
    {
        inputField.SetActive(false);
        assepted.SetActive(true);
    }

    public void YesNoButton()
    {
        if (!isCliced)
        {
            text.text = "Are you sure to save name 'Dildo'?";
            isCliced = true;
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", "Dildo");
            background.SetActive(false);
        }
    }

    public void DestroyObj()
    {
        Destroy(background);
    }
}
