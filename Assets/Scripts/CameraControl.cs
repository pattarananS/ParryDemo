using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    float rotX = 0f;
    float rotY = 0f;

    [SerializeField] float sensitivity = 15f;
    [SerializeField] GameObject player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        rotX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY -= Input.GetAxis("Mouse X") * -1 * sensitivity;
        transform.localEulerAngles = new Vector3(rotX,rotY,0);
    }
}
