using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wave_choice : MonoBehaviour
{
    public Text text;
    public int i;
    private spawn script;
    private bird_spawn bird_script;
    private MoneyCount MoneyCount;
    private Save save;
    void Start()
    {
        script= GameObject.Find("spawn_point").GetComponent<spawn>();
        bird_script = GameObject.Find("spawn_point").GetComponent<bird_spawn>();
        text = GameObject.Find("Wave_count").GetComponent<Text>();
        MoneyCount = GameObject.Find("Bill").GetComponent<MoneyCount>();
        save = GameObject.Find("save").GetComponent<Save>();
        i = save.save_wave;
    }
    void Update()
    {
        text.text ="Wave: " +i.ToString();
    }
    public void Right()
    {
        if (i < 21)
            i++;
        save.save_wave = i;
    }
    public void Left()
    {
        if (i >= 1)
            i--;
        save.save_wave = i;
    }
    public void Back()
    {
        save.Save_progress();
        script.ChangeChance();
        bird_script.ChangeChance();
        gameObject.SetActive(false);
    }
    public void Money()
    {
        MoneyCount.flesh[0] += 50;
        MoneyCount.flesh[1] += 30;
        MoneyCount.flesh[2] += 20;
        MoneyCount.Save();
    }
}
