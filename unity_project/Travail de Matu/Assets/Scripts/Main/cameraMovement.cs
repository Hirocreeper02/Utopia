using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float zoom = 30.0f;
    public bool colliding; 
    public GameObject cam;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        colliding = false;
    }
    
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.W)) // Forward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * transform.position.y/5);
        }
        if (Input.GetKey(KeyCode.S)) // Backward
        { 
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed * transform.position.y/5);
        }
        if (Input.GetKey(KeyCode.A)) // Left
        { 
            transform.Translate(-1 * Vector3.right * Time.deltaTime * speed * transform.position.y/5);
        }
        if (Input.GetKey(KeyCode.D)) // Right
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * transform.position.y/5);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // Zoom In
        {
            cam.transform.Translate(Vector3.forward * Time.deltaTime * zoom * transform.position.y);
        } 
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // Zoom Out 
        {
           cam.transform.Translate(-1 * Vector3.forward * Time.deltaTime * zoom * transform.position.y);
        }  
    }

    
    void OnTriggerEnter(Collider CollisionCheck)
        {
        if (CollisionCheck.gameObject.tag == "Terrain") 
        {
            colliding = true;
            Debug.Log("Collision!!!");
        } 
    }
}

