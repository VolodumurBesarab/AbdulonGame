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
    public Transform spawnPoint;

    
    //public void SetEffect(int value)
    //{
        //var pref = Instantiate(effects, transform, false);
        //pref.SetPosition(Input.mousePosition);
        //pref.SetValue(value);
    //}


    public void CreateEffect(int value)
    {
        Vector2 vector2 = new Vector2(2.5f, 2.5f);
        Vector2 pos = new Vector2(Random.Range(spawnPoint.position.x - vector2.x, spawnPoint.position.x + vector2.x), Random.Range(spawnPoint.position.y - vector2.y, spawnPoint.position.y + vector2.y));
        Instantiate(spawnMoneyText, pos, Quaternion.identity, effectsSpawn.transform);
        effects.SetValue(value);
    }

}
