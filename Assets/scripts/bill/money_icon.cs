using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class money_icon : MonoBehaviour
{
    public Text text;
    public MoneyCount script;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = script.mon.ToString();
    }
}
