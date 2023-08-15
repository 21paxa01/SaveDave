using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bill_debaffs : MonoBehaviour
{
    private bill bill;
    private int pois_i;
    public int poison_damage;
    public GameObject poison_icon;
    private bool pois_chek;
    void Start()
    {
        bill = GetComponent<bill>();
        pois_chek = false;
        pois_i = 0;
    }

    void Update()
    {
        
    }
    public void poison_start()
    {
        if (pois_i == 0&&pois_chek==false)
            StartCoroutine(Poison());
        pois_i = 0;
    }
    private IEnumerator Poison()
    {
        pois_chek = true;
        poison_icon.SetActive(true);
        while (pois_i < 6)
        {
            pois_i++;
            bill.HP -= poison_damage;
            yield return new WaitForSeconds(1f);
        }
        pois_i = 0;
        poison_icon.SetActive(false);
        pois_chek = false;
    }
}
