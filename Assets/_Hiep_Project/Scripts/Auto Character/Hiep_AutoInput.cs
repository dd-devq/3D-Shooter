using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Hiep_AutoInput : MonoBehaviour
{   
    public Vector2 dir;
    public Vector2 dirFire;
    public static event Action<bool> OnFire;
    private bool isFire;

    public bool IsFire
    {
        get => isFire;
        set
        {
            isFire = value;
            if (OnFire != null)
            {
                OnFire(value);
            }
        }
    }

    public VariableJoystick joystickMove;
    public VariableJoystick joystickFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirKeyboard = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 dirJoystick = joystickMove.Direction;
        //dirFire = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsFire = true;          
        }
        else
        {
            IsFire = joystickFire.isFire;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsFire = false;
        }
        else
        {
            IsFire = joystickFire.isFire;
        }

        dir = dirKeyboard + dirJoystick;
        dirFire = joystickFire.Direction;
       
    }
}
