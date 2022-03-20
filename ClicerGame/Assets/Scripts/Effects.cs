using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Effects : MonoBehaviour
{
    [SerializeField]
    private Text text;
    //private TextMeshProUGUI text;
    [SerializeField]
    private CanvasGroup group;



   
    void Update()
    {
        group.alpha = Mathf.Lerp(group.alpha, 0, Time.deltaTime * 5);
        transform.position += Vector3.up * Time.deltaTime * 2;

        if (group.alpha < .01f)
            Destroy(gameObject);

    }
    
    public void SetValue(int value)
    {
        text.text = "+ " + value;
    } 
}
