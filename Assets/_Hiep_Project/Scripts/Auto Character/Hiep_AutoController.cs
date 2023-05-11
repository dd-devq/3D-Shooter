using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hiep;

public class Hiep_AutoController : MonoBehaviour
{
    public List<GameObject> lsWeapons = new List<GameObject>();
    public CharacterController characterController;
    public Hiep_AutoDatabinding autoDatabinding;
    public Hiep_AutoInput autoInput;

    public float speedMove = 2;
    public Transform trans;
    public Transform transModel;

    private bool isFire;
    private MissionControl missionControl;
    private int level;
    // Start is called before the first frame update
    void Awake()
    {
        trans = transform.parent;
        characterController = GetComponent<CharacterController>();
        autoDatabinding = GetComponent<Hiep_AutoDatabinding>();   
        OnSetupWeapon();

    }

    public void OnSetup(int level, MissionControl missionControl)
    {
        this.level = level;
        this.missionControl = missionControl;
        missionControl.OnSetupMission(level);
    }


    public void OnSetupWeapon()
    {
        GetComponent<WeaponControl>().SwitchWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(autoInput.dir.x, 0, autoInput.dir.y);
        Vector3 fireDir = new Vector3(autoInput.dirFire.x, 0, autoInput.dirFire.y);
        isFire = autoInput.IsFire;
        
        if (isFire)
        {
            if (fireDir.magnitude > 0)
            {                
                fireDir.Normalize();
                trans.forward = moveDir;
                transModel.forward = fireDir;
            }
        }
        else
        {
            if (moveDir.magnitude > 0)
            {
                moveDir.Normalize();
                //trans.forward = moveDir;
                transModel.forward = moveDir;               
            }
        }

        if (moveDir.magnitude > 0.3f)
        {
            characterController.Move(moveDir * Time.deltaTime * speedMove);
        }
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out RaycastHit hitInfo, 999))
        //{
        //    Vector3 target = hitInfo.point;
        //    target.y = transModel.position.y;
        //    transModel.LookAt(target);
        //}

        autoDatabinding.Speed = moveDir.magnitude;

    }
}
