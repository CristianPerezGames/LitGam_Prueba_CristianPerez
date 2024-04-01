using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("VARIABLES")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float rollSpeed;

    [Header("REFERENCES")]
    [SerializeField] private Rigidbody rgBody;
    [SerializeField] private Camera characterCamera;

    bool waitForFrame;
    private Vector3 velocity;

    float targetSpeed; 
    float yMouse;
    float yAngle;
    float xMouse;
    float xAngle;

    private void Awake() {
        waitForFrame = true;
    }

    // Start is called before the first frame update
    void Start() {
        xAngle = 180;

        StartCoroutine(RutineWaitForFrame());
    }

    IEnumerator RutineWaitForFrame(){
        yield return new WaitForSeconds(0.5f);
        waitForFrame = false;
    }

    // Update is called once per frame
    void Update() {
        if(waitForFrame) return;
        
        Rotation();
        Movement();
    }

    private void FixedUpdate() {
        rgBody.MovePosition(rgBody.position + (velocity * Time.fixedDeltaTime));
    }

    void Rotation(){
        xMouse = Input.GetAxis("Mouse X");
        xAngle += xMouse * turnSpeed * Time.deltaTime;
        rgBody.transform.rotation = Quaternion.Euler(0, xAngle, 0);

        yMouse = -Input.GetAxis("Mouse Y");
        yAngle += yMouse * rollSpeed * Time.deltaTime;
        yAngle = Mathf.Clamp(yAngle,-90,90);
        characterCamera.transform.localRotation = Quaternion.Euler(yAngle,0,0);
    }

    void Movement(){
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 right = transform.right * horAxis;
        Vector3 foward = transform.forward * verAxis;
        Vector3 direction = right + foward;
        direction = Vector3.ClampMagnitude(direction, 1);
        targetSpeed = Input.GetKey(KeyCode.LeftShift)? runSpeed : walkSpeed;
        velocity = direction * targetSpeed;

        if(horAxis == 0 && verAxis == 0){
            rgBody.velocity = Vector3.zero;
        }
    }
}
