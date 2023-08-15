using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawn_time : MonoBehaviour
{
    public Text count;
    private int a;
    public death death_script;
    public bill bill_script;
    public new_wave new_wave_script;
    public ultimate ultimate_script;
    public bool chek;
    void Start()
    {
        chek = true;
    }

    // Update is called once per frame
    void Update()
    {
        count.text = a.ToString();
    }
    public void active_count()
    {
        if (chek == true)
        {
            a = 10;
            StartCoroutine(Count());
            chek = false;
        }
    }
    IEnumerator Count()
    {
        if (chek == true)
        {
            a = 10;
            while (a > 0)
            {
                yield return new WaitForSeconds(1f);
                a--;
            }
            death_script.Restart();
            bill_script.REspawn();
            new_wave_script.NeW_Wave();
            ultimate_script.UltOff();
        }
    }
}
