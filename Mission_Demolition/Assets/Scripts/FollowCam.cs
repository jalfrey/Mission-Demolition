/*
 * 
 * Created by: Jason Alfrey
 * Created date: 2/9/2022
 * Edited by: Jason Alfrey
 * Edit date: 2/14/2022
 * 
 * Description: Camera to follow slingshot projectile. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;
    
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;


    [Header("Set Dynamically")]
    public float camZ;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        // Deprecated section
        // If there is no point of interest, exit update
        //if (POI == null) return;
        //Vector3 destination = POI.transform.position;

        Vector3 destination;
        if (POI == null)
            destination = Vector3.zero;
        else
        {
            destination = POI.transform.position;
            if(POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                }
            }
        }
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        // Interpolate from current camera position towards destination 
        destination = Vector3.Lerp(transform.position, destination, easing);
        
        destination.z = camZ;
        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
