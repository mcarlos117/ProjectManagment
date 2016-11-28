using UnityEngine;
using UnityEngine.Networking;

public class ProjectileShooter : NetworkBehaviour {

    GameObject prefab;
	void Start () {
        prefab = Resources.Load("Sphere") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody _rb = projectile.GetComponent<Rigidbody>();
            _rb.velocity = Camera.main.transform.forward * 40;
        }
	}
}
