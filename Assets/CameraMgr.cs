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

    public float cameraMoveSpeed = 500;

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
    }
}
