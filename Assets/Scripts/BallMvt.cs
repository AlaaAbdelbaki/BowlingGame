using UnityEngine;

public class BallMvt : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Debug.Log(rb.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 acc = Input.acceleration;

        //if (acc.z > .6)
        //{
        //    rb.AddForce(0, 0, speed * 10000 * Time.deltaTime);
        //}
        //SoundManager.playBallSound();
        Vector3 position = rb.transform.position;

        if (Input.GetKeyUp(KeyCode.Return))
        {
            rb.AddForce(0, 0, speed * 20000 * Time.deltaTime);
        }
            position += Vector3.right * Input.GetAxis("Horizontal") *3 *Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -4f, 4f);
            rb.transform.position = position;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pin")
        {
            Handheld.Vibrate();
            SoundManager.playStrikeSound();
            
        }
             
    }


}
