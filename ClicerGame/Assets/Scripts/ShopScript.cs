using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
//using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public string[] titles;
    public GameObject button;
    public GameObject content;
    public Sprite imgbtn;
    public MainScript mainScript;
    public GameObject dmgBtn;

    //public int[] baseprise;
    public int[] price;
    





    private List<GameObject> list = new List<GameObject>();
    private VerticalLayoutGroup _group;


    void Start()
    {
        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        _group = GetComponent<VerticalLayoutGroup>();
        price = new int[titles.Length];
        //mainScript.baseprise = new int[titles.Length];
        SetSHop();
        
    }


    private void RemoveList()
    {
        foreach (var elem in list)
        {
            Destroy(elem);
        }
        list.Clear();
    }

    void SetSHop()
    {
        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        RemoveList();
        if (titles.Length > 0)
        {
            var pr1 = Instantiate(button.transform);
            var h = pr1.GetComponent<RectTransform>().rect.height;
            var tr = GetComponent<RectTransform>();
            tr.sizeDelta = new Vector2(tr.rect.width, h * titles.Length);
            Destroy(pr1.gameObject);

            for (var i = 0; i < titles.Length; i++)
            {
                var pr = Instantiate(button, transform);
                pr.GetComponentInChildren<Text>().text = titles[i];
                pr.GetComponentsInChildren<Image>()[1].sprite = imgbtn;
                var i1 = i;
                pr.GetComponentsInChildren<Text>()[3].text = mainScript.upgradelvl[i].ToString();
                PriceCount(i);
                pr.GetComponentsInChildren<Text>()[2].text = price[i].ToString();
                pr.GetComponentInChildren<Button>().onClick.AddListener(() => ShopList(i1));
                list.Add(pr);
            }
        }


    }

    void ShopList(int id)
    {
        switch (id)
        {
            case 0:
                Debug.Log(id);
                //string currentPrice =  list[id].GetComponentsInChildren<Text>()[2].text;
                if (price[id] <= mainScript.moneyfloat)

                {
                    mainScript.moneyfloat -= price[id];
                    mainScript.upgradelvl[id]++;
                    PriceCount(id);
                    mainScript.ClDmgCount(mainScript.upgradelvl[id]);
                    list[id].GetComponentsInChildren<Text>()[3].text = mainScript.upgradelvl[id].ToString();
                    list[id].GetComponentsInChildren<Text>()[2].text = price[id].ToString();
                }
                break;
            case 1:
                Debug.Log(id);
                if (price[id] <= mainScript.moneyfloat && !dmgBtn.activeSelf)
                {
                    dmgBtn.SetActive(true);
                    mainScript.moneyfloat -= price[id];
                    mainScript.upgradelvl[id]++;//Nai bude
                    PlayerPrefs.GetString("BoostIsActive", "true");
                    list[id].GetComponentsInChildren<Text>()[1].text = "Enable";

                    list[id].GetComponentsInChildren<Text>()[2].text = price[id].ToString();

                }
                break;
            case 2:
                IdleFarmBtn(id);
                break;
            case 3:
                IdleFarmBtn(id);
                break;
            case 4:
                IdleFarmBtn(id);
                break;
            case 5:
                IdleFarmBtn(id);
                break;
            case 6:
                IdleFarmBtn(id);
                break;
            case 7:
                IdleFarmBtn(id);
                break;
            case 8:
                IdleFarmBtn(id);
                break;
            case 9:
                IdleFarmBtn(id);
                break;
            case 10:
                IdleFarmBtn(id);
                break;
            case 11:
                IdleFarmBtn(id);
                break;
            case 12:
                IdleFarmBtn(id);
                break;
            case 13:
                IdleFarmBtn(id);
                break;
            case 14:
                IdleFarmBtn(id);
                break;

        }
    }

    public void IdleFarmBtn(int id)
    {
        if (price[id] <= mainScript.moneyfloat)
        {
            mainScript.moneyfloat -= price[id];
            mainScript.upgradelvl[id] ++;
            list[id].GetComponentsInChildren<Text>()[3].text = mainScript.upgradelvl[id].ToString();
            PriceCount(id);
            list[id].GetComponentsInChildren<Text>()[2].text = price[id].ToString();
        }
    }

    public void PriceCount(int i)
    {
        price[i] = mainScript.baseprise[i];
        for (int j = 1; j <= mainScript.upgradelvl[i]; j++)
            price[i] += (int)price[i] / 3;
    }

 

}
