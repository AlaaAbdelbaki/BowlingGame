using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{

    public GameObject[] pins;
    public GameObject ball;
    private Transform ballPos;
    public Text[] scrs;
    public Text[] scrsRound;
    int turnCounter = 1;
    int RoundCounter = 1;
    int[] scrsValues = { 0,0,0,0,0,0,0,0,0,0 };
    ArrayList scrsTotalValues = new ArrayList() ;
    int score = 0;
    public Text ScoreUi;
    Vector3[] positions;
    public GameObject ScoreTable;
    public HighScore highScore; 
    // Start is called before the first frame update
    void Start()
    {
        /*foreach(Transform item in ball.transform)
        {
            if(item.tag == "Ball")
            {
                ball = item.gameObject;
            }
        }*/
        ballPos = ball.transform;
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
        //Debug.Log(pins[0].gameObject.transform.position);
        //ballPos.position = pins[0].gameObject.transform.position;
        if (turnCounter > 10)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if ( ball.transform.position.y < -20 )
        {
            Debug.Log("Ball fell");
            CountPinsDown();
            scrs[turnCounter-1].text = scrsValues[turnCounter-1].ToString();
            scrs[turnCounter-1].gameObject.SetActive(true);
           // CheckIfPinsActive();
            ResetPins();
        }

        

        

    }
    void CheckIfPinsActive ()
    {
        int p=0;
        for (int i = 0; i < pins.Length; i++)
        {
            if(pins[i].activeSelf)
            {
                p++;
            }
        }
        if (p > 0)
        {
            turnCounter++;
        }
        else if (p == 0 && turnCounter % 2 != 0)
        {
            turnCounter = turnCounter+2;
            int TotalScrForEachRounds = (scrsValues[turnCounter - 3] + scrsValues[turnCounter - 2]) * 80;
            scrsTotalValues.Add(TotalScrForEachRounds);
            scrsRound[(turnCounter - 3) / 2].text = scrsTotalValues[(turnCounter - 3) / 2].ToString();
            scrsRound[(turnCounter - 3) / 2].gameObject.SetActive(true);

        }
        else if (p == 0 && turnCounter % 2 == 0)
        {
            turnCounter++;
        }
            
    }
    void CountPinsDown()
    {
        int pinsDown=0;
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
                
            }
        }
        scrsValues[turnCounter - 1] = score;
        score = 0;

        if (turnCounter % 2 == 0)
        {

            int TotalScrForEachRounds = (scrsValues[turnCounter - 2] + scrsValues[turnCounter - 1]) * 80;
            scrsTotalValues.Add(TotalScrForEachRounds);
            scrsRound[(turnCounter - 2) / 2].text = scrsTotalValues[(turnCounter - 2) / 2].ToString();
            scrsRound[(turnCounter - 2) / 2].gameObject.SetActive(true);

        }
        else
        {

        }

        

        ScoreUi.text = score.ToString();
        if (score > highScore.highScore )
        {
            highScore.highScore = score;
        }
        
    }

    void ResetPins()
    {
        CheckIfPinsActive();


        for (int i = 0; i < pins.Length; i++)
        {
            if (turnCounter % 2 != 0)
            {
                pins[i].SetActive(true);

            }
            pins[i].transform.position = positions[i];
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.rotation = Quaternion.identity;
        }

        /*ball.transform.position = new Vector3(-0.1f, 0.8f, -85.3f);*/
        /*ball.transform.position = new Vector3(0.3f, 0f, -4f);*/
        Debug.Log(pins[0].gameObject.transform.position);
        ball.transform.position = pins[pins.Length-1].transform.position + new Vector3(0, 2f, -5f);
        //Debug.Log(ballPos.position - new Vector3(0f, 1f, 5f));
        //Vector3 pos = new Vector3(0, 2f, -50f);
        /*ball.transform.position = ballPos.position;*/
        Debug.Log(ball.transform.position);
        /*ball.transform.position = pins[0].gameObject.transform.position-new Vector3(0,0,5);*/
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;

    }

}
