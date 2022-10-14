using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject effect;
    private float effectRemoveTime = 0.05f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (effectRemoveTime > 0) {
            effectRemoveTime = effectRemoveTime - Time.deltaTime;
        }
        else
        {
            EnableEffect(false);
        }
    }

    void EnableEffect(bool state) {
        effect.SetActive(state);
        if (state == true) {
            effectRemoveTime = 0.05f;
        }
    }
 
}
