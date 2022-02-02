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
    public GameObject pointer;
    

    // Update is called once per frame
    void Update()
    {
        if(entity != null)
        {
            selectionCircle.SetActive(entity.isSelected);
          
            pointer.SetActive(entity.isSelected);
            
            
        }
 
    }

    private void OnMouseDown()
    {
        Debug.Log("Click");
        SelectionMgr.inst.SelectEntity(entity);
    }



}
