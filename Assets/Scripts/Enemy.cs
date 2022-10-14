using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 curPoint = Vector2.left;
    private bool isDeath=false;
    private int aggressivity = 100;
    private int hp = 100;
    private float moveSpeed = 0.8f;
    private Vector3 movePoint ;
    private Animator animator;
    public GameObject BoomEffect;
    public Rigidbody2D rigidbody2D;
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        movePoint = -transform.right;
    }

    void Update()
    {
        if (isDeath)
        {
            return;
        }
        Move();
    }

    void Move() {
        transform.position += movePoint * moveSpeed * Time.deltaTime;
    }


   public  void Turn()
    {
        if (curPoint==Vector2.left)
        {
            movePoint = transform.right;
            curPoint = Vector2.right;
        }
        else { 
            movePoint = -transform.right;
            curPoint = Vector2.left;
        }
    }

    // ‹…À
    public void Hurt(int value) {
        hp -= value;

        if (hp <= 0)
        {
            Death();
        }
        else {
            animator.SetTrigger("Hurt");
        }
    }

    // ‹…À
    public void Hurt(int value,Vector2 vector)
    {
        hp -= value;

        if (hp <= 0)
        {
            Death(vector);
        }
        else
        {
            animator.SetTrigger("Hurt");
        }
    }

    public void Death()
    {
        animator.SetBool("isDeath", true);
        transform.GetComponent<Enemy>().enabled = false;
        gameObject.layer = 9;
        isDeath =true;
        if (Random.Range(1, 10)>6) {
           GameObject obj=  Instantiate<GameObject>(BoomEffect, transform);
            obj.transform.parent = transform.parent;
        }

        float x = Random.Range(-20, -40);
        float y = Random.Range(40, 60);
        if (curPoint == Vector2.left)
        {
            x = -x;
        }
        rigidbody2D.velocity = new Vector2(0,0);
        rigidbody2D.AddForce(new Vector2(x, y));
    }

    public void Death(Vector2 vector)
    {
        animator.SetBool("isDeath", true);
        transform.GetComponent<Enemy>().enabled = false;
        gameObject.layer = 9;
        isDeath = true;
        if (Random.Range(1, 10) > 6)
        {
            GameObject obj = Instantiate<GameObject>(BoomEffect, transform);
            obj.transform.parent = transform.parent;
        }

        float x = Random.Range(-20, -40);
        float y = Random.Range(40, 60);
        if (vector == Vector2.right)
        {
            x = -x;
        }
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.AddForce(new Vector2(x, y));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.tag == "Player")
        {
            if (isDeath) {
                return;
            }
            collision.transform.GetComponent<Player>().Hurt(aggressivity);
        }
    }

}
