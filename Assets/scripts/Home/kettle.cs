using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kettle : MonoBehaviour
{
    public GameObject Bill;
    private float distToPlayer;
    public Animator anim;
    public float test;
    public AudioSource chainik,plita;
    private bool chek;
    void Start()
    {
        Bill = GameObject.Find("Bill");
        anim = GetComponent<Animator>();
        chek = false;
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, Bill.transform.position);
        test = distToPlayer;
        if (distToPlayer < 0.3f)
        {
            anim.SetBool("fire", true);
            if (chek == false)
            {
                chek = true;
                StartCoroutine(Audio());
            }
        }
    }
    IEnumerator Audio()
    {
        plita.Play();
        yield return new WaitForSeconds(3.5f);
        chainik.Play();
    }
    public void Stop()
    {
        plita.Stop();
        chainik.Stop();
        chek = false;
    }
}
