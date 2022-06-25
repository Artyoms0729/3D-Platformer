using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [Header("Bullet Logic")]
    [SerializeField] float speed;
    private Rigidbody bulletRb;

    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        bulletRb.velocity = transform.forward*speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Target"))
        {
            //add points
            Destroy(other.gameObject);
            CountersScript.score++;
            Debug.Log("add 1 point");
        }
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
