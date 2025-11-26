using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float motorForce = 1500f;
    public float brakeForce = 50000f;
    public float maxSteerAngle = 45f;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    private float currentSteerAngle;
    private float currentBrakeForce;
    private bool isBraking;

    private Rigidbody rb;
    public Text Speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();

        Speed.text = (rb.velocity.magnitude * 2.23693629f).ToString("0") + (" m/h");
    }

    private void GetInput()
    {
        currentSteerAngle = maxSteerAngle * Input.GetAxis("Horizontal");
        isBraking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        float verticalInput = Input.GetAxis("Vertical");
        rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce;
        if (verticalInput == 0 || isBraking)
        {
            currentBrakeForce = brakeForce;
        }
        else
        {
            currentBrakeForce = 0f; 
        }

        ApplyBraking();
    }

    private void ApplyBraking()
    {
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        frontRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateWheelPosition(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPosition(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPosition(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPosition(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPosition(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
}
