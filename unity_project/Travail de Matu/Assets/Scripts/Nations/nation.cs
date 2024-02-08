using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class nation : MonoBehaviour
{
    ///// VARIABLES /////
    
    // GENERAL INFO //

    public string nationName;
    public string nationDescription;
    public Sprite flag;
    
    // RESSOURCES //

    public float money = 50f;
    public float food = 50f;

    // REVENUES //

    public float moneyRevenue;
    public float foodRevenue;

    // BOOLEANS //

    public bool isPlayer;

    // LISTS //

    public List<GameObject> citiesList = new List<GameObject>();
    public List<GameObject> unitsList = new List<GameObject>();

    // OBJECTS //
    
    public GameObject unitSelect;
    public GameObject citySelect; 

    public AudioSource coinSound;

    [SerializeField] 
    private Text _moneyDisplay;
    [SerializeField] 
    private Text _foodDisplay;


    ///// FUNCTIONS /////

    IEnumerator Start() {
        brain.Instance.nationsList.Add(this.gameObject);

        yield return new WaitForEndOfFrame(); // Wait one frame forthat the unitList is already created

        foreach(var unit in unitSelect.GetComponent<unitSelections>().unitList) { // Add unity of same tag
            if(unit.gameObject.tag == gameObject.tag) {
               unitsList.Add(unit.gameObject);
            } 
        }

        foreach(var city in citySelect.GetComponent<citySelections>().cityList) { // Add city of same tag
            if(city.gameObject.tag == gameObject.tag) {
               citiesList.Add(city.gameObject);
            } 
        }
    }

    public void updateValue() {
        money += moneyRevenue;
        food += foodRevenue;

        Debug.Log(nationName+" : "+money+" , "+food);
    }

    public void display() {

        string moneyDis = money.ToString();
        string foodDis = food.ToString();

        _moneyDisplay.text = moneyDis;
        _foodDisplay.text = foodDis;

        coinSound.Play();


    }

}
