/*
 * 
 * Created by: Jason Alfrey
 * Created date: 2/14/2022
 * 
 * Description: Script to generate clouds. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int numberOfClouds = 40;
    public GameObject cloudPrefab;
    public Vector3 cloudPositionMinimum = new Vector3(-50, -5, 10);
    public Vector3 cloudPositionMax = new Vector3(150, 100, 10);
    public float cloudScaleMin = 1;
    public float cloudScaleMax = 3;
    float cloudSpeedMultiplier = 0.5f;

    private GameObject[] cloudInstances;

    private void Awake()
    {
        cloudInstances = new GameObject[numberOfClouds];
        GameObject anchor = GameObject.Find("CloudAnchor");

        GameObject cloud;
        for (int i = 0; i < numberOfClouds; i++)
        {
            cloud = Instantiate<GameObject>(cloudPrefab);

            // Position cloud
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPositionMinimum.x, cloudPositionMax.x);
            cPos.y = Random.Range(cloudPositionMinimum.y, cloudPositionMax.y);

            // Scale clouds
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

            // Smaller clouds with smaller scale are positioned closer
            // to the ground 
            cPos.y = Mathf.Lerp(cloudPositionMinimum.y, cPos.y, scaleU);
        }
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
