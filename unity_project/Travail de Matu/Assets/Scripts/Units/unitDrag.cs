using UnityEngine;

public class unitDrag : MonoBehaviour
{   

    Camera myCam;

    [SerializeField]
    RectTransform boxVisual; //Graphical [HC]

    Rect selectionBox; //Logical [HC]

    public GameObject playerController;

    Vector2 startPosition;
    Vector2 endPosition;

    void Start()
    { 
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        drawVisual();
        
    }


    void Update()
    {
        //Click [HC]

        if (Input.GetMouseButtonDown(0)) {

            startPosition = Input.mousePosition;
            selectionBox = new Rect();

        }

        //Drag [HC]

        if (Input.GetMouseButton(0)) {

            endPosition = Input.mousePosition;
            drawVisual();
            drawSelection();

        }

        //Release [HC]
        if (Input.GetMouseButtonUp(0)) {

            selectUnits();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            drawVisual();

        }
    }

    void drawVisual() {

        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxSize;

    }

    void drawSelection() {

        //X calculations [HC]

        if(Input.mousePosition.x < startPosition.x) { //Draging Left [HC]

            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
            
        } else { //Draging Right [HC]

            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;

        }

        //Y calculations [HC]

        if(Input.mousePosition.y < startPosition.y) { //Draging Down [HC]

            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
            
        } else { //Draging Up [HC]

            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;

        }

    }

    void selectUnits() {

        foreach (var unit in unitSelections.Instance.unitList) {

            if (selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position)) && unit.tag == playerController.tag) { //If unit is in Selection Box [HC]

                unitSelections.Instance.dragSelect(unit);

            }

        }

    }

}
