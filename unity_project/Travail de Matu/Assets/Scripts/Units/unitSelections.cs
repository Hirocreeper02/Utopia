using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class unitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    public GameObject unitInfoWindow;

    [SerializeField] 
    private Text _unitInfoName;
    [SerializeField] 
    private Text _unitInfoText;

    private static unitSelections _instance;
    public static unitSelections Instance { get { return _instance; }} //Complex but let's hope it's not that important [HC]

    void Start() {

        foreach (var unit in unitSelections.Instance.unitList) { 
            shiftClickSelect(unit);
        }
        deselectAll(); // Select all Units and deselect to solve an strange bug
    }

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

    public void clickSelect(GameObject unitToAdd) {

        deselectAll();
        unitSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<unitMovement>().enabled = true;

        openWindow();

    }

    public void shiftClickSelect(GameObject unitToAdd) { //Select multiple units while maintaining shift [HC]
        
        if (!unitSelected.Contains(unitToAdd)) {

            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<unitMovement>().enabled = true;

        } else {
            
            unitToAdd.GetComponent<unitMovement>().enabled = false;
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitSelected.Remove(unitToAdd);

        }
    }

    public void dragSelect(GameObject unitToAdd) { //Select multiple units like on windows desktop [HC]

        if(!unitSelected.Contains(unitToAdd)) {
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<unitMovement>().enabled = true;

            openWindow();
        }
        
    }

    public void deselectAll() { //Pretty self explanatory [HC]

        foreach (var unit in unitSelected) {
            unit.GetComponent<unitMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        unitSelected.Clear();
        openWindow();

    }

    public void deselect(GameObject unitToDeselect) { //Deselect a specific unit [HC]

    }

    void openWindow() {

        if(unitSelected.Count == 1) {
            unit nameScript = unitSelected[0].GetComponent<unit>();
            float dmgTot = (nameScript.dmgR + nameScript.dmgI + nameScript.dmgC);
            float manTot = (nameScript.manR + nameScript.manI + nameScript.manC);
            string name = ("Army - "+nameScript.unitName);
            string infos = ("Damage:"+dmgTot+"\n"+"Manpower:"+manTot);

            Debug.Log(name);

            unitInfoWindow.SetActive(true);

            _unitInfoName.text = name;
            _unitInfoText.text = infos;
        } else {
            unitInfoWindow.SetActive(false);
        }

    }

}
