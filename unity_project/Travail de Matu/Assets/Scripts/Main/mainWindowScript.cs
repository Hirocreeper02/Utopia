using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainWindowScript : MonoBehaviour
{
    public GameObject mainWindow;

    public void openWindow() {

        mainWindow.SetActive(true);

    }

    public void closeWindow() {

        mainWindow.SetActive(false);

    }
}
