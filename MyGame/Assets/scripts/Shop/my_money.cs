using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class my_money : MonoBehaviour
{
    private MoneyCount money;
    public Text text;
    void Start()
    {
        money = GameObject.Find("Bill").GetComponent<MoneyCount>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = money.mon.ToString();
    }
}
