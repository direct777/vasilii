using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform targetPoint;
    public Camera cameraLink;
    public float targetInSkyDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.6f, 0));
        RaycastHit hit;
        //Physics.Raycast(ray, out hit);
        
        //Debug.Log("hit=" + hit);
        //Debug.DrawRay(cameraLink.transform.position, ray, Color.red);

        if (Physics.Raycast(ray,out hit))
        {
            targetPoint.position = hit.point;
            //Debug.DrawRay(ray, targetPoint.position, Color.red);
            //Debug.Log("targetPoint.position=" + hit.point);
        }
        else
        {
            targetPoint.position = ray.GetPoint(targetInSkyDistance);
            //Debug.Log("targetPoint.position in the else=" + hit.point);
        }
        transform.LookAt(targetPoint.position);
    }
}
