using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class OfflineIncome : MonoBehaviour
{
    //public MainScript mainScript;
    [SerializeField]
    private int multi; //Множник(дільник) оффлайн заробітка
    public Text massage;
    public GameObject hideMassage;


    public void CalculateOfflineIncome(float idlemoney, float moneyfloat)
    {
        //float money = mainScript.moneyfloat;
        //float idlemoney = mainScript.idlemoney;
        multi = 10;

        var lastPlayedTime = DateTime.Parse(PlayerPrefs.GetString("LastPlayedTime", null));
        Debug.Log(lastPlayedTime.ToString());

        if (lastPlayedTime == null)
            return;

        int timeSpanRestriction = 24 * 60 * 60;
        double secondSpan = (DateTime.UtcNow - lastPlayedTime).TotalSeconds;
        Debug.Log(secondSpan);

        if (secondSpan > timeSpanRestriction)
            secondSpan = timeSpanRestriction;

        float totalDamage = (float)secondSpan * idlemoney / multi;
        moneyfloat += totalDamage;

        massage.text = "You was offline " + secondSpan + " sec. In this time you extracterd " + totalDamage + " ore";
    }

    public void HideMassage()
    {
        hideMassage.SetActive(false);
        //Destroy(hideMassage);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastPlayedTime", DateTime.UtcNow.ToString());
    }

    /*
    private void OnApplicationPause()
    {
        PlayerPrefs.SetString("LastPlayedTime", DateTime.UtcNow.ToString());
        Save();
    }
    */
}
