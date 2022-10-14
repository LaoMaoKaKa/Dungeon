using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float jumpValue = 2.3f;
    private new Rigidbody2D rigidbody2D;
    private int hp = 100;
    private Animator animator;
    public GameObject jumpEffect;
    public GameObject deathSoundObj;
    void Start()
    {
        animator=transform.GetComponent<Animator>();
        GameManger.Instance.SetCurPoint(Vector2.right);
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManger.Instance.GetDeathState()==true) {
            return;
        }
        Move();
    }

    void Move() {
        if (Input.GetKey(KeyCode.X) &&(Input.GetKey(KeyCode.LeftArrow)==false&& Input.GetKey(KeyCode.RightArrow) == false))
        {
            if (GameManger.Instance.GetCurPoint() == Vector2.left)
            {
                rigidbody2D.AddForce(Vector2.right * 5f);
            }
            else {
                rigidbody2D.AddForce(Vector2.left * 5f);
            }

            rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -0.1f, 0.1f), Mathf.Clamp(rigidbody2D.velocity.y, -10f, 10f));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump(false);
        }

        if (Input.GetKey(KeyCode.LeftArrow)&& Input.GetKey(KeyCode.RightArrow)==false)
        {
            if (GameManger.Instance.GetIsTriggerEnterFront() == true&& GameManger.Instance.GetCurPoint()==Vector2.left) {
                rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, 0f, 0f), Mathf.Clamp(rigidbody2D.velocity.y, -10f, 10f));
                return;
            }
            Turn(Vector2.left);
            rigidbody2D.AddForce(Vector2.left*5f);
            rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -1.3f, 1.3f), Mathf.Clamp(rigidbody2D.velocity.y, -10f, 10f));
        }
        else if (Input.GetKey(KeyCode.RightArrow)&& Input.GetKey(KeyCode.LeftArrow)==false)
        {
            if (GameManger.Instance.GetIsTriggerEnterFront() == true && GameManger.Instance.GetCurPoint() == Vector2.right)
            {
                rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, 0f, 0f), Mathf.Clamp(rigidbody2D.velocity.y, -10f, 10f));
                return;
            }
            Turn(Vector2.right);
            rigidbody2D.AddForce(Vector2.right*5f);
            rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -1.3f, 1.3f),Mathf.Clamp(rigidbody2D.velocity.y, -10f, 10f));
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)|| Input.GetKeyUp(KeyCode.RightArrow)) {
            rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, 0f, 0f), Mathf.Clamp(rigidbody2D.velocity.y, -10f, 10f));
        }

        if (Input.GetKey(KeyCode.LeftArrow)==false && Input.GetKey(KeyCode.RightArrow)==false)
        {
            if (GameManger.Instance.GetJumpState() == true)
            {
                return;
            }
            else {
                animator.SetBool("isWalk",false);
            }
        }
    }

   public  void Jump(bool isFore)
    {
        if (GameManger.Instance.GetJumpState() == true && isFore==false) {
            return;
        }
        if (isFore) {
            rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -5f, 5f), 0);
        }
        animator.SetTrigger("jump");
        GameObject obj= Instantiate<GameObject>(jumpEffect, transform);
        obj.transform.SetParent(transform.parent);
        obj.SetActive(true);
        rigidbody2D.AddForce(Vector2.up*jumpValue, ForceMode2D.Impulse);
        GameManger.Instance.SetJumpState(true);
    }

    void Turn(Vector2 point) {
        animator.SetBool("isWalk", true);
        if (Input.GetKey(KeyCode.X))
        {
            return;
        }
        float y = 0;
        if (point==Vector2.left) {
            y = 180;
        }
        GameManger.Instance.SetCurPoint(point);
        transform.rotation = Quaternion.Euler(0, y, 0);
    }

    public void Hurt(int value) {
        if (GameManger.Instance.GetDeathState() == true) {
            return;
        }
        hp -= value;
        if (hp <= 0) {
            Death();
        }
    }

    void Death() {
        Time.timeScale = 0.5f;
        GameManger.Instance.SetDeathState(true);
        animator.SetBool("isDeath", true);
        gameObject.layer = 9;
        deathSoundObj.SetActive(true);
        Destroy(transform.Find("Foot").gameObject);
        transform.Find("Gen").GetComponent<Gen>().enabled=false;
        rigidbody2D.velocity = new Vector2(0,0);

        float x = Random.Range(-50, -70);
        float y = Random.Range(80, 120);
        if (GameManger.Instance.GetCurPoint() == Vector2.left)
        {
            x = -x;
        }

        rigidbody2D.AddForce(new Vector2(x, y));

        transform.GetComponent<Player>().enabled = false;
    }
}
