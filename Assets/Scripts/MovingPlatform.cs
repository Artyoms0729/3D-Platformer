using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{    
    [SerializeField] private float speed;
    [SerializeField] private float range;
    //[SerializeField] private float value;

    private GameObject floatingObstacle;
    private float reach;

    private void Start()
    {
        floatingObstacle = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        MovingObstacle();    
    }

    private void MovingObstacle()
    {
        reach += speed*Time.deltaTime;

        floatingObstacle.transform.localPosition = new Vector3(0, Mathf.Cos(reach) * range, 0);
    }
}
