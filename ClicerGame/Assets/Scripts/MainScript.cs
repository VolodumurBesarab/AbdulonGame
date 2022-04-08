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
    public GameObject activescrollbar;
    public GameObject offlineMassage;
    public int cldmg;
    public float idlemoney;
    public float moneyfloat;
    public string boostIsActive;
    public ShopScript shopScript;
    public GameObject boostBtn;
    public BoosterScript boosterScript;
    public EnterNameScript enterName;
    public PlanetHp planetHp;
    public OfflineIncome offlineIncome;
    public EffectsController effectsController;
    private string playerName;
    public int[] upgradelvl;
    public int[] activeUpgradeLvl;
    [SerializeField]
    public int[] baseprise; //Стартова ціна пасив шопа
    public int[] activeBasePrise; //Стартова ціна ектів шопа
    public float[] xCounter; //Множник карутини в секунду
    public int boostPowerCounter; //Лічильник кліків для буста



    private int money; //Змінна лише для вивода в текст
    public Text moneytext;


    void Start()
    {
        upgradelvl = new int[baseprise.Length];
        activeUpgradeLvl = new int[activeBasePrise.Length];

        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            enterName.SetStartName();
            IsStart();
        }
        else
            enterName.DestroyObj();

        //IsStart();
        
        //xCounter = new int[shopScript.titles.Length];
        LoadSave();


        IdleMoneyCount();
        
        boosterScript.boost = 1;

        ClDmgCount(activeUpgradeLvl[0]);

        if (activeUpgradeLvl[1] == 1)
            boostBtn.SetActive(true);
        
        StartCoroutine(IdleFarm());
        StartCoroutine(SaveGameMin());

        offlineMassage.SetActive(true);
        offlineIncome.CalculateOfflineIncome(idlemoney);
    }


    public void ClDmgCount(int lvl)
    {
        int dmg = lvl + 1;
        cldmg = dmg * boosterScript.boost;
    }

    public void ActiveShop()
    {
        activescrollbar.SetActive(!activescrollbar.activeSelf);
        if (scrollbar.activeSelf)
            scrollbar.SetActive(false);
    }

    public void PasiveShop()
    {
        scrollbar.SetActive(!scrollbar.activeSelf);
        if (activescrollbar.activeSelf)
            activescrollbar.SetActive(false);
    }

    public void ButtonClick()
    {
        moneyfloat += cldmg;
        money = (int)moneyfloat;
        moneytext.text = money.ToString();
        boostPowerCounter++;
        boosterScript.Boost1Power(boostPowerCounter);
        effectsController.CreateEffect(cldmg);//Test
        planetHp.DamageCounter(cldmg);
        
    }
        

    public void IdleMoneyCount()
    {
        for (int i = 0; i <= upgradelvl.Length - 1; i++)
        {
            idlemoney += upgradelvl[i]*xCounter[i];
        }
        idlemoney /= 10; //руди за 0.1 сек
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
        PlayerPrefs.SetFloat("Moneyfloat", 0);
        PlayerPrefs.SetInt("Stage", 1);
        PlayerPrefs.SetInt("MonsterKill", 0);
        PlayerPrefs.SetString("BoostIsActive", "false");
        for (int i = 0; i <= shopScript.titles.Length; i++)
        {
            PlayerPrefs.SetInt("Upgradelevel"+i.ToString(), 0);
        }
        for (int i = 0; i <= activeBasePrise.Length; i++)
        {
            PlayerPrefs.SetInt("ActiveUpgradelevel" + i.ToString(), 0);
        }
    }


    public void LoadSave()
    {
        playerName = PlayerPrefs.GetString("PlayerName");
        moneyfloat = PlayerPrefs.GetFloat("Moneyfloat");
        boostIsActive = PlayerPrefs.GetString("BoostIsActive");
        for (int i = 0; i <= upgradelvl.Length-1; i++)
            upgradelvl[i] = PlayerPrefs.GetInt("Upgradelevel" + i.ToString());
        for (int i = 0; i <= activeBasePrise.Length - 1; i++)
            activeUpgradeLvl[i] = PlayerPrefs.GetInt("ActiveUpgradelevel" + i.ToString());
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Moneyfloat", moneyfloat);
        Debug.Log(moneyfloat);
        PlayerPrefs.SetString("BoostIsActive", boostIsActive);
        for (int i = 0; i <= upgradelvl.Length-1; i++)        
            PlayerPrefs.SetInt("Upgradelevel" + i.ToString(), upgradelvl[i]);
        for (int i = 0; i <= activeBasePrise.Length - 1; i++)
            PlayerPrefs.SetInt("ActiveUpgradelevel" + i.ToString(), activeUpgradeLvl[i]);
    }

    public void ExitButton()
    {
        Save();
        Application.Quit();
    }

    public void AddMoney(float money)
    {
        moneyfloat += money;
    }

    public void RemoveMoney(float money)
    {
        moneyfloat += money;
    }


    public bool CheckMoney(float prise)
    {
        if (moneyfloat >= prise)
        {
            moneyfloat -= prise;
            return true;
        }
        else
            return false;
    }


    private int test; 
    public int Test
    {
        get { return test; }
        set
        { 
            test = value;
        }
    }





    private void OnApplicationQuit()
    {
        Save();
        PlayerPrefs.SetString("LastPlayedTime", DateTime.UtcNow.ToString());
        //PlayerPrefs.SetString("LastPlayedTime", null);
    }

    


    /*
    private void OnApplicationPause()
    {
        Save();
    }
    */
}
