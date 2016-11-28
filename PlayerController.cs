using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 7;
    [SerializeField]
    private float thrusterForce = 1000f;
    private PlayerMotor motor;
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }
    void Update()
    {
        if (PauseMenu.IsOn)
        {
            return;
        }


        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov; 
        Vector3 movVertical = transform.forward * zMov;
        //final movement vector
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        motor.Move(velocity);

        //calculate rotation
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0) * lookSensitivity;

        //Apply Rotation
        motor.Rotate(rotation);

        //calculate Camera rotation
        float xRot = Input.GetAxisRaw("Mouse Y");

        float cameraRotationX = xRot * lookSensitivity;

        //Apply Rotation
        motor.RotateCamera(cameraRotationX);


        Vector3 _thrusterForce = Vector3.zero;
        
        if (Input.GetButton("Jump"))
        {
            _thrusterForce = Vector3.up * thrusterForce;
        }
        //Apply thruster force
        motor.ApplyThruster(_thrusterForce);

    }
}
