using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            spriteRenderer.enabled = false;
        }
    }
}
