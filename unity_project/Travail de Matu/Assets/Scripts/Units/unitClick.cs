using UnityEngine;

public class unitClick : MonoBehaviour
{   

    private Camera myCam;
    public   GameObject groundMarker;

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

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable) && hit.collider && hit.collider.gameObject.GetComponent<unit>() != null && hit.collider.gameObject.tag == playerController.tag) { // A: We hit a clickable object [HC]

                
                if (Input.GetKey(KeyCode.LeftShift)) { // Shift Click [HC]

                    unitSelections.Instance.shiftClickSelect(hit.collider.gameObject);

                } else { // Normal Click [HC]

                    unitSelections.Instance.clickSelect(hit.collider.gameObject);

                }

            } else { // B: We don't [HC]

                if(!Input.GetKey(KeyCode.LeftShift)) {

                    unitSelections.Instance.deselectAll();

                }

            }
        
        }

        if (Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) {

                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(true); 

            }
        }    

    }       

        

}
