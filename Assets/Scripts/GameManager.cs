using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button startButton;
    public Button pauseButton;
    public bool blueRocketCheck;
    public bool redRocketCheck;
    public GameObject blueRocket;
    public GameObject redRocket;
    public GameObject rulerEarth;
    public GameObject pauseScreen;
    public GameObject dice;

    public AudioClip btnSound, diceRollSound;
    AudioSource audioSource;

    [SerializeField]
    public DiceScript diceScript;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startButton.onClick.AddListener(StartRollDice);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Reset()
    {
        startButton.gameObject.SetActive(true);
        diceScript.Reset();
    }

    public void ShiftRocket(int diceNumber)
    {
        if (blueRocketCheck)
        {
            for(int i = 0; i < diceNumber; i++)
            {
                Vector3 lastPos = blueRocket.gameObject.transform.position;
                //Debug.Log(lastPos);
                blueRocket.gameObject.transform.position = new Vector3 (lastPos.x, lastPos.y += 0.08f, lastPos.z);
                //Debug.Log(blueRocket.gameObject.transform.position);
                //StartCoroutine(waiter());
            }
            //StartCoroutine(waiter());
            blueRocketCheck = false;
            redRocketCheck = true;
        }
        else if (redRocketCheck)
        {
            for(int i = 0; i < diceNumber; i++)
            {
                Vector3 lastPos = redRocket.gameObject.transform.position;
                redRocket.gameObject.transform.position = new Vector3 (lastPos.x, lastPos.y += 0.08f, lastPos.z);
            }
            redRocketCheck = false;
            blueRocketCheck = true;
        }
        //Vector3 lastPosRE = redRocket.gameObject.transform.position;
        //rulerEarth.gameObject.transform.position = new Vector3 (0 , lastPosRE.y -= 1 * Time.deltaTime, 0);
        StartCoroutine(waiter());   
    }

    void StartRollDice()
    {
        PlayDiceRollSound();
        diceScript.StartRollDice();
        startButton.gameObject.SetActive(false);
    }

    public void OnPauseButton ()
    {
        PlayBtnClickSound();
        pauseButton.gameObject.SetActive(false);
        dice.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResumeButton ()
    {
        PlayBtnClickSound();
        pauseScreen.gameObject.SetActive(false);
        dice.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void OnExitButton ()
    {
        PlayBtnClickSound();
        SceneManager.LoadScene(0);
    }

    public void PlayBtnClickSound() {
        audioSource.PlayOneShot(btnSound);
    }
    public void PlayDiceRollSound() {
        audioSource.PlayOneShot(diceRollSound);
    }

    IEnumerator waiter()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1f;
        Reset();
        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
