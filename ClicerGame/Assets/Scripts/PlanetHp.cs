using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlanetHp : MonoBehaviour
{
    [SerializeField]
    private int maxHp = 3200, currentHp;
    public int core;
    [SerializeField]
    private double percentHp;
    public Image hpImg;
    public double currentPersent;

    private void Start()
    {
        maxHp = 1500;
        currentHp = maxHp;
        currentPersent = 100;
        GetComponentInChildren<Text>().text = maxHp + " / " + currentHp;
    }
    public void DamageCounter(int damage)
    {
        currentHp = currentHp - damage;
        
        if (currentHp <= 0)
            currentHp = 0;
        currentPersent = currentHp * 100;
        currentPersent /=  maxHp;
        //currentPersent /= maxHp;
        //percentHp = maxHp / currentHp * 100;
        //percentHp = currentPersent * 100;
        //percentHp = percentHp / maxHp;
        Debug.Log(currentPersent);
        GetComponentInChildren<Text>().text = maxHp + " / " + currentHp;
        if (currentHp <= 0)
            NewPlanet();
        ScaleSize();
    }
    
    public void ScaleSize()
    {
        //var pref = GetComponentsInChildren<Image>();
        
        hpImg.rectTransform.localScale = new Vector2((int)currentPersent, 1);
        
    }

    public void NewPlanet()
    {
        // отигруєм анимацию
        maxHp = currentHp = 9999999;
    }

}
