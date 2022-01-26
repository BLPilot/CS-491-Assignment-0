using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientedPhysics : MonoBehaviour
{
    public EntityData entity;

    // Start is called before the first frame update
    void Start()
    {
        entity.position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        //Speed

        if(Utilities.ApproximatelyEqual(entity.speed, entity.desiredSpeed))
        {

        }else if (entity.speed < entity.desiredSpeed)
        {
            entity.speed = entity.speed + entity.acceleration * Time.deltaTime;
        }else if (entity.speed > entity.desiredSpeed)
        {
            entity.speed = entity.speed - entity.acceleration * Time.deltaTime;
        }

        //Clamp speed
        entity.speed = Utilities.Clamp(entity.speed, entity.minSpeed, entity.maxSpeed);

        //Heading
        if(Utilities.ApproximatelyEqual(entity.heading, entity.desiredHeading))
        {
           
        }else if (Utilities.AngleDiffPosNeg(entity.desiredHeading, entity.heading) > 0)
        {
            entity.heading += entity.turnRate * Time.deltaTime;
        }
        else if (Utilities.AngleDiffPosNeg(entity.desiredHeading, entity.heading) < 0)
        {
            entity.heading -= entity.turnRate * Time.deltaTime;
        }


        entity.heading = Utilities.Degrees360(entity.heading);



        //Velocity
        entity.velocity.x = Mathf.Sin(entity.heading * Mathf.Deg2Rad) * entity.speed;
        entity.velocity.y = 0;
        entity.velocity.z = Mathf.Cos(entity.heading * Mathf.Deg2Rad) * entity.speed;

        entity.position = entity.position + entity.velocity * Time.deltaTime;

        transform.localPosition = entity.position;

        eulerRotation.y = entity.heading;
        transform.localEulerAngles = eulerRotation;
    }

    public Vector3 eulerRotation = Vector3.zero;

    
}
