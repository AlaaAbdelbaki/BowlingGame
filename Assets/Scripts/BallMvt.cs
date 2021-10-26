using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMvt : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    public AudioSource audioData;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
            audioData.Play(0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.transform.Translate(-2 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.transform.Translate(2 * Time.deltaTime, 0, 0);
        }
    }
}
