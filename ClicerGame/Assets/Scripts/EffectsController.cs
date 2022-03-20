using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectsController : MonoBehaviour
{
    public Effects effects;
    public GameObject effectsSpawn;
    public Text spawnMoneyText;

    
    //public void SetEffect(int value)
    //{
        //var pref = Instantiate(effects, transform, false);
        //pref.SetPosition(Input.mousePosition);
        //pref.SetValue(value);
    //}

    public void CreateEffect(int value)
    {
        Instantiate(spawnMoneyText, effectsSpawn.transform);
        effects.SetValue(value);

        //GetComponentInChildren<Text>().text = "+" + value.ToString();
    }

}
