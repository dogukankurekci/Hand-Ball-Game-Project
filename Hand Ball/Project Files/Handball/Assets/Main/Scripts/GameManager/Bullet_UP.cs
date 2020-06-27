using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_UP : MonoBehaviour
{
    public GameManager_UP gameManager_UP;

    public MeshRenderer meshRenderer;

    public GameObject[] environmenParticle;

    public Transform bulletTransform;



    private void Start()
    {
        bulletTransform = GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "UltimatePaint_Engel")
        {
            FindObjectOfType<AudioManager_UP>().Play("impact");
            gameManager_UP.Fail();
            environmenParticle[0].SetActive(true);
            Camera.main.GetComponent<cameraFollow_UP>().target[2] = new Vector3(bulletTransform.position.x, 10, bulletTransform.position.z - 5);
            Camera.main.GetComponent<cameraFollow_UP>().transform.LookAt(bulletTransform);
            Camera.main.GetComponent<cameraFollow_UP>().zoomTarget = true;

        }

        if (collision.gameObject.tag == "UltimatePaint_Enemy")
        {
            meshRenderer.enabled = false;
            gameManager_UP.Fail();
            environmenParticle[1].SetActive(true);
            Camera.main.GetComponent<cameraFollow_UP>().target[2] = new Vector3(bulletTransform.position.x , 10, bulletTransform.position.z - 5);
            Camera.main.GetComponent<cameraFollow_UP>().zoomTarget = true;

            FindObjectOfType<AudioManager_UP>().Play("poof");
        }

    }
}
