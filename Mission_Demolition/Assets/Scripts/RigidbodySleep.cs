/*
 * 
 * Created by: Jason Alfrey
 * Created date: 2/16/2022
 * 
 * Description: Script to put the rigidbody to sleep for the first frame update.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodySleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
