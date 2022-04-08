using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlanetHp : MonoBehaviour
{
    [SerializeField]
    private int maxHp, currentHp, bossHp;
    private const int startHp = 20;
    [SerializeField]
    private int stage, monsterKill;
    public int core;
    [SerializeField]
    private double percentHp;
    public Image hpImg;
    public double currentPersent;
    public Text monsterKillText;
    public Text stageText;

    private void Start()
    {
        monsterKill =  PlayerPrefs.GetInt("MonsterKill");
        stage =  PlayerPrefs.GetInt("Stage");


        monsterKillText.text = monsterKill + "/10";
        stageText.text = "Stage: " + stage;




        currentHp = maxHp = HpCounter(stage);
        //maxHp = 1500;

        //currentPersent = 100;
        GetComponentInChildren<Text>().text = maxHp + " / " + currentHp;
    }


    public void DamageCounter(int damage)
    {
        currentHp -= damage;
        
        if (currentHp <= 0)
            currentHp = 0;
        currentPersent = currentHp * 100;
        currentPersent /= maxHp;
        //currentPersent /= maxHp;
        //percentHp = maxHp / currentHp * 100;
        //percentHp = currentPersent * 100;
        //percentHp = percentHp / maxHp;
        Debug.Log(currentPersent);
        

        //Смерть моба
        if (currentHp <= 0)
            StageAndKill();
        //NewPlanet();

        GetComponentInChildren<Text>().text = currentHp + " / " + maxHp;
        ScaleSize();
    }
    

    private void ScaleSize()
    {  
        hpImg.rectTransform.localScale = new Vector2((int)currentPersent, 1);        
    }



    private void StageAndKill()
    {
        if (monsterKill < 10)
        {
            monsterKill++;
            monsterKillText.text = monsterKill + "/10";
        }
        else
        {
            stage++;
            monsterKill = 0;
            monsterKillText.text = monsterKill + "/10";
            stageText.text = "Stage: " + stage;
        }


        maxHp =  HpCounter(stage);
        currentHp = HpCounter(stage);
        currentPersent = 100;

        PlayerPrefs.SetInt("Stage", stage);
        PlayerPrefs.SetInt("MonsterKill", monsterKill);
    }

    private int HpCounter(int stage)
    {
        maxHp = startHp;       
        for (int i = 0; i <= stage; i++)
        {
            maxHp += maxHp / 3;
            Debug.Log(maxHp);
        }

        int tenPersent = maxHp / 10;

        maxHp += tenPersent;
        maxHp -= Random.Range(tenPersent, tenPersent * 2);

        return maxHp;
    }
}
