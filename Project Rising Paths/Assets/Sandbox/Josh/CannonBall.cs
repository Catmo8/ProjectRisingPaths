using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float lifeTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0) {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0){
                Destruction();
            }
        }
        
    }

    void Destruction() {
        Destroy(this.gameObject);
    }
}
