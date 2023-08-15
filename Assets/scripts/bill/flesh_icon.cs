using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flesh_icon : MonoBehaviour
{
    public Text text;
    public MoneyCount script;
    private int i;
    public GameObject flesh_1, flesh_2, flesh_3;
    private GameObject[] flesh; 
    void Start()
    {
        flesh = new GameObject[3];
        flesh[0] = flesh_1;flesh[1] = flesh_2;flesh[2] = flesh_3;
        i = 0;
    }

    void Update()
    {
        text.text = script.flesh[i].ToString();
    }
    public void Change()
    {
        flesh[i].SetActive(false);
        if (i == 2)
            i = 0;
        else
            i++;
        flesh[i].SetActive(true);
    }
}
