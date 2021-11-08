using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] pins;
    public GameObject ball;
    int turnCounter = 0;
    int score = 0;
    public Text ScoreUi;
    Vector3[] positions;  
    // Start is called before the first frame update
    void Start()
    {

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length];
        for (int i = 0; i < pins.Length; i++)
        {
            positions[i] = pins[i].transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if( ball.transform.position.y < -20 )
        {
            CountPinsDown();
            turnCounter++;
            ResetPins();
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
        ScoreUi.text = score.ToString();
    }

    void ResetPins()
    {
        for(int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(true);
            pins[i].transform.position = positions[i];
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.rotation = Quaternion.identity;
        }

        ball.transform.position = new Vector3(-0.1f, 0.8f, -85.3f);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;
    }

}
