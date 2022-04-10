using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterScript : MonoBehaviour
{
    public int boost = 1;
    public MainScript mainScript;
    public ShopScript shopScript;
    public Image segment;
    public GameObject layout;
    //private int[] img; 


    void Start()
    {
        boost = 1;
    }
    public void Booster1()
    {
        if (mainScript.boostPowerCounter < 300)//500
            return;
        mainScript.boostPowerCounter = 0;
        for (int i = 0; i <= 9; i++)
            Destroy(layout.transform.GetChild(i).gameObject);

        boost = 5;
        mainScript.ClDmgCount(shopScript.mainScript.activeUpgradeLvl[0]);
        Invoke("BoosterInvokeMatYogoTyda", 20);        
    }


    private void BoosterInvokeMatYogoTyda()
    {
        boost = 1;
        mainScript.ClDmgCount(shopScript.mainScript.activeUpgradeLvl[0]);
    }

    public void Boost1Power (int counter)
    {
        if (counter > 300)
            return;
        if (counter % 30 == 0)
            Instantiate(segment, layout.transform);
    }

}
