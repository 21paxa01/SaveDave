using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultimate : MonoBehaviour
{
    public change_weapon change;
    private int change_i;
    public GameObject skins;
    public Animator anim;
    private bool move;
    public GameObject weapon;
    public GameObject minigun_icon;
    public shoting minigun_1, minigun_2;
    public bill bill;
    void Start()
    {
        
    }

    void Update()
    {
        anim.SetBool("move", move);
        if (bill.moveX > 0)
            move = true;
        else
            move = false;
    }
    public void UltOff()
    {
        change_weapon.change = change_i;
        change.weapons[change_i].SetActive(true);
        change.ult = false;
        skins.SetActive(true);
        weapon.SetActive(true);
        minigun_icon.SetActive(false);
        gameObject.SetActive(false);
    }
    public void Activate()
    {
        weapon.SetActive(false);
        minigun_icon.SetActive(true);
        change_i = change_weapon.change;
        change.weapons[change_i].SetActive(false);
        change_weapon.change = 100;
        minigun_1.ReloaD = false;
        minigun_1.reload = 0f;
        minigun_1.stop = false;
        minigun_2.ReloaD = false;
        minigun_2.reload = 0f;
        minigun_2.stop = false;
        Invoke("UltOff", 15f);
    }
}
