using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneScript : MonoBehaviour
{
    private float speed = 3f;
    //public Vector2 vector2 = new Vector2(5f, 5f);
    public Vector2 pos;
    private Image image;

    private void Start()
    {
        StartCoroutine(DestroeObj());
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Meteors/" + Random.Range(1, 10));

    }
    void Update()
    {
        transform.Translate(pos * Time.deltaTime * speed);
    }       

    public void GetValue(Vector2 vector)
    {
        pos = vector;
        //StartCoroutine(DestroeObj());
    }

    public IEnumerator DestroeObj()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
