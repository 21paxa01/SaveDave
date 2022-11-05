using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drink : MonoBehaviour
{
    private Animator anim;
    private MoneyCount MoneyCount;
    public int l;
    public GameObject money;
    public Transform Drink;
    public float time;
    private float x, y;
    private bill bill;
    private bool work;
    void Start()
    {
        MoneyCount = GameObject.Find("Bill").GetComponent<MoneyCount>();
        bill = GameObject.Find("Bill").GetComponent<bill>();
    }
    void Update()
    {
        
    }
    public void Recycle()
    {
        if (work == false)
        {
            work = true;
            Drink = GameObject.Find("drink").GetComponent<Transform>();
            anim = GameObject.Find("drink").GetComponent<Animator>();
            //MoneyCount.mon += MoneyCount.flesh[0]+ MoneyCount.flesh[1]*3+ MoneyCount.flesh[2]*5;
            l = MoneyCount.flesh[0] + MoneyCount.flesh[1] * 3 + MoneyCount.flesh[2] * 5;
            //MoneyCount.flesh[0] = 0; MoneyCount.flesh[1] = 0; MoneyCount.flesh[2] = 0;
            MoneyCount.Save();
            StartCoroutine(Money_spawn());
            anim.SetBool("work", true);
        }
    }
    public int flesh_chek;
    IEnumerator Money_spawn()
    {
        flesh_chek = 0;
        time = 0.15f;
        bill.stop = true;
        while (l > 0)
        {
            x = Random.Range(-0.1f, 0.1f);
            y = Random.Range(-0.1f, 0.1f);
            if (MoneyCount.flesh[0] > 0)
            {
                MoneyCount.flesh[0]--;
                Instantiate(money, new Vector3(Drink.position.x + x, Drink.position.y + y, Drink.position.z), Drink.rotation);
                yield return new WaitForSeconds(time);
                l--;
                if (time > 0.025f)
                    time -= 0.0035f;
            }
            else if (MoneyCount.flesh[1] > 0)
            {
                for(int k=0;k<3;k++)
                {
                    Instantiate(money, new Vector3(Drink.position.x + x, Drink.position.y + y, Drink.position.z), Drink.rotation);
                    yield return new WaitForSeconds(time);
                    l--;
                    if (time > 0.025f)
                        time -= 0.0035f;
                }
                MoneyCount.flesh[1]--;
            }
            else if (MoneyCount.flesh[2] > 0)
            {
                for (int k = 0; k < 5; k++)
                {
                    Instantiate(money, new Vector3(Drink.position.x + x, Drink.position.y + y, Drink.position.z), Drink.rotation);
                    yield return new WaitForSeconds(time);
                    l--;
                    if (time > 0.025f)
                        time -= 0.0035f;
                }
                MoneyCount.flesh[2]--;
            }
        }
        bill.stop = false;
        work = false;
        anim.SetBool("work", false);
    }
}
