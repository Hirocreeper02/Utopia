using UnityEngine;

public class cityClick : MonoBehaviour
{   

    private Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

    public GameObject playerController;

    void Start()
    {
        myCam = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable) && hit.collider.gameObject.GetComponent<city>() != null && hit.collider.gameObject.tag == playerController.tag) { // A: We hit a clickable object [HC]

                citySelections.Instance.clickSelect(hit.collider.gameObject);

            } else { // B: We don't [HC]

                citySelections.Instance.deselectAll();

            }
        
        }  

    }       

        

}
