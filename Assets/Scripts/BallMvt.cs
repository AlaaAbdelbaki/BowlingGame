using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMvt : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    int score = 0;
    GameObject[] pins;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        pins = GameObject.FindGameObjectsWithTag("Pin");
      

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 acc= Input.acceleration;

        //if (acc.z > .6)
        //{
        //    rb.AddForce(0, 0, speed * 10000 * Time.deltaTime);
        //}
        //SoundManager.playBallSound();
        Vector3 position = rb.transform.position;

        if(Input.GetKeyUp(KeyCode.Return))
        {
            rb.AddForce(0, 0, speed * 30000 * Time.deltaTime);
        }
            position += Vector3.right * Input.GetAxis("Horizontal") *3 *Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -4f, 4f);
            rb.transform.position = position;
            CountPinsDown();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pin")
        {
            Handheld.Vibrate();
            SoundManager.playStrikeSound();
            
        }
             
    }

    void CountPinsDown()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
        }
        Debug.Log(score);
    }

}
