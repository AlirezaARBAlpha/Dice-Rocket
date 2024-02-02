using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Win : MonoBehaviour
{
    public Button pauseButton;
    public GameObject winScreen;
    public GameObject dice;
    public TMP_Text _winObject;

    public AudioClip gameWinSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
	{
        Debug.Log("win");
        Time.timeScale = 0f;
        PlayGameWinSound();
        pauseButton.gameObject.SetActive(false);
        dice.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(true);
        _winObject.text = col.name;
	}
    public void PlayGameWinSound()
    {
        audioSource.PlayOneShot(gameWinSound);
    }
}
