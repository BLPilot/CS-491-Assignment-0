using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponentInParent<EntityData>();
    }

    public EntityData entity;
    public GameObject selectionCircle;

    // Update is called once per frame
    void Update()
    {
        if(entity != null)
        {
            selectionCircle.SetActive(entity.isSelected);
        }

        if (Input.GetMouseButtonUp(1))
        {
            RightClick();
            
        }


       
    }

    private void OnMouseDown()
    {
        Debug.Log("Click");
        SelectionMgr.inst.SelectEntity(entity);
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
        }
        
    }

    
    




}
