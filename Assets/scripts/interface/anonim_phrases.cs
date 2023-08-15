using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anonim_phrases : MonoBehaviour
{
    public Text text;
    public int i;
    public int l;
    public GameObject computer_menu;
    public int inventory = 0;
    public bool  first_wave=true;
    public GameObject right;
    public GameObject left;
    private bool stop = false;
    private string[] inventory_phrases = { "Welcome to inventory! On the left you see all the weapons available to you. To take them with you on a mission, drag the desired weapon from the window on the left to the right window."," Remember that you can take a limited amount of equipment on a mission." };
    private string[] first_phrases = { "HI Bill! Welcome to your new home. I'm here to increase your chances of survival. You don't need to know my name. There are many infected outside. Your task is to clear the area around the base from zombies.", "If you do well, you can earn money for new weapons or costumes. Learn more about it in the shop. Weapons can also be upgraded, ask the mechanic about it. Well, maybe you'll have better luck than the previous occupants of this room. See you!" };
    private string[] random_phrases = { "If you want to know more about the zombies you encountered, then you can find detailed information in the bestiary in the settings." };
    private string[] training_phrases = {"joustik_1", "joustik_2", "hp", "flesh count","weapon cell","grenage cell","now weapon","wave","pause" };
    private typewriter script;
    private Save save;
    void Start()
    {
        i = 0;
        text = GetComponent<Text>();
        script = GetComponent<typewriter>();
        save = GameObject.Find("save").GetComponent<Save>();
    }

    void Update()
    {
        if (stop == false)
        {
            if (save.training_phrases == true&& save.training == true)
            {
                l = 8;
                script.text = training_phrases[i];
                script.StartType();
            }
            else if (inventory == 1)
            {
                l = 1;
                script.text = inventory_phrases[i];
                script.StartType();
            }
            else if (save.training==true&&inventory!=1)
            {
                l = 1;
                script.text = first_phrases[i];
                script.StartType();
            }
            else
            {
                l = 0;
                script.text = random_phrases[i];
                script.StartType();
            }
        }
        if (i == 0)
            left.SetActive(false);
        else
            left.SetActive(true);
        if(i==l)
            right.SetActive(false);
        else
            right.SetActive(true);
    }
    public void Right()
    {
        script.chek = false;
        //script.StartType();
        if (i==l)
            i = 0;
        else
            i++;
    }
    public void Left()
    {
        script.chek = false;
        //script.StartType();
        if (i == 0)
            i = l;
        else
            i--;
    }
    public void Inventory()
    {
        save = GameObject.Find("save").GetComponent<Save>();
        if (save.training == true&&inventory==0)
        {
            inventory = 1;
            i = 0;
            computer_menu.SetActive(true);
            //script.chek = false;
        }
    }
    public void Inventory_OFF()
    {
        stop = false;
        script.chek = false;
        if (inventory > 0 && inventory < 2)
            inventory=2;
    }
}
