using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class brain : MonoBehaviour
{      

    public class Country {

        public string name { get; set; }

        public float money { get; set; }
        public float food { get; set; }

        public float moneyPlus { get; set; }
        public float foodPlus  { get; set; }

        //public string name { get { return name; } set { name = value; } }
        //public float money { get { return money; } set { money = value; } }
        //public float food { get { return food; } set { food = value; } }
        //public float moneyPlus { get { return moneyPlus; } set { moneyPlus = value; } }
        //public float foodPlus { get { return foodPlus; } set { money = foodPlus; } }

    }

    public float time;
    public float totalTime;
    public float timeSec = 2.0f;
    public float timeSpeed = 1.0f;


    [SerializeField] 
    private Text _moneyDisplay;
    [SerializeField] 
    private Text _foodDisplay;
    [SerializeField] 
    private Text _timeDisplay;

    public List<GameObject> nationsList = new List<GameObject>();

    private static brain _instance;
    public static brain Instance { get { return _instance; }} //Complex but let's hope it's not that important

     /////////////
    /// SETUP ///
   /////////////

    // Start is called before the first frame update
    void Start() {
        Debug.Log("========== NEW TAKE ===========");
    }

    private void Awake() {
        //If an Instance of this already exists, and it isn't this one... 
        if (_instance != null && _instance != this) {
            //... we destroy this instance... [HC]
            Destroy(this.gameObject);
        } else {
            //...otherwise make this the instance
            _instance = this;
        }
    }

     //////////////////////////////
    /// PASSIVE GAME MECHANICS ///
   //////////////////////////////

    public void Update() {

        totalTime += Time.deltaTime;

        if(totalTime >= timeSec) {
            
            totalTime = 0;
            time += timeSpeed;
            Debug.Log("======= "+time+" =======");

            // VALUES UPDATE //
            
            foreach (var nation in nationsList) { 
                nation.gameObject.GetComponent<nation>().updateValue();
                if(nation.gameObject.GetComponent<nation>().isPlayer) {
                    nation.gameObject.GetComponent<nation>().display();
                }
            }

        }

    }
    
     ////////////////////////
    /// COMBAT MECHANICS ///
   ////////////////////////

    public void Combat(unit defender, unit attacker) {

        // Save the Manpower Values to Return part of Them at End of Battle //

        float attOriginalManR = attacker.manR;
        float attOriginalManI = attacker.manI;
        float attOriginalManC = attacker.manC;

        float defOriginalManR = defender.manR;
        float defOriginalManI = defender.manI;
        float defOriginalManC = defender.manC;
        
        while ((attacker.manR + attacker.manI + attacker.manC) != 0 && (defender.manR + defender.manI + defender.manC) != 0) {
            // ATTACKER'S TURN //

            // Ranged Units //

            float attackValue = attacker.dmgR * attacker.general * attacker.budMor;
            float randomValue = Random.Range(0, 10);

            if (randomValue <= 1) { // 10% Chance --> Cavalry

                defender.manC -= attackValue * (Random.Range(1,3) / 2) * (1 - defender.defC);

            } else { // 90% Chance --> Infantry

                defender.manI -= attackValue * (Random.Range(1,3) / 2) * (1 - defender.defI);

            }

            // Infantry Units //

            attackValue = attacker.dmgI * attacker.general * attacker.budMor;
            randomValue = Random.Range(0, 10);

            if (randomValue <= 2) { // 20% Chance --> Ranged

                defender.manR -= attackValue * (Random.Range(1,3) / 2) * (1 - defender.defR);

            } else if(randomValue <= 7) { // 50% Chance --> Infantry

                defender.manI -= attackValue * (Random.Range(1,3) / 2) * (1 - defender.defI);

            } else { // 30% Chance --> Cavalry

                defender.manC -= attackValue * (Random.Range(1,3) / 2) * (1 - defender.defC);

            }

            // Infantry Units //

            attackValue = attacker.dmgC * attacker.general * attacker.budMor;
            randomValue = Random.Range(0, 10);

            if (randomValue <= 5) { // 50% Chance --> Ranged

                defender.manR -= attackValue * (Random.Range(1,3) / 2) * (1 - defender.defR);

            } else if(randomValue <= 8) { // 30% Chance --> Infantry

                defender.manI -= attackValue * (Random.Range(1,3) / 2) * (1 - defender.defI);

            } else { // 20% Chance --> Cavalry

                defender.manC -= attackValue * (Random.Range(1,3) / 2) * (1 - defender.defC);

            }


            // DEFENDER'S TURN //

            // Ranged Units //

            attackValue = defender.dmgR * defender.general * defender.budMor;
            randomValue = Random.Range(0, 10);

            if (randomValue <= 1) { // 10% Chance --> Cavalry

                defender.manC -= attackValue * (Random.Range(1,3) / 2) * (1 - attacker.defC);

            } else { // 90% Chance --> Infantry

                defender.manI -= attackValue * (Random.Range(1,3) / 2) * (1 - attacker.defI);

            }

            // Infantry Units //

            attackValue = defender.dmgI * defender.general * defender.budMor;
            randomValue = Random.Range(0, 10);

            if (randomValue <= 2) { // 20% Chance --> Ranged

                defender.manR -= attackValue * (Random.Range(1,3) / 2) * (1 - attacker.defR);

            } else if(randomValue <= 7) { // 50% Chance --> Infantry

                defender.manI -= attackValue * (Random.Range(1,3) / 2) * (1 - attacker.defI);

            } else { // 30% Chance --> Cavalry

                defender.manC -= attackValue * (Random.Range(1,3) / 2) * (1 - attacker.defC);

            }

            // Infantry Units //

            attackValue = defender.dmgC * defender.general * defender.budMor;
            randomValue = Random.Range(0, 10);

            if (randomValue <= 5) { // 50% Chance --> Ranged

                attacker.manR -= attackValue * (Random.Range(1,3) / 2) * (1 - attacker.defR);

            } else if(randomValue <= 8) { // 30% Chance --> Infantry

                attacker.manI -= attackValue * (Random.Range(1,3) / 2) * (1 - attacker.defI);

            } else { // 20% Chance --> Cavalry

                attacker.manC -= attackValue * (Random.Range(1,3) / 2) * (1 - attacker.defC);

            }
        }

        if((attacker.manR + attacker.manI + attacker.manC) == 0) { // Attacker Lost

            Debug.Log("Attacker Lost the Battle! ("+ attacker.unitName +")");

        } else { // Defender Lost
            
            Debug.Log("The Attack was a Total Success! ("+ attacker.unitName +")");

        }

        // Giving Back Half of Lost Manpower

        attacker.manR += (attOriginalManR - attacker.manR) / 2;
        attacker.manI += (attOriginalManI - attacker.manI) / 2;
        attacker.manC += (attOriginalManC - attacker.manC) / 2;

        defender.manR += (defOriginalManR - defender.manR) / 2;
        defender.manI += (defOriginalManI - defender.manI) / 2;
        defender.manC += (defOriginalManC - defender.manC) / 2;

        // Reshowing Armies

        attacker.gameObject.SetActive(true);
        defender.gameObject.SetActive(true);
    }
}
