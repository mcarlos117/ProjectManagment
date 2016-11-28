using UnityEngine;
using System.Collections;


//Nice Bruh!
public class Chase : MonoBehaviour {

    public Transform target;
    public Transform myTransform;
    float speed = 10.0f;
    const float EPSILON = 0.1f;

    void Start()
    {
        Debug.Log("Players = " + HostGame.playerCount);
    }

    void Update()
    {

        //Debug.Log("Players = " + Network.connections.Length);

        if (HostGame.playerCount == 2)
        {

           
//Isnt there a new pokemon game??
            transform.LookAt(target.position);

            if ((transform.position - target.position).magnitude > EPSILON)
            {
                transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
            }
        }
    }

}
