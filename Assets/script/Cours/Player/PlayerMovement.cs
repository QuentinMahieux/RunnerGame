using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float rotationSpeed = 100f;
    private float walkSpeed = 4f;
    private float sprintSpeed = 8f;
    private float acceleration = 5f;
    private float currentSpeed = 0f;
    private float targetSpeed;
    private Vector3 velocity;
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    private void Update()   
    {
        float horizontalInput = Input.GetAxis("Horizontal");      
        float verticalInput = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 rotationDirection = new Vector3(0, mouseX, 0);

        bool hasInput = inputDirection.sqrMagnitude > 0.01f;
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        
        if(hasInput) animator.SetBool("IsWalking", true);
        else animator.SetBool("IsWalking", false);
        
        if (isSprinting) { targetSpeed = sprintSpeed; animator.SetBool("IsRunning", true);  }
        else             { targetSpeed = walkSpeed;   animator.SetBool("IsRunning", false); }
        
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        velocity = inputDirection * currentSpeed;
        
        transform.Translate(velocity * Time.deltaTime, Space.Self);
        transform.Rotate(rotationDirection);
    }
}