using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : MonoBehaviour
{
    public EntityData entity;
    private Vector3 targetLocation= Vector3.zero;
    private Vector3 diff = Vector3.zero;
    private float targetHeading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            RightClick();
            MovePos(targetLocation);

        }
    }

    private void RightClick()
    {
        Debug.Log("Right Click");

        float rayLength = 1000f;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            Debug.Log(hit.point);
            targetLocation = hit.point;
        }

    }

    private void MovePos(Vector3 tar)
    {
        Vector3 diff = tar - entity.position;
        targetHeading= Mathf.Atan2(diff.z, diff.x);
        entity.desiredHeading = targetHeading;
        entity.desiredSpeed = entity.maxSpeed;
    }
}
