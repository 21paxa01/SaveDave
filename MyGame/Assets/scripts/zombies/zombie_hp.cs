using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombie_hp : MonoBehaviour
{
    public Image bar;
    public Image back;
    public float fill;
    public bool stop;

    public Animator anim;
    public float death_time;
    public bool death;
    public SpriteRenderer sp;
    public Rigidbody2D rb;
    public Save save_script;
    private bool new_weap;
    private spawn spawn_script;
    public GameObject drawing;
    public Transform money_spawn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fill = 1f;
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        save_script = GameObject.Find("save").GetComponent<Save>();
        spawn_script = GameObject.Find("spawn_point").GetComponent<spawn>();
        if (spawn_script.last == true)
            new_weap = true;
    }

    
    void Update()
    {
        bar.fillAmount = fill;
        if (hp >= HP&&death==false)
        {
            death = true;
            StartCoroutine(Die());
        }
    }
    public float HP;
    public float hp = 0;

    public bool bird;
    IEnumerator Die()
    {
        sp.sortingOrder = 8;
        spawn.zombie_kol--;
        save_script.save_killed_zombies++;
        save_script.Save_task();
        anim.SetBool("death", death);
        Destroy(back);
        if (spawn_script.last == true&& spawn.zombie_kol==0&&bird==false)
        {
            if (save_script.save_wave == 1 || save_script.save_wave == 2 || save_script.save_wave == 3 || save_script.save_wave == 5)
                Instantiate(drawing, money_spawn.position, transform.rotation);
        }
        yield return new WaitForSeconds(death_time);
        Destroy(gameObject);
        hp = 0;
    }
    public int kef;
    public float disc_time;
    IEnumerator Discard()
    {
        stop = true;
        rb.velocity = new Vector2(kef * 1, 0f);
        yield return new WaitForSeconds(disc_time);
        stop = false;
    }
    public void discard()
    {
        StartCoroutine(Discard());
    }
}