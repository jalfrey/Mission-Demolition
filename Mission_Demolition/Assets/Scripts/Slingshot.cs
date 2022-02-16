/*
 * 
 * Created by: Jason Alfrey
 * Created date: 2/9/2022
 * 
 * Description: Provides slingshot mechanics. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    static private Slingshot S; 


    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMultiplier = 8f;
    
    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 LaunchPos;
    public GameObject projectile;
    public bool aimingMode;
    public Rigidbody projectileRB;
    
    static public Vector3 LAUNCH_POS
    {
        get { if (S == null) return Vector3.zero;
            return S.LaunchPos;
        } 
    }

    private void Awake()
    {
        S = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");
        
        launchPoint = launchPointTrans.gameObject;

        // disable launchPoint
        launchPoint.SetActive(false); 
       
        LaunchPos = launchPointTrans.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!aimingMode) return;

        // Get mouse position from 2D coordinates
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - LaunchPos;

        // Limit the mouse delta to the slingshot radius
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        if(mouseDelta.magnitude > maxMagnitude)
        {
            // Sets vector to the same direction with a length of one
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }


        // Move projectile to new position
        Vector3 projectilePos = LaunchPos + mouseDelta;
        projectile.transform.position = projectilePos;
        
        // Determine whether the mouse button has been released
        if(Input.GetMouseButtonUp(0))
        {
            aimingMode = false;

            // need to assign variable 
            projectileRB.isKinematic = false;
            projectileRB.velocity = -mouseDelta * velocityMultiplier;

            // need to add here 
            projectile = null;
        }

    }

    private void OnMouseEnter()
    {
        launchPoint.SetActive(true);
        print("Slingshot: On Mouse Enter");
    }

    private void OnMouseExit()
    {
        launchPoint.SetActive(false);
        print("Slingshot: On Mouse Exit");
    }

    private void OnMouseDown()
    {
        aimingMode = true;
        projectile = Instantiate(prefabProjectile) as GameObject;
//   LaunchPos = launchPointTrans;
        projectile.transform.position = LaunchPos;
        //need to assign variable 
        projectileRB.GetComponent<Rigidbody>().isKinematic = true;
        projectileRB.isKinematic = true;
    }
}
