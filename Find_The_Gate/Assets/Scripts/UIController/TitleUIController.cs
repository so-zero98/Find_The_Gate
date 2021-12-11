using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleUIController : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject selectStagePanel;
    public GameObject quitPanel;
    public GameObject backGroundObject;

    public AudioClip buttonSound;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SoundManager.instance.SelectBGM("TitleScene"));
        audioSource.clip = buttonSound;
        selectStagePanel.SetActive(false);
        quitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            titlePanel.SetActive(false);
            quitPanel.SetActive(true);
        }
    }

    public void OnStartButtonClick()
    {
        audioSource.Play();
        backGroundObject.SetActive(false);
        titlePanel.SetActive(false);
        selectStagePanel.SetActive(true);
    }

    public void OnTutorialButtonClick()
    {
        audioSource.Play();
        SceneManager.LoadScene(2);
    }

    public void OnSelectStageButtonClick()
    {
        audioSource.Play();
        titlePanel.SetActive(false);
        selectStagePanel.SetActive(true);
    }

    public void OnStageButtonClick()
    {
        audioSource.Play();
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

        if (clickedButton.name == "Stage1Button")
        {
            GameManager.stage = 1;
        }
        else if (clickedButton.name == "Stage2Button")
        {
            GameManager.stage = 2;
        }
        else if (clickedButton.name == "Stage3Button")
        {
            GameManager.stage = 3;
        }
        else if (clickedButton.name == "Stage4Button")
        {
            GameManager.stage = 4;
        }
        else if (clickedButton.name == "Stage5Button")
        {
            GameManager.stage = 5;
        }
        else if (clickedButton.name == "Stage6Button")
        {
            GameManager.stage = 6;
        }
        else if (clickedButton.name == "Stage7Button")
        {
            GameManager.stage = 7;
        }
        else if (clickedButton.name == "Stage8Button")
        {
            GameManager.stage = 8;
        }
        else if (clickedButton.name == "Stage9Button")
        {
            GameManager.stage = 9;
        }
        else if (clickedButton.name == "Stage10Button")
        {
            GameManager.stage = 10;
        }

        SceneManager.LoadScene(1);
    }

    public void OnBackButtonClick()
    {
        audioSource.Play();
        selectStagePanel.SetActive(false);
        backGroundObject.SetActive(true);
        titlePanel.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
        audioSource.Play();
        titlePanel.SetActive(false);
        quitPanel.SetActive(true);
    }

    public void OnYesButtonClick()
    {
        audioSource.Play();
        Application.Quit();
    }

    public void OnNoButtonClick()
    {
        audioSource.Play();
        quitPanel.SetActive(false);
        titlePanel.SetActive(true);
    }
    public void OnTestButtonClick()
    {
        audioSource.Play();
        SceneManager.LoadScene(3);
    }

}
