using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialUIController : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject pausedPanel;
    public GameObject askHomePanel;

    AudioSource audioSource;

    public AudioClip buttonSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = buttonSound;
        pausedPanel.SetActive(false);
        askHomePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPausedButtonClick()
    {
        audioSource.Play();
        Time.timeScale = 0;
        pausedPanel.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        audioSource.Play();
        Time.timeScale = 1;
        pausedPanel.SetActive(false);
    }

    public void OnRetryButtonClick()
    {
        audioSource.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void OnHomeButtonClick()
    {
        audioSource.Play();
        pausedPanel.SetActive(false);
        askHomePanel.SetActive(true);
    }

    public void OnYesButtonClick()
    {
        audioSource.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnNoButtonClick()
    {
        audioSource.Play();
        askHomePanel.SetActive(false);
        pausedPanel.SetActive(true);
    }
}