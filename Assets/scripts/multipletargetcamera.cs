using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class multipletargetcamera : MonoBehaviour
{
    public List<Transform> targets;
// variables para controlar el movimiento de la camara
    public float smoothTime = .5f;
    private Vector3 velocity;

// variables para controlar el zoom de la camara
    public float maxZoom = 10f;
    public float minZoom = 40f;
    public float zoomLimiter = 40f;


    private Camera cam ;


//variables para controlar la rotacion de la camara

    public float rotationVelocity;
    public Transform centerObjet;
    void Start()
    {
        cam = GetComponent<Camera>();
    }
    public Vector3 offSet;
    void LateUpdate() {
        if (targets.Count == 0)
        {
            return;
        }

        movement();

        zoom();
        centerObjet.position = GetCenterPoint();
        //Debug.Log(centerObjet.localRotation);
      

        
        rotationCamera();
    }

    void  zoom(){
        
        float newzoom = Mathf.Lerp(maxZoom,minZoom, GetGreatestDistance() / zoomLimiter );
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newzoom, Time.deltaTime);
    }
    void movement(){
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offSet;
        transform.position = Vector3.SmoothDamp(transform.position,newPosition, ref velocity,smoothTime); 
    }
    float GetGreatestDistance(){
        var bounds = new Bounds(targets[0].position,Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }
    void rotationCamera(){
        
        transform.LookAt(centerObjet);

    }
    Vector3 GetCenterPoint(){
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for ( int i= 0 ;i <targets.Count;  i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;

    }


}
