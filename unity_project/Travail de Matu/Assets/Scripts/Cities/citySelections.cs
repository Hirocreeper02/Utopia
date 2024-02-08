using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class citySelections : MonoBehaviour
{
    public List<GameObject> cityList = new List<GameObject>();
    public List<GameObject> citySelected = new List<GameObject>();

    public GameObject mastermind;
    public GameObject cityInfoWindow;

    [SerializeField] 
    private Text _cityInfoName;
    [SerializeField] 
    private Text _cityInfoText;

    private static citySelections _instance;
    public static citySelections Instance { get { return _instance; }} //Complex but let's hope it's not that important [HC]

    //void Start() {
    //    deselectAll();
    //}

    private void Awake() {
        //If an Instnce of this already exists, and it isn't this one... [HC]
        if (_instance != null && _instance != this) {
            //... we destroy this instance... [HC]
            Destroy(this.gameObject);
        } else {
            //...otherwise make this the instance [HC]
            _instance = this;
        }
    }

    public void clickSelect(GameObject cityToAdd) {

        deselectAll();
        citySelected.Add(cityToAdd);

        openWindow();

    }

    public void deselectAll() { //Pretty self explanatory [HC]

        foreach (var city in citySelected) {
            city.transform.GetChild(0).gameObject.SetActive(false);
        }
        citySelected.Clear();
        openWindow();
        mastermind.GetComponent<soundManager>().audioClick();

    }

    public void deselect(GameObject cityToDeselect) { //Deselect a specific city [HC]

    }

    void openWindow() {

        if(citySelected.Count == 1) {
            city nameScript = citySelected[0].GetComponent<city>();
            string name = nameScript.cityName;
            string infos = ("Damage:"+"\n"+"Manpower:");

            Debug.Log(name);

            cityInfoWindow.SetActive(true);

            _cityInfoName.text = name;
            _cityInfoText.text = infos;

        } else {
            cityInfoWindow.SetActive(false);
        }

    }

}
