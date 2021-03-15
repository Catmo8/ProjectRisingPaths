using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public Transform body;

    private PhotonView photonView;

    private Transform bodyObject;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        PlayerController runner = FindObjectOfType<PlayerController>();
        bodyObject = runner.transform.Find("Player Model");

        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            MapPosition(body, bodyObject);
            //UpdateAnimator();
        }
    }
    void MapPosition(Transform target, Transform bodyTransform)
    {
        Debug.Log("Position:" + bodyTransform.position);
        Debug.Log("Rotation:" + bodyTransform.rotation);
        target.position = bodyTransform.position;
        target.rotation = bodyTransform.rotation;
    }
}
