using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;

    [Header("Player Controller Setup")]
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] float speed = 6;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    [SerializeField] bool isGrounded = true;
    [SerializeField] bool gameOver = false;

    [Header("Interaction and aim")]
    [SerializeField] private Transform gameCamera;
    [SerializeField] private KeyCode interactionKey;
    [SerializeField] private float interactionDistance;


    //[SerializeField] float smoothTurnTime = 0.1f;    
     


    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        isGrounded = true;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        PlayerJump();
        Interactions();
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3 (horizontalInput,0f, verticalInput).normalized;

        if (direction.magnitude >= 0.1f)
        {            

            Vector3 Movement = transform.TransformDirection(direction) * speed;
            playerRb.velocity = new Vector3(Movement.x, playerRb.velocity.y, Movement.z);
                      
        }

    }

    private void PlayerJump()
    {
        if(Input.GetKeyDown(jumpKey) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void Interactions()
    {
#if UNITY_EDITOR
        // draw interaction line if in Unity
        Debug.DrawLine(gameCamera.transform.position, gameCamera.transform.position + gameCamera.transform.forward * interactionDistance, Color.green);
#endif
        if (Input.GetKeyDown(interactionKey))
        {
            RaycastHit hit;
            if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit, interactionDistance)) ;
            {
                if (hit.transform.GetComponent<Elevator>())
                {
                    hit.transform.GetComponent<Elevator>().Interact();
                }
            }

        }
    }
}
