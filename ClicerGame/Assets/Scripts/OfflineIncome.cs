using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class OfflineIncome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CalculateOfflineIncome()
    {
        var lastPlayedTime = DateTime.Parse(PlayerPrefs.GetString("LastPlayedTime", null));

        if (lastPlayedTime == null)
            return;

        int timeSpanRestriction = 24 * 60 * 60;
        double secondSpan = (DateTime.UtcNow - lastPlayedTime).TotalSeconds;

        if (secondSpan > timeSpanRestriction)
            secondSpan = timeSpanRestriction;

        //float totalDamage = (float)secondSpan * GetPa
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastPlayedTime", DateTime.UtcNow.ToString());
    }
}
