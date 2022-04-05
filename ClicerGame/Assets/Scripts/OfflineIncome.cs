using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class OfflineIncome : MonoBehaviour
{
    public MainScript mainScript;
    public GameObject massage;
    
    public void CalculateOfflineIncome(float income)
    {
        int persent = 1; //ділення офф заррбітка

        var lastPlayedTime = DateTime.Parse(PlayerPrefs.GetString("LastPlayedTime", null));

        if (lastPlayedTime == null)
            return;

        int timeSpanRestriction = 24 * 60 * 60;
        double secondSpan = (DateTime.UtcNow - lastPlayedTime).TotalSeconds;

        if (secondSpan > timeSpanRestriction)
            secondSpan = timeSpanRestriction;

        float totalDamage = (float)secondSpan * income / persent;

        TimeSet(secondSpan, totalDamage);
        mainScript.AddMoney(totalDamage);
        

    }

    private void TimeSet(double time, float totalDamage)
    {
        int hour, min, sec;

        hour = (int)time / 3600;

        min = (int)time % 3600 / 60;

        sec = (int)time % 3600 % 60;

        massage.GetComponentInChildren<Text>().text = "You was offline " + hour + " hour " + min + " min " + sec + " sec and mine " + (int)totalDamage + " ore";
    }
    public void HideMassage()
    {
        Destroy(massage);
    }

}
