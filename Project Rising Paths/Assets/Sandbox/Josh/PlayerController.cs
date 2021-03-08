using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   float horizontal;
   float vertical;
   public float moveSpeed = 5.0f;

   private void Update(){
       Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;
       transform.position += moveDirection * moveSpeed * Time.deltaTime;
   }
    
    public void OnMoveInput(float horizontal, float vertical){
        this.vertical = vertical;
        this.horizontal = horizontal;
         Debug.Log($"Player Contoller: Move Input: {vertical}, {horizontal}");
    }
}
