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
    void Start()
    {
        script= GameObject.Find("spawn_point").GetComponent<spawn>();
        bird_script = GameObject.Find("spawn_point").GetComponent<bird_spawn>();
        i = spawn.wave;
        text = GameObject.Find("Wave_count").GetComponent<Text>();
        MoneyCount = GameObject.Find("Bill").GetComponent<MoneyCount>();
    }
    void Update()
    {
        text.text ="Wave: " +i.ToString();
    }
    public void Right()
    {
        if (i < 21)
            i++;
        spawn.wave = i;
    }
    public void Left()
    {
        if (i >= 1)
            i--;
        spawn.wave = i;
    }
    public void Back()
    {
        script.ChangeChance();
        bird_script.ChangeChance();
        gameObject.SetActive(false);
    }
    public void Money()
    {
        MoneyCount.mon += 500;
        MoneyCount.Save();
    }
}
