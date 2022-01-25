using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //public List<GameObject> CubeEntities;
    public List<PhysicAndInput> cubeEntitiesPhysics;


    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    public PhysicAndInput selectedEntity;
    public int selectedEntityIndex;



    public float deltaVelocity = 5;
    void ProcessInput()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            selectedEntity.velocity.x -= deltaVelocity;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            selectedEntity.velocity.x += deltaVelocity;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            selectedEntity.velocity.z += deltaVelocity;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            selectedEntity.velocity.z -= deltaVelocity;
        }
        if (Input.GetKey(KeyCode.Equals))
        {
            selectedEntity.velocity.y += deltaVelocity;
        }
        if (Input.GetKey(KeyCode.Minus))
        {
            selectedEntity.velocity.y -= deltaVelocity;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            selectedEntity.velocity = Vector3.zero;
        }

        if (Input.GetKeyUp(KeyCode.Tab)){
            SelectNextEntity();
        }
        
    }

    void SelectNextEntity()
    {

        UnselectAll();
        selectedEntityIndex = (selectedEntityIndex >= cubeEntitiesPhysics.Count - 1 ? 0 : selectedEntityIndex + 1);
        selectedEntity = cubeEntitiesPhysics[selectedEntityIndex];
        selectedEntity.isSelected = true;
    }

    void UnselectAll()
    {
        foreach(PhysicAndInput phx in cubeEntitiesPhysics)
        {
            phx.isSelected = false;
        }
    }

}
