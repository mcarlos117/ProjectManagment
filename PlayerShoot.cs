using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    public PlayerWeaponScript weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    private const string PLAYER_TAG = "Player";

    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("PlayerShoot: No Camera referenced");
            this.enabled = false;
        }
    }

    void Update()
    {
        if (PauseMenu.IsOn)
        {
            return;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }



    [Client]
    void Shoot()
    {
        RaycastHit _hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            //We Hit Something
            if(_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name, weapon.damage);

            }
        }
    }

    [Command]
    void CmdPlayerShot(string playerID, int damage)
    {
        Debug.Log(playerID + " has been shot.");
        Player _player = GameManager.GetPlayer(playerID);

        _player.RpcTakeDamage(damage);
        
        // _player.GetTagged(tag);
        //_player.Tag();
    }

}
