using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typewriter : MonoBehaviour
{
    public string text;
    public int l;
    public int i;
    public Text txt;
    public bool chek;
    void Start()
    {
        txt = GetComponent<Text>();
        l = text.Length;
        StartCoroutine(Tipe());
    }

    void Update()
    {
        
    }
    IEnumerator Tipe()
    {
        i = 0;
        while (i < l)
        {
            txt.text += text[i];
            i++;
            yield return new WaitForSeconds(0.02f);
        }
    }
    public void StartType()
    {
        if (chek == false)
        {
            i = l;
            i = 0;
            txt.text = "";
            l = text.Length;
            chek = true;
            StartCoroutine(Tipe());
        }
    }
}
