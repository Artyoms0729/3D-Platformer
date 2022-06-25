using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Elevator Setup")]
    [SerializeField] Transform platform;
    [SerializeField] private float floor4;
    [SerializeField] private float floor3;
    [SerializeField] private float floor2;
    [SerializeField] private float floor1;
    [SerializeField] private float floor0;
    [SerializeField] private float elevatorSpeed;
    
    //[SerializeField] private AnimationCurve eCurve;

    public int choosenFloor;
    private float targetFloor;


    private Vector3 startPos;
    //private Vector3 endPos;
    

    public static Platform Instance { get; private set; }  
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = platform.transform.localPosition;
        choosenFloor = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        Vector3 changePosition = new Vector3(startPos.x, Mathf.MoveTowards(platform.transform.localPosition.y, targetFloor,elevatorSpeed * Time.fixedDeltaTime), startPos.z);
        platform.transform.localPosition = changePosition;
        //endPos = new Vector3(startPos.x, targetFloor, startPos.z);
        //transform.position = Vector3.Lerp(startPos, endPos, travelTime);
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
            case 2:
                targetFloor = floor2;
                break;
            case 3:
                targetFloor = floor3;
                break;
            case 4:
                targetFloor = floor4;
                break;
        }
            
    }
}
