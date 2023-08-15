using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flesh : MonoBehaviour
{
    public Rigidbody2D rb;
    public int test = 0;
    public Animator anim;
    public Collider2D coll;
    public MoneyCount script;
    private MoneyMagnet magnet_script;
    public bool money;
    public int i;
    void Start()
    {
        script = GameObject.Find("Bill").GetComponent<MoneyCount>();
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        magnet_script = GetComponent<MoneyMagnet>();
        Invoke("start_die", 5f);
    }
    void Update()
    {
        if(transform.position.y<= -3.011614f&&money==false)
        {
            anim.SetBool("drop", true);
            transform.position = new Vector3(transform.position.x, -3.011614f, transform.position.z);
            rb.gravityScale = 0f;
        }
        if (transform.position.y <= -11.515f && money == true)
        {
            anim.SetBool("drop", true);
            transform.position = new Vector3(transform.position.x, -11.515f, transform.position.z);
            rb.gravityScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (money == false)
            {
                script.flesh[i]++;
            }
            else
            {
                script.mon++;
            }
            script.Save();
        }        
    }
    private int testik = 0;
    void Drop()
    {
        if (testik == 0)
        {
            rb.gravityScale = 0f;
            testik++;
        }
    }
    private void start_die()
    {
        StartCoroutine(Die());
    }
   IEnumerator Die()
    {
        for(float i = 0; i < 50; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f - i / 100);
            yield return new WaitForSeconds(0.04f);
        }
        for (int i = 0; i < 10; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
    
}
