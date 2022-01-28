using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    public static CameraMgr inst;
    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject rtsCameraRig;

    public GameObject yawNode;
    public GameObject pitchNode;
    public GameObject rollNode;

    public float cameraMoveSpeed = 100;
    public float cameraTurnRate = 50;
    public Vector3 currentYawEulerAngles = Vector3.zero;
    public Vector3 currentPitchEulerAngles = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            yawNode.transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            yawNode.transform.Translate(Vector3.back * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            yawNode.transform.Translate(Vector3.left * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            yawNode.transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.R))
        {
            yawNode.transform.Translate(Vector3.up * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.F))
        {
            yawNode.transform.Translate(Vector3.down * Time.deltaTime * cameraMoveSpeed);
        }

        currentYawEulerAngles = yawNode.transform.localEulerAngles;

        
        if(Input.GetKey(KeyCode.Q))
        {
            currentYawEulerAngles.y -= cameraTurnRate * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.E))
        {
            currentYawEulerAngles.y += cameraTurnRate * Time.deltaTime;
        }
        yawNode.transform.localEulerAngles = currentYawEulerAngles;

        currentPitchEulerAngles = pitchNode.transform.localEulerAngles;
        if (Input.GetKey(KeyCode.Z))
        {
            currentPitchEulerAngles.x -= cameraTurnRate * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.X))
        {
            currentPitchEulerAngles.x += cameraTurnRate * Time.deltaTime;
        }

        pitchNode.transform.localEulerAngles = currentPitchEulerAngles;
        Vector3 savedPitch = Vector3.zero;
        savedPitch.Set(25, 0, 0);

        if (Input.GetKeyUp(KeyCode.C))
        {
            if (isRTSMode)
            {
                yawNode.transform.SetParent(SelectionMgr.inst.selectedEntity.cameraRig.transform);
                yawNode.transform.localPosition = Vector3.zero;
                yawNode.transform.localEulerAngles = Vector3.zero;
                pitchNode.transform.localEulerAngles = savedPitch;
            }
            else
            {
                yawNode.transform.SetParent(rtsCameraRig.transform);
                yawNode.transform.localPosition = Vector3.zero;
                yawNode.transform.localEulerAngles = Vector3.zero;
            }
            isRTSMode = !isRTSMode;
        }
    }

    public bool isRTSMode = true;
}
