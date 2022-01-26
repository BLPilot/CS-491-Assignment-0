using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMgr : MonoBehaviour
{
    public static SelectionMgr inst;
    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            SelectNextEntity();
        }
    }

    public int selectedEntityIndex = 0;
    public EntityData selectedEntity;

    public void SelectNextEntity()
    {
        selectedEntityIndex = (selectedEntityIndex >= EntityMgr.inst.entities.Count - 1 ? 0 : selectedEntityIndex + 1);
        selectedEntity = EntityMgr.inst.entities[selectedEntityIndex];
        UnSelectAll();
        selectedEntity.isSelected = true;
    }

    void UnSelectAll()
    {
        foreach(EntityData ent in EntityMgr.inst.entities)
        {
            ent.isSelected = false;
        }
    }
}
