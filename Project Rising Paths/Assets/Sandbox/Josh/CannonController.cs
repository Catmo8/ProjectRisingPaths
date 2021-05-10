using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    //Cannon Firing Variables
    public GameObject cannonBall;
    Rigidbody cannonballRB;
    public Transform shotPos;
    public GameObject explosion;
    public bool stopFiring = false;
    public float firePower;
    public float powerMult = 1;
    public float firstShot;
    public float fireRate;

    
    // Start is called before the first frame update
    void Start(){
        InvokeRepeating("FireCannon", firstShot, fireRate);
        firePower *= powerMult;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireCannon() {
        shotPos.rotation = transform.rotation;
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPos.position, shotPos.rotation) as GameObject;
        cannonballRB = cannonBallCopy.GetComponent<Rigidbody>();
        cannonballRB.AddForce(shotPos.forward * firePower);
        //Instantiate(explosion, shotPos.position, shotPos.rotation);
        if(stopFiring){
            CancelInvoke("FireCannon");
        }
    }
}
