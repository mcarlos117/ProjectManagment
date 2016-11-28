using UnityEngine;
using System.Collections;

public class chase : MonoBehaviour {
    public Transform target;
    public Transform myTransform;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        transform.Translate(Vector3.forward*2*Time.deltaTime);
        
    }
}
