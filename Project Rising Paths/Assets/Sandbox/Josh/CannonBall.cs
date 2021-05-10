using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float lifeTime = 5f;
    public GameObject cannonBall;
    Rigidbody impact;
    public CannonController cannon;
    Rigidbody cannonballRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        /*
        if (lifeTime > 0) {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0){
                Destruction();
            }
        }
        
        */
    }

    void Destruction() {
        Destroy(cannonballRB);
    }

    
    void OnCollisionEnter(Collision collision) {
    if (collision.collider.tag == "Player") {
      impact = collision.gameObject.GetComponent<Rigidbody>();
      impact.AddForce(Vector3.forward * 50);
    }
  }
}
