using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bestiary_cell_animation : MonoBehaviour
{
    public int i;
    public Bestiary script;
    private Animator anim;
    public bool test;
    void Start()
    {
        script = GameObject.Find("Home_Canvas").GetComponent<Bestiary>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.cell_ind_chek == i&& script.cell_ind!=-1)
        {
            anim.SetBool("active", true);
            test = true;
        }
        else
        {
            test = false;
            anim.SetBool("active", false);
        }
    }
}
