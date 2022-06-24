using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;    

    [Header("Key settings")]
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private KeyCode interactionKey;
    [SerializeField] private KeyCode shootKey;

    [Header("Player Controller Setup")]
    [SerializeField] float speed = 6;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;
    [SerializeField] bool isGrounded = true;
    [SerializeField] bool gameOver = false;

    [Header("Interaction and aim")]
    [SerializeField] private Transform gameCamera;
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private Transform spawnBulletPos;
    [SerializeField] private LayerMask aimMask = new LayerMask();
    [SerializeField] private float interactionDistance;
    [SerializeField] private Transform debugTransform;
    
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
        Shoot();
        
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (direction.magnitude >= 0.1f)
        {

            Vector3 Movement = transform.TransformDirection(direction) * speed;
            playerRb.velocity = new Vector3(Movement.x, playerRb.velocity.y, Movement.z);

        }

    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
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

    private void Shoot()
    {
        Vector3 mousePosition = Vector3.zero;

        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimMask))
        {
            debugTransform.position = raycastHit.point;
            mousePosition = raycastHit.point;
        }
        if (Input.GetKeyDown(shootKey))
        {            
            Vector3 aimDirection = (mousePosition - spawnBulletPos.position).normalized;
            Instantiate(bulletPrefab, spawnBulletPos.position, Quaternion.LookRotation(aimDirection, Vector3.up));
            //GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            //if (pooledProjectile != null)
            //{
            //    pooledProjectile.SetActive(true); // activate it
            //    pooledProjectile.transform.position = spawnBulletPos.transform.position; // position it in front of a player
            //    Quaternion.LookRotation(aimDirection, Vector3.up);
            //}
        }

              
    }

    //private void MousePositionUpdate()
    //{
    //    Vector3 mousePosition = Vector3.zero;

    //    Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);    
    //    Ray ray= Camera.main.ScreenPointToRay(screenCenter);
    //    if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimMask))
    //    {
    //        debugTransform.position = raycastHit.point;
    //        mousePosition = raycastHit.point;
    //    }
    //}
}
