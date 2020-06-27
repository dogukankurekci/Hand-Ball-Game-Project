using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Enemy_UP : MonoBehaviour
{
    Animator anim;
    public GameObject fakeBullet;

    void Start()
    {
        anim = GetComponent<Animator>();
        fakeBullet.SetActive(false);


    }


    void Update()
    {
        anim.SetBool("idle", true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "UltimatePaint_Bullet")
        {
            anim.SetBool("catch", true);
            fakeBullet.SetActive(true);
        }
    }
    
}
