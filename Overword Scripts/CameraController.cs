using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*    
     this class grabs the transform of a target in order to follow it and then it uses an offset to position itself away from the player for a custom distance. Also uses other varibles to control the speed and the maximum and minimum zoom. You can use the scroll wheel to zoom in and A, D, left, and right arrow keys to rotate the camer
         */ 
    public Transform target;
    public Vector3 offset;
    private float currentZoom = 10f;
    private float pitch = 2f;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float yawSpeed = 100f;
    private float currentYaw = 0f;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (pauseMenuUI.activeInHierarchy == false)
        {
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
