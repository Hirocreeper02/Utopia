using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioSource clickSound;
    
    public void audioClick()
    {
        clickSound.Play();
    }

}
