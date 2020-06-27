using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_UP : MonoBehaviour
{
    public bool canMove = true;


    public void Finish()
    {
        FindObjectOfType<AudioManager_UP>().Play("beatbox");
        canMove = false;
        Invoke("WinUltimatePaint", 1f);
        StartCoroutine(finish_delay());
    }

    public void Fail()
    {
        canMove = false;
        Invoke("LoseUltimatePaint", 1f);
        StartCoroutine(failed_delay());
    }

    IEnumerator finish_delay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator failed_delay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
