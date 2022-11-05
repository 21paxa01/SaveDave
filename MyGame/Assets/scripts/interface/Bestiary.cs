using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bestiary : MonoBehaviour
{
    public GameObject bobo;
    public GameObject bibo;
    public GameObject bo;
    public GameObject karl;
    public GameObject bird;
    public GameObject lara;
    public GameObject martin;
    public GameObject mike;
    public GameObject richard;
    public GameObject boom_bird;
    public GameObject gru;
    public GameObject giovanni;
    public GameObject[] cells_arr;
    public GameObject cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9, cell_10;
    public int i;
    public int j;
    private GameObject[] zombies;
    public GameObject Bestiary_menu;
    public bool[] chek = { false, false, false, false, false, false, false, false,false,false };
    private string[] zomb_info = { "An unremarkable wandering zombie. First on your way.", "Carl doesn't like to be alone. He is always drawn to people.", "This bird doesn’t remember either his bird family or the nest. It is interested in one thing - to shred!", "What could be more dangerous than a zombie chef? Only zombie chef with exploding pies!", "In ordinary life, Bibo bothered everyone with his character. No wonder this zombie can do harm even after his death.", "Apparently this bird has a lot in common with Martin, only it is also faster!", "This woman should beware. Lara spews poisonous projectiles over long distances. Getting close to her is a big problem!", "The only zombie that won't hurt you. His magical music gives zombies life and inspiration.", "As a doctor, Richard always thought that people misused the defibrillator. Now he uses it for its intended purpose.", "He's bringing you a gift, why are you shooting at him?!", "Why can't bullets pierce a ordinary door? We don't know the answer. Try to attack from the other side.", "Bo loves boxing. He doesn't care that no one can survive his punch." };
    private int[] speed_info = { 3, 2, 4, 3, 5, 4, 1, 4, 3, 2, 3,2 }, power_info = { 4, 1, 5, 3, 2, 3, 4, 1, 3, 2, 5,3 }, health_info = { 3, 3, 2,4, 5, 1, 4, 3, 2, 3, 5,4 };
    public GameObject info;
    private Text info_text;
    public int zomb_kol;
    public GameObject up, down;
    public Sprite[] icons_img;
    public Sprite bobo_sprite, karl_sprite, bird_sprite, gru_sprite, bibo_sprite,boom_bird_sprite, lara_sprite, richard_sprite, martin_sprite, mike_sprite, bo_sprite,giovanni_sprite;
    public GameObject[] speed_arr, power_arr,health_arr;
    public GameObject speed_1, speed_2, speed_3, speed_4, speed_5, power_1, power_2, power_3, power_4, power_5, health_1, health_2, health_3, health_4, health_5;
    public string[] names = {"Bobo", "Karl", "Bird", "Gru", "Bibo", "Boom_bird", "Lara", "Giovanni", "Richard", "Martin", "Mike", "Bo" };
    public Text name;
    public bool cell_anim;
    void Start()
    {
        i = 0;
        j = 0;
        zombies = new GameObject[12];
        zombies[0] = bobo; zombies[1] = karl; zombies[2] = bird; zombies[3] = gru; zombies[4] = bibo;zombies[5] = boom_bird; zombies[6] = lara; zombies[7] = giovanni; zombies[8] = richard; zombies[9] = martin; zombies[10] = mike; zombies[11] = bo;
        icons_img = new Sprite[12];
        icons_img[0]=bobo_sprite; icons_img[1]=karl_sprite; icons_img[2]=bird_sprite; icons_img[3]=gru_sprite; icons_img[4]=bibo_sprite;icons_img[5] = boom_bird_sprite; icons_img[6]=lara_sprite;icons_img[7] = giovanni_sprite; icons_img[8]=richard_sprite; icons_img[9]=martin_sprite; icons_img[10]=mike_sprite; icons_img[11]=bo_sprite;
        info_text = info.GetComponent<Text>();
        cells_arr = new GameObject[10];
        cells_arr[0] = cell_1; cells_arr[1] = cell_2; cells_arr[2] = cell_3; cells_arr[3] = cell_4; cells_arr[4] = cell_5; cells_arr[5] = cell_6; cells_arr[6] = cell_7; cells_arr[7] = cell_8; cells_arr[8] = cell_9; cells_arr[9] = cell_10;
        speed_arr = new GameObject[5]; power_arr = new GameObject[5]; health_arr = new GameObject[5];
        speed_arr[0] = speed_1; speed_arr[1] = speed_2; speed_arr[2] = speed_3; speed_arr[3] = speed_4; speed_arr[4] = speed_5;power_arr[0] = power_1; power_arr[1] = power_2; power_arr[2] = power_3; power_arr[3] = power_4; power_arr[4] = power_5;health_arr[0] = health_1; health_arr[1] = health_2; health_arr[2] = health_3; health_arr[3] = health_4; health_arr[4] = health_5;
        Zombie_ON();
        ChangeStats();
    }

    
    void Update()
    {
        if (j == 0)
            up.SetActive(false);
        else
            up.SetActive(true);
        if (j == zomb_kol-1)
            down.SetActive(false);
        else
            down.SetActive(true);
    }
    public void Zombie_ON()
    {
        zombies[i].SetActive(true);
        info_text.text = zomb_info[i];
    }
    public void Zombie_OFF()
    {
        for (int k = 0; k < zomb_kol; k++)
            zombies[k].SetActive(false);
        info_text.text = "";
    }
    public void right()
    {
        if (i < 5&&chek[i+2]==true)
            i++;
    }
    public void left()
    {
        if (i > 0)
            i--;
    }
    public void Menu_ON()
    {
        Bestiary_menu.SetActive(true);
        cell_anim = true;
        StartCoroutine(Cell_animation());
    }
    public void Menu_OFF()
    {
        Bestiary_menu.SetActive(false);
        cell_anim = false;
    }
    public void Chek_zombies()
    {
        for (int k = 0; k < 3; k++)
        {
            chek[k] = true;
            cells_arr[k].SetActive(true);
        }
    }
    public void UP()
    {
        j--;
    }
    public void DOWN()
    {
        j++;
    }
    public void ChangeStats()
    {
        for(int k = 0; k < 5; k++)
        {
            if(speed_info[i]<k+1)
                speed_arr[k].SetActive(false);
            else
                speed_arr[k].SetActive(true);
            if (power_info[i] < k + 1)
                power_arr[k].SetActive(false);
            else
                power_arr[k].SetActive(true);
            if (health_info[i] < k + 1)
                health_arr[k].SetActive(false);
            else
                health_arr[k].SetActive(true);
        }
        name.text = names[i];
    }
    public int cell_ind;
    public int cell_ind_chek;
    IEnumerator Cell_animation()
    {
        //cell_chek = 0;
        while (cell_anim == true)
        {
            do
            {
                cell_ind = Random.Range(1, 4);
            } while (cell_ind == cell_ind_chek);
            cell_ind_chek = cell_ind;
            yield return new WaitForSecondsRealtime(0.5f);
            cell_ind = -1;
            yield return new WaitForSecondsRealtime(3f);
        }
    }
}
