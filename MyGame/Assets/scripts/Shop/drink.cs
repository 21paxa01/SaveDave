using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drink : MonoBehaviour
{
    private Animator anim;
    private MoneyCount MoneyCount;
    void Start()
    {
        MoneyCount = GameObject.Find("Bill").GetComponent<MoneyCount>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Recycle()
    {
        anim = GameObject.Find("drink").GetComponent<Animator>();
        MoneyCount.mon += MoneyCount.flesh[0]+ MoneyCount.flesh[1]*3+ MoneyCount.flesh[2]*5;
        MoneyCount.flesh[0] = 0; MoneyCount.flesh[1] = 0; MoneyCount.flesh[2] = 0;
        MoneyCount.Save();
        anim.SetBool("work", true);
    }
}
