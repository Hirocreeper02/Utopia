using UnityEngine;

public class city : MonoBehaviour
{

    public string cityName;

    public float population;
    public float revenue;

    public bool isRegionalCapital;
    public bool isNationCapital;

    //public List<string> buildingsList = new List<string>();   

    void Start()
    {
        citySelections.Instance.cityList.Add(this.gameObject);
    }

    void OnDestroy()
    {
        citySelections.Instance.cityList.Remove(this.gameObject);
        citySelections.Instance.citySelected.Remove(this.gameObject);
    }
}
