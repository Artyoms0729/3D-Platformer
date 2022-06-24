using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{   

    [SerializeField] Transform platform;
    [SerializeField] float floor1 = 10;
    [SerializeField] float floor0 = 0;
    [SerializeField] float elevatorSpeed;

    public int choosenFloor;
    private float targetFloor;

    public static Platform Instance { get; private set; }  
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        choosenFloor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 movePlatform = new Vector3(platform.position.x,floor1, platform.position.z);
        //platform.position = movePlatform;
        platform.transform.localPosition = new Vector3(0, Mathf.Lerp(platform.localPosition.y, targetFloor, elevatorSpeed * Time.deltaTime), 0);
    }

    public void GoToFloor()
    {
        switch (choosenFloor)
        {
            case 0:
                targetFloor = floor0;
                break;
            case 1:
                targetFloor = floor1;
                break;
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
