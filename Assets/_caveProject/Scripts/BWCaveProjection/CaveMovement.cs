using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UVRPN.Core;

public class CaveMovement : MonoBehaviour
{
    public GameObject flystick;
    private float speed = 3f;
    private float rotationSpeed=20f;
    private Vector3 forwardDirection;
    private Vector2 joystick;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Debug.Log(flystick.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        forwardDirection=flystick.transform.forward;
        //Debug.Log(flystick.transform.parent.gameObject);
        joystick=FindObjectOfType<UVRPN.Core.VRPN_Analog>().Analog;
        //Debug.Log(joystick.y);
        transform.position += forwardDirection * Time.deltaTime * speed * joystick.y;
        transform.Rotate(Vector3.up *Time.deltaTime * rotationSpeed * joystick.x);
    }
}
