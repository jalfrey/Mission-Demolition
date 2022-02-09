/*
 * 
 * Created by: Jason Alfrey
 * Created date: 2/9/2022
 * 
 * Description: Camera to follow slingshot projectile. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;
    public float camZ;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        // If there is no point of interest, exit update
        if (POI == null) return;

        Vector3 destination = POI.transform.position;
        destination.z = camZ;
        transform.position = destination;
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
