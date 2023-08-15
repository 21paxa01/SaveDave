using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    public Animator anim;
    public float damage;
    public Joystick joystick;
    private int offset;
    public int const_change;
    public bool attack;
    private Rigidbody2D rb;
    public float speed;
    public bool right;
    public bool left;
    public float rotateZ;
    private zombie_hp script;
    public Transform bill;
    public Collider2D coll;
    private bool test;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
    public bool inventory;
    void Update()
    {
        if (change_weapon.change == const_change&&inventory==false)
        {
            rotateZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
            transform.position = new Vector3(bill.position.x + 0.034f, bill.position.y + 0.124f, bill.position.z);

            Vector3 LocalScale = Vector3.one;
            if (rotateZ < 90 && rotateZ > -90)
            {
                LocalScale.y = 1f;
                right = true;left = false;
            }
            else
            {
                LocalScale.y = -1f;
                right = false;left = true;
            }
            transform.localScale = LocalScale;
            if (joystick.Vertical != 0 && joystick.Horizontal != 0)
            {
                attack = true;
            }
        }
        if (joystick.Vertical == 0 && joystick.Horizontal == 0&&inventory==false)
        {
            transform.localRotation = Quaternion.Euler(0, 0, rotateZ);
            attack = false;
        }
        anim.SetBool("attack", attack);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("zombie"))
        {
            script = other.gameObject.GetComponent<zombie_hp>();
            if (right == true) script.kef = 1;
            else script.kef = -1;
            if (test == false)
            {
                if (script.death == false)
                {
                    test = true;
                    script.discard();
                    if (script.hp + damage > script.HP)
                    {
                        script.hp = script.HP;
                    }
                    else
                        script.hp += damage;
                    script.fill = 1 - script.hp / script.HP;
                    //test = false;
                }
            }
        }
    }
    public void Attack()
    {
        if (change_weapon.change == const_change)
        {
            attack = true;
            StartCoroutine(ATTACK());
        }
    }
    IEnumerator ATTACK()
    {
        yield return new WaitForSeconds(0.13333333f);
        while (attack == true)
        {
            yield return new WaitForSeconds(0.26666f);
            test = false;
        }
    }
}
