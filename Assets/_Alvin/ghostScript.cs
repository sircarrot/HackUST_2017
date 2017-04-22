using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScript : MonoBehaviour {

    public GameObject Parent;
	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 tmpPosition = new Vector3(-1 * Parent.transform.position.x, Parent.transform.position.y, this.transform.position.z);
        this.transform.position = tmpPosition;
	}
}
