using System.Collections;
using UnityEngine;

public class Zoomer : MonoBehaviour
{
    public float distanceMin;
    public float distanceMax;
    public float zoomSpeed;

    private float[] distances = new float[32];
    private Vector3 moveDirection = Vector3.zero;


    void Update()
    {

        moveDirection = new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel"));
        moveDirection *= zoomSpeed;

        //Checking the upper and lower bounds is a matter of determining if 
        //    the direction we're moving is positive (zooming in) or negative (zooming out). 
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit point; Physics.Raycast(ray, out point, 25); 
            Vector3 Scrolldirection = ray.GetPoint(5);

            float step = zoomSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Scrolldirection, Input.GetAxis("Mouse ScrollWheel") * step);
        }
    }
}
