using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : MonoBehaviour
{
 
    
    private Vector3 diff = Vector3.zero;
    public GameObject targetPointer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        MovePointer();
        

        if (Input.GetMouseButtonUp(1) )
        {
            RightClick();
            SelectionMgr.inst.selectedEntity.moveToTarget = true;
            

        }


        if (SelectionMgr.inst.selectedEntity.moveToTarget)
        {
            MovePos(SelectionMgr.inst.selectedEntity.targetLocation);
        }
    }



    public void MovePointer()
    {
        

        float rayLength = 1000f;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            targetPointer.transform.position = hit.point;

        }
    }

    public void RightClick()
    {
        Debug.Log("Right Click");

        float rayLength = 1000f;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

       
        SelectionMgr.inst.selectedEntity.pointer.transform.position = targetPointer.transform.position;
        

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            Debug.Log(hit.point);
            SelectionMgr.inst.selectedEntity.targetLocation = hit.point;
        }
    }

    public void MovePos(Vector3 tar)
    {
        Vector3 diff = tar - SelectionMgr.inst.selectedEntity.position;
        SelectionMgr.inst.selectedEntity.targetHeading = Utilities.Degrees360((Mathf.Atan2(-diff.z, diff.x) * Mathf.Rad2Deg + 90));
        SelectionMgr.inst.selectedEntity.desiredHeading = SelectionMgr.inst.selectedEntity.targetHeading;
        SelectionMgr.inst.selectedEntity.desiredSpeed = SelectionMgr.inst.selectedEntity.maxSpeed;
    }

    
}
