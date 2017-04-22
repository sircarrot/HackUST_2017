using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour {

    public GameObject Door;
    public bool on = true;
    public float TimeReal = 1;
    Vector3 tmpNow;
    Vector3 tmpTarget;
    // Use this for initialization
    void Start ()
    {
        tmpNow = Door.transform.position;
        tmpTarget = new Vector3(Door.transform.position.x, Door.transform.position.y - 27.4f, Door.transform.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(on == false)
        {
            if(TimeReal>0)
            {
                TimeReal -= Time.deltaTime * 1;
            }
            
            Door.transform.position = Vector3.Lerp(tmpTarget,tmpNow,TimeReal);
        }
	}
}
