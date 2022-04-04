using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;


public class MainScript : MonoBehaviour
{
    private string path;
    public GameObject scrollbar;
    public int cldmg;
    public float idlemoney;
    public float moneyfloat;
    public string boostIsActive;
    public OfflineIncome offlineIncome;
    public ShopScript shopScript;
    public GameObject boostBtn;
    public BoosterScript boosterScript;
    public EnterNameScript enterName;
    public PlanetHp planetHp;
    public EffectsController effectsController;
    private string playerName;
    public int[] upgradelvl;
    [SerializeField]
    public int[] baseprise; //Стартова ціна
    public float[] xCounter; //Множник карутини в секунду
    public int boostPowerCounter; //Лічильник кліків для буста



    private int money; //Змінна лише для вивода в текст
    public Text moneytext;
    

    void Start()
    {
        upgradelvl = new int[baseprise.Length];
        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            enterName.SetStartName();
            IsStart();
        }
        //IsStart();
        
        //xCounter = new int[shopScript.titles.Length];
        LoadSave();
        Debug.Log(moneyfloat);

        IdleMoneyCount();
        
        boosterScript.boost = 1;

        ClDmgCount(upgradelvl[0]);

        if (upgradelvl[1] == 1)
            boostBtn.SetActive(true);
        
        StartCoroutine(IdleFarm());
        StartCoroutine(SaveGameMin());

        offlineIncome.CalculateOfflineIncome(idlemoney, moneyfloat);
    }

    public void ClDmgCount(int lvl)
    {
        int dmg = lvl + 1;
        cldmg = dmg * boosterScript.boost;
    }

    public void ActiveShop()
    {
        scrollbar.SetActive(!scrollbar.activeSelf);
        Save();
    }

    public void ButtonClick()
    {
        moneyfloat += cldmg;
        money = (int)moneyfloat;
        moneytext.text = money.ToString();
        boostPowerCounter++;
        boosterScript.Boost1Power(boostPowerCounter);
        effectsController.CreateEffect(cldmg);
        planetHp.DamageCounter(cldmg);
        
    }
        

    public void IdleMoneyCount()
    {
        for (int i = 2; i <= upgradelvl.Length - 1; i++)
        {
            idlemoney += upgradelvl[i]*xCounter[i];
        }
        idlemoney /= 10;
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(0.1f);
        IdleMoneyCount();
        moneyfloat += idlemoney;
        //money = (int)moneyfloat;
        //Debug.Log(moneyfloat);
        money = (int)moneyfloat;
        moneytext.text = money.ToString();
        StartCoroutine(IdleFarm());
    }

    IEnumerator SaveGameMin()
    {
        yield return new WaitForSeconds(15f);
        Save();
        StartCoroutine(SaveGameMin());
    }

    public void IsStart()
    {
        PlayerPrefs.SetInt("Moneyfloat", 0);
        PlayerPrefs.SetString("BoostIsActive", "false");
        for (int i = 0; i <= shopScript.titles.Length; i++)
        {
            PlayerPrefs.SetInt("Upgradelevel"+i.ToString(), 0);
        }
    }


    public void LoadSave()
    {
        playerName = PlayerPrefs.GetString("PlayerName");
        moneyfloat = PlayerPrefs.GetFloat("Moneyfloat");
        //Debug.Log(money);
        boostIsActive = PlayerPrefs.GetString("BoostIsActive");
        for (int i = 0; i <= upgradelvl.Length-1; i++)
            upgradelvl[i] = PlayerPrefs.GetInt("Upgradelevel" + i.ToString());
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Moneyfloat", moneyfloat);
        Debug.Log(moneyfloat);
        PlayerPrefs.SetString("BoostIsActive", boostIsActive);
        for (int i = 0; i <= upgradelvl.Length-1; i++)
        {
            PlayerPrefs.SetInt("Upgradelevel" + i.ToString(), upgradelvl[i]);
        }
    }

    public void ExitButton()
    {
        Save();
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        Save();
    }
    /*
    private void OnApplicationPause()
    {
        Save();
    }
    */
}
