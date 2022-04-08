using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveShopScript : MonoBehaviour
{

    public GameObject button;
    public GameObject content;
    public MainScript mainScript;
    public GameObject boost1;


    //public GameObject dmgBtn;
    //public int[] baseprise;


    public string[] titles;
    public int[] price;


    private List<GameObject> list = new List<GameObject>();
    private VerticalLayoutGroup _group;


    void Start()
    {
        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        _group = GetComponent<VerticalLayoutGroup>();
        price = new int[titles.Length];
        SetShop();
    }

    private void RemoveList()
    {
        foreach (var elem in list)
        {
            Destroy(elem);
        }
        list.Clear();
    }

    void SetShop()
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
                pr.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("ActiveShop/" + i);
                var i1 = i;
                pr.GetComponentsInChildren<Text>()[3].text = mainScript.activeUpgradeLvl[i].ToString();
                PriceCount(i);
                pr.GetComponentsInChildren<Text>()[2].text = price[i].ToString();
                pr.GetComponentInChildren<Button>().onClick.AddListener(() => ShopList(i1));
                list.Add(pr);
            }
        }



        void ShopList(int id)
        {
            switch (id)
            {
                case 0:
                    Debug.Log(id);
                    //if (price[id] <= mainScript.moneyfloat)
                    if (mainScript.CheckMoney(price[id]))
                    {
                        mainScript.activeUpgradeLvl[id]++;
                        PriceCount(id);
                        mainScript.ClDmgCount(mainScript.activeUpgradeLvl[id]);
                        list[id].GetComponentsInChildren<Text>()[3].text = mainScript.activeUpgradeLvl[id].ToString();
                        list[id].GetComponentsInChildren<Text>()[2].text = price[id].ToString();
                    }
                    break;
                case 1:
                    Debug.Log(id);
                    if (mainScript.CheckMoney(price[id]))
                    {
                        boost1.SetActive(true);
                        mainScript.activeUpgradeLvl[id]++;  //Nai bude
                        PlayerPrefs.GetString("BoostIsActive", "true");
                        list[id].GetComponentsInChildren<Text>()[1].text = "Enable";

                        list[id].GetComponentsInChildren<Text>()[2].text = price[id].ToString();
                    }
                    break;
            }
        }


    }
    private void PriceCount(int i)
    {
        price[i] = mainScript.activeBasePrise[i];
        for (int j = 1; j <= mainScript.activeUpgradeLvl[i]; j++)
            price[i] += (int)price[i] / 3;
    }
}