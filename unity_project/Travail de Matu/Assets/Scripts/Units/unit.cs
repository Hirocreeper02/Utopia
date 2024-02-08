using UnityEngine;

public class unit : MonoBehaviour
{

    public GameObject prefab;
    public GameObject mastermind;

    public string unitName;
    public bool isFleeing = false;

    public float dmgR;
    public float defR;
    public float manR;

    public float dmgI;
    public float defI;
    public float manI;

    public float dmgC;
    public float defC;
    public float manC;

    public float general;
    public float budMor;

    void Start()
    {
        unitSelections.Instance.unitList.Add(this.gameObject);
    }

    void Update() {
        if (Input.GetKey(KeyCode.F) && unitSelections.Instance.unitSelected.Count == 1 && unitSelections.Instance.unitSelected.Contains(gameObject)) { //Check if selected and if is the only one selected [HC]
            transform.Rotate (0,0,0); // Set rotation to 0 [HC]
            Instantiate(prefab,transform.position,transform.rotation); // Spawn City [HC]
            //Country.moneyPlus += 3;
            //Country.foodPlus += 2;
            Destroy(gameObject); // Destroy Unit [HC]
        }
    }

    void OnDestroy()
    {
        unitSelections.Instance.unitList.Remove(this.gameObject);
        unitSelections.Instance.unitSelected.Remove(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(gameObject.GetComponent<unit>().isFleeing == false && collision.gameObject.GetComponent<unit>().isFleeing == false && gameObject.tag != collision.gameObject.tag) {
            Debug.Log("Collision Mylord!");
            collision.gameObject.SetActive(false);
            mastermind.GetComponent<brain>().Combat(this.gameObject.GetComponent<unit>(), collision.gameObject.GetComponent<unit>());
            gameObject.SetActive(false);
        } else {
            Debug.Log("That's no Army!");
        }
        
    }
}
