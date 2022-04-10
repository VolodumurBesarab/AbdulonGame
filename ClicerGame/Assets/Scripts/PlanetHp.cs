using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlanetHp : MonoBehaviour
{
    [SerializeField]
    private int revard;
    [SerializeField]
    private float maxHp, currentHp;
    private const int startHp = 20;
    [SerializeField]
    private bool bossDie = false, tryToKill = false;
    [SerializeField]
    private int stage, monsterKill;
    [SerializeField]
    private double timer; 
    public int core;
    [SerializeField]
    private double percentHp, currentPersent;
    //private int bossMaxHp, bossCurrentHp;
    //private const int bossStartHp = 20;
    public Image hpImg;
    public Text monsterKillText;
    public Text stageText;
    public MainScript mainScript;

    private void Start()
    {
        monsterKill =  PlayerPrefs.GetInt("MonsterKill");
        stage =  PlayerPrefs.GetInt("Stage");


        monsterKillText.text = monsterKill + "/10";
        stageText.text = "Stage: " + stage;




        currentHp = maxHp = revard = HpCounter(stage);
        timer = 0;
        tryToKill = false;
        bossDie = false;



        GetComponentInChildren<Text>().text = (int)maxHp + " / " + currentHp;
    }


    public void DamageCounter(float damage)
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
        //Debug.Log(currentPersent);


        //Смерть моба
        if (currentHp <= 0)
        {
            mainScript.AddMoney(revard);
            if (bossDie)
            {
                stage ++;
                bossDie = false;
                timer = 0;
            }

            if (!tryToKill)
            {
                if (monsterKill < 10)
                {
                    monsterKill++;
                }
                else
                {
                    stage++;
                    monsterKill = 0;
                }
            }

            monsterKillText.text = monsterKill + "/10";
            stageText.text = "Stage: " + stage; 

            

            if (stage % 10 == 0)
            {
                stage--;
                monsterKill = 10;
                Boss(); //генерится бос
            }
            else
                StageAndKill();// генерится моб

        }    
            


        GetComponentInChildren<Text>().text = (int)currentHp + " / " + (int)maxHp;
        ScaleSize();
    }
    

    private void ScaleSize()
    {  
        hpImg.rectTransform.localScale = new Vector2((int)currentPersent, 1);        
    }



    private void StageAndKill()
    {
        
        


        maxHp = currentHp = revard = HpCounter(stage);
        currentPersent = 100;

        GetComponentInChildren<Text>().text = (int)currentHp + " / " + (int)maxHp;
        ScaleSize();
        monsterKillText.text = monsterKill + "/10";
        stageText.text = "Stage: " + stage;

        PlayerPrefs.SetInt("Stage", stage);
        PlayerPrefs.SetInt("MonsterKill", monsterKill);
    }

    private void Boss()
    {
        bossDie = true;

        for (int i = 0; i <= stage; i++)
        {
            maxHp += maxHp / 5;
        }
        maxHp *= 2;
        currentHp = maxHp;
        currentPersent = 100;
        revard = (int)maxHp * 2;
        

        timer = 30;
        monsterKillText.text = timer.ToString();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.1f);
        timer -= 0.1;
        monsterKillText.text = timer.ToString();
        if (timer <= 0)
        {
            monsterKillText.text = monsterKill + "/10";
            stageText.text = "Stage: " + stage;

            if (bossDie)
            {              
                bossDie = false;
                revard = 0;
                StageAndKill();
                tryToKill = true;
            }
        }
        else
            StartCoroutine(Timer());
    }
    private int HpCounter(int stage)
    {
        maxHp = startHp;       
        for (int i = 0; i <= stage; i++)
        {
            maxHp += maxHp / 5;
        }

        int tenPersent = (int)maxHp / 10;

        maxHp += tenPersent;
        maxHp -= Random.Range(tenPersent, tenPersent * 2);

        return (int)maxHp;
    }

    public void NextBtn()
    {
        
        if (tryToKill)
        {
            tryToKill = false;
            Boss();
            stageText.text = "Stage: " + (stage + 1);
        }
        
    }
    
}
