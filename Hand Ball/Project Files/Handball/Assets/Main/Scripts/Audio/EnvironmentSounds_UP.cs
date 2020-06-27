using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSounds_UP : MonoBehaviour
{
    // Start is called before the first frame update


    void shootPlay()
    {
        FindObjectOfType<AudioManager_UP>().Play("throwing");
    }
    void shootStop()
    {
        FindObjectOfType<AudioManager_UP>().Stop("throwing");
    }


}
