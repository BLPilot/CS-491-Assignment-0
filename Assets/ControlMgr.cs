using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float deltaSpeed = 1;
    public float deltaHeading = 1;

    // Update is called once per frame
    void Update()
    {

        //change speed
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            SelectionMgr.inst.selectedEntity.desiredSpeed += deltaSpeed;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            SelectionMgr.inst.selectedEntity.desiredSpeed -= deltaSpeed;
        }

        //clamp
        SelectionMgr.inst.selectedEntity.desiredSpeed =
            Utilities.Clamp(SelectionMgr.inst.selectedEntity.desiredSpeed, SelectionMgr.inst.selectedEntity.minSpeed, SelectionMgr.inst.selectedEntity.maxSpeed);

        //change heading
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            SelectionMgr.inst.selectedEntity.desiredHeading -= deltaHeading;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            SelectionMgr.inst.selectedEntity.desiredHeading += deltaHeading;
        }


        SelectionMgr.inst.selectedEntity.desiredHeading = Utilities.Degrees360(SelectionMgr.inst.selectedEntity.desiredHeading);


    }
}
