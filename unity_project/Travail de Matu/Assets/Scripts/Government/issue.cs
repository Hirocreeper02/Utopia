using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class issue : MonoBehaviour
{
    
    smartspider smartspider;
    
    void initialisation()
    {
        smartspider.addIssue(this);
    }
}
