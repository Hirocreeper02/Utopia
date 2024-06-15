using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smartspider : MonoBehaviour
{
    
    Dictionary<object, int> position = new Dictionary<object, int>();
    object owner;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void addIssue(object issue)
    {
        this.position.Add(issue,0);
    }
    
    public void removeIssue(object issue)
    {
        this.position.Remove(issue);
    }
    
}
