using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engel_UP : MonoBehaviour
{

    public GameManager_UP gameManager_UP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UltimatePaint_Bullet")
        {
            Debug.Log("sa");
            FindObjectOfType<AudioManager_UP>().Play("impact");
            gameManager_UP.Fail();
        }


    }
}
