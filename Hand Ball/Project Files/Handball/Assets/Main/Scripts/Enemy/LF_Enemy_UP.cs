using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LF_Enemy_UP : MonoBehaviour
{
    public Transform[] movePoints;
    private int randomPoints;

    private float enemySpeed = 4;

    private float waitTime;
    public float startWaitTime;

    Animator anim;
    public GameObject fakeBullet;

    void Start()
    {
        waitTime = startWaitTime;
        randomPoints = 0;

        anim = GetComponent<Animator>();
        fakeBullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoints[randomPoints].position, enemySpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoints[randomPoints].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomPoints = Random.Range(0, movePoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        anim.SetBool("step", true);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "UltimatePaint_Bullet")
        {
            enemySpeed = 0;
            anim.SetBool("catch", true);
            fakeBullet.SetActive(true);
        }
    }
}
