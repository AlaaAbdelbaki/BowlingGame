using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; //player gameObject
    public Vector3 offset; //Distance between the player and camera

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (player && player.transform.position.z < 60)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            
            return;
        }
    }
}
