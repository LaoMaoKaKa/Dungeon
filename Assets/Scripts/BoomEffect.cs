using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private int aggressivity = 80;
    public CircleCollider2D collider2D;
    private float stopTime = 0.05f;
    private bool isStartStop=false;
    private bool isStopOVer=false;
    void Start()
    {
        
    }

    void Update()
    {
        if (isStartStop==true&& isStopOVer==false) {
            stopTime-=Time.deltaTime*100;
            if (stopTime <= 0) {
                isStopOVer = true;
                Time.timeScale = 1;
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5 && isStartStop==false) {
            Time.timeScale = 0.01f;
            isStartStop =true;
        }
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            spriteRenderer.enabled = false;
            collider2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Hurt(aggressivity);
        }
    }
}
