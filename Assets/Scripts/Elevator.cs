using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] int buttonPressed;
    // Start is called before the first frame update
    public Platform platform;

    public void Interact()
    {
        platform.choosenFloor = buttonPressed;
        platform.GoToFloor();        
    }
}
