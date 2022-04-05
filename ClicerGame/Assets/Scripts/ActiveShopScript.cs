using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveShopScript : MonoBehaviour
{
    public string[] titles;
    public GameObject button;
    public GameObject content;
    public Sprite imgbtn;
    //public MainScript mainScript;
    //public GameObject dmgBtn;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
