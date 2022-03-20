using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnShopScript : MonoBehaviour
{
    public Text txt;
    private ShopScript shopScript;
    //public Button button;
    //public int asdid;

    public void counter(int id)
    {
        txt.text = shopScript.titles[id];
    }

    
}
