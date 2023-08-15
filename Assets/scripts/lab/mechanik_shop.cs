using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class mechanik_shop : MonoBehaviour
{
    public GameObject bill;
    public static bool lab;
    public GameObject lab_menu;
    public GameObject board;
    public GameObject fon;
    public SpriteRenderer sp;
    public GameObject static_weap;
    public GameObject weapons;
    public GameObject shotgun;
    public GameObject ak47;
    public GameObject pistol;
    public GameObject rpg;
    public GameObject p90;
    public GameObject snowgun;
    public GameObject awp;

    public GameObject buy_menu;
    private weapons_upgrade script;
    public int i;
    public int category;
    public Text text;

    private GameObject[] weapons_arr= new GameObject[7];

    public GameObject damage_marking1;
    public GameObject damage_marking2;
    public GameObject damage_marking3;
    public GameObject damage_marking4;
    public GameObject damage_marking5;
    public GameObject reload_marking1;
    public GameObject reload_marking2;
    public GameObject reload_marking3;
    public GameObject reload_marking4;
    public GameObject reload_marking5;
    public GameObject ammunition_marking1;
    public GameObject ammunition_marking2;
    public GameObject ammunition_marking3;
    public GameObject ammunition_marking4;
    public GameObject ammunition_marking5;

    private GameObject[] damage_marking_arr = new GameObject[5];
    private GameObject[] reload_marking_arr = new GameObject[5];
    private GameObject[] ammunition_marking_arr = new GameObject[5];
    private int prise;
    public Save save_script;
    private MoneyCount mon_scrript;
    private MoneyCount MoneyCount;
    public GameObject Canvas;
    public GameObject damage_button, reload_button, ammunition_button;
    void Start()
    {
        mon_scrript = GameObject.Find("Bill").GetComponent<MoneyCount>();
        save_script = GameObject.Find("save").GetComponent<Save>();
        save_script.Load_weapon();
        //damage_marking_arr = new GameObject[5];
        //reload_marking_arr = new GameObject[5];
        //ammunition_marking_arr = new GameObject[5];
        bill = GameObject.Find("Bill");
        script = bill.gameObject.GetComponent<weapons_upgrade>();
        i = 0;
        sp = board.GetComponent<SpriteRenderer>();
        //weapons_arr = new GameObject[7];
        weapons_arr[0] = pistol; weapons_arr[1] = shotgun; weapons_arr[5] = ak47;weapons_arr[4] = rpg;weapons_arr[2] = p90;weapons_arr[6] = snowgun;weapons_arr[3] = awp;
        damage_marking_arr[0] = damage_marking1; damage_marking_arr[1] = damage_marking2; damage_marking_arr[2] = damage_marking3; damage_marking_arr[3] = damage_marking4; damage_marking_arr[4] = damage_marking5;
        reload_marking_arr[0] = reload_marking1; reload_marking_arr[1] = reload_marking2; reload_marking_arr[2] = reload_marking3; reload_marking_arr[3] = reload_marking4; reload_marking_arr[4] = reload_marking5;
        ammunition_marking_arr[0] = ammunition_marking1; ammunition_marking_arr[1] = ammunition_marking2; ammunition_marking_arr[2] = ammunition_marking3; ammunition_marking_arr[3] = ammunition_marking4; ammunition_marking_arr[4] = ammunition_marking5;
        ChekUpgrades();
        //Load();
        MoneyCount = GameObject.Find("Bill").GetComponent<MoneyCount>();
        Canvas = GameObject.Find("Home_Canvas");
    }

    void Update()
    {
        if (lab == true)
        {
            static_weap.SetActive(false);
            lab_menu.SetActive(true);
            ShopCamera.x = -1.05f;
            ShopCamera.y = 0.3f;
            ZoomCamera.zoom = 0.35f;
            sp.sortingOrder = 21;
            fon.SetActive(true);
            weapons.SetActive(true);
            Canvas.SetActive(false);
        }
        else
        {
            Canvas.SetActive(true);
            static_weap.SetActive(true);
            lab_menu.SetActive(false);
            ShopCamera.x = 0f;
            ZoomCamera.zoom = 0.7f;
            ShopCamera.y = 0.1f;
            sp.sortingOrder = 1;
            fon.SetActive(false);
            weapons.SetActive(false);
        }
    }
    public void Right()
    {
        weapons_arr[i].SetActive(false);
        do
        {   
            i++;
            if (i == 6)
                i = 0;
        } while (save_script.w_buy_arr[i] == 0);
        weapons_arr[i].SetActive(true);
        ChekUpgrades();
    }
    public void Left() 
    {
        weapons_arr[i].SetActive(false);
        do
        {
            i--;
            if (i == -1)
                i = 5;
        } while (save_script.w_buy_arr[i] == 0);
        weapons_arr[i].SetActive(true);
        ChekUpgrades();
    }
    public void DamageUpdrade()
    {
        if (script.damage_count[i]<5&&MoneyCount.mon>=prise) 
        {
            MoneyCount.mon -= prise;
            MoneyCount.Save();
            save_script.save_weapon_upgrade = true;
            save_script.Save_task();
            mon_scrript.Save();
            script.damage_count[i] +=1;
            for (int j = 0; j < 5; j++)
            {
                if (j < script.damage_count[i])
                    damage_marking_arr[j].SetActive(true);
                else
                    damage_marking_arr[j].SetActive(false);
            }
            script.damage_arr[i] += 0.25f;
            script.ChangeStats(); 
        }
        buy_menu.SetActive(false);
        ChekUpgrades();
    }
    public void ReloadUpdrade()
    {
        if (script.reload_count[i] < 5 && MoneyCount.mon >= prise)
        {
            MoneyCount.mon -= prise;
            MoneyCount.Save();
            save_script.save_weapon_upgrade = true;
            save_script.Save_task();
            mon_scrript.Save();
            script.reload_count[i] += 1;
            for(int j = 0; j < 5; j++)
            {
                if (j < script.reload_count[i])
                    reload_marking_arr[j].SetActive(true);
                else
                    reload_marking_arr[j].SetActive(false);
            }
            script.reload_arr[i] -= 0.1f;
            script.ChangeStats();
        }
        buy_menu.SetActive(false);
        ChekUpgrades();
    }
    public void AmmunitionUpdrade()
    {
        if (script.ammunition_count[i] < 5 && MoneyCount.mon >= prise)
        {
            MoneyCount.mon -= prise;
            MoneyCount.Save();
            save_script.save_weapon_upgrade = true;
            save_script.Save_task();
            mon_scrript.Save();
            script.ammunition_count[i] += 1;
            for (int j = 0; j < 5; j++)
            {
                if (j < script.ammunition_count[i])
                    ammunition_marking_arr[j].SetActive(true);
                else
                    ammunition_marking_arr[j].SetActive(false);
            }
            script.ammunition_arr[i] += 0.2f;
            script.ChangeStats();
        }
        buy_menu.SetActive(false);
        ChekUpgrades();
    }
    public void Off_Updrade()
    {
        lab = false;
    }
    public void BuyMenuOn()
    {
        if(category==0)
            prise = save_script.w_prise_arr[i] + script.damage_count[i] * save_script.w_prise_arr[i];
        else if (category == 1)
            prise = save_script.w_prise_arr[i] + script.reload_count[i] * save_script.w_prise_arr[i];
        else if (category == 2)
            prise = save_script.w_prise_arr[i] + script.ammunition_count[i] * save_script.w_prise_arr[i];
        buy_menu.SetActive(true);
        text.text = prise.ToString() + "?";
    }
    public void BuyMenuOFF()
    {
        buy_menu.SetActive(false);
    }
    public void Upgrades()
    {
        if (category == 0)
            DamageUpdrade();
        else if (category == 1)
            ReloadUpdrade();
        else if (category == 2)
            AmmunitionUpdrade();
    }
    private bool dam_chek, rel_chek, amm_chek;
    public void ChekUpgrades()
    {
        damage_button.SetActive(true);reload_button.SetActive(true);ammunition_button.SetActive(true);
        dam_chek = false;rel_chek = false;amm_chek = false;
        for (int j = 0; j < 5; j++)
        {
            if (j < script.damage_count[i])
                damage_marking_arr[j].SetActive(true);
            else
            {
                damage_marking_arr[j].SetActive(false);
                if (dam_chek == false)
                {
                    dam_chek = true;
                    damage_button.GetComponent<RectTransform>().anchoredPosition = new Vector2(-30+ 25 * j, damage_button.GetComponent<RectTransform>().anchoredPosition.y);
                }
            }
            if (j < script.reload_count[i])
                reload_marking_arr[j].SetActive(true);
            else
            {
                reload_marking_arr[j].SetActive(false);
                if (rel_chek == false)
                {
                    rel_chek = true;
                    reload_button.GetComponent<RectTransform>().anchoredPosition = new Vector2(-30 + 25 * j, reload_button.GetComponent<RectTransform>().anchoredPosition.y);
                }
            }
            if (j < script.ammunition_count[i])  
                ammunition_marking_arr[j].SetActive(true);
            else
            {
                ammunition_marking_arr[j].SetActive(false);
                if (amm_chek == false)
                {
                    amm_chek = true;
                    ammunition_button.GetComponent<RectTransform>().anchoredPosition = new Vector2(-30 + 25 * j, ammunition_button.GetComponent<RectTransform>().anchoredPosition.y);
                }
            }
        }
        if (dam_chek == false)
            damage_button.SetActive(false);
        if (rel_chek == false)
            reload_button.SetActive(false);
        if (amm_chek == false)
            ammunition_button.SetActive(false);
    }
}
