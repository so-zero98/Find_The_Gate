using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameUIController : MonoBehaviour
{
    enum YesState { home, quit };
    YesState whatYes;

    enum NoState { home, quit };
    NoState whatNo;

    enum HomeState { paused, clear };
    HomeState whatHome;

    public GameObject startPanel;
    public GameObject mainPanel;
    public GameObject pausedPanel;
    public GameObject clearPanel;
    public GameObject askHomePanel;
    public GameObject quitPanel;

    public Text startPanelStageText;
    public Text mainPanelStageText;
    public Text mainPanelTimeText;
    public Text clearPanelTimeText;

    public GameObject nextButton;

    public SoundManager soundManager;

    public AudioClip buttonSound;

    AudioSource audioSource;

    [SerializeField] Animator animator;

    void Awake()
    {
        animator = GameObject.Find("StartPanel").GetComponent<Animator>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SoundManager.instance.SelectBGM("MainGameScene"));
        audioSource.clip = buttonSound;
        mainPanel.SetActive(false);
        pausedPanel.SetActive(false);
        clearPanel.SetActive(false);
        askHomePanel.SetActive(false);
        quitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.whatState)
        {
            case GameManager.GameState.ready:
                startPanelStageText.text = GameManager.stage.ToString();
                animator.SetTrigger("onStart");
                break;
            case GameManager.GameState.game:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 0;
                    pausedPanel.SetActive(true);
                }

                mainPanelStageText.text = GameManager.stage.ToString();
                mainPanelTimeText.text = string.Format("{0:N2}", GameManager.instance.time);
                startPanel.SetActive(false);
                mainPanel.SetActive(true);
                break;
            case GameManager.GameState.clear:
                if(GameManager.stage>=5)
                {
                    nextButton.SetActive(false);
                }
                clearPanelTimeText.text = string.Format("{0:N2}",GameManager.instance.time);
                mainPanel.SetActive(false);
                clearPanel.SetActive(true);
                GameManager.instance.whatState = GameManager.GameState.clear + 1;
                whatHome = HomeState.clear;
                break;
        }
    }

    public void OnPausedButtonClick()
    {
        audioSource.Play();
        whatHome = HomeState.paused;
        Time.timeScale = 0;
        pausedPanel.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        audioSource.Play();
        Time.timeScale = 1;
        pausedPanel.SetActive(false);
    }

    public void OnNextButtonClick()
    {
        audioSource.Play();
        GameManager.instance.whatState = GameManager.GameState.ready;
        clearPanel.SetActive(false);
        mainPanel.SetActive(false);
        GameManager.stage += 1;
        startPanel.SetActive(true);
    }

    public void OnRetryButtonClick()
    {
        audioSource.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void OnHomeButtonClick()
    {
        audioSource.Play();

        if (whatHome == HomeState.paused)
        {
            pausedPanel.SetActive(false);
        }
        else if (whatHome == HomeState.clear)
        {
            clearPanel.SetActive(false);
        }

        whatYes = YesState.home;
        whatNo = NoState.home;
        askHomePanel.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
        audioSource.Play();
        whatYes = YesState.quit;
        whatNo = NoState.quit;
        pausedPanel.SetActive(false);
        quitPanel.SetActive(true);
    }

    public void OnYesButtonClick()
    {
        audioSource.Play();

        if (whatYes == YesState.home)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        else if (whatYes == YesState.quit)
            Application.Quit();
    }

    public void OnNoButtonClick()
    {
        audioSource.Play();

        if (whatNo == NoState.home)
        {
            if (whatHome == HomeState.paused)
            {
                pausedPanel.SetActive(true);
            }
            else if (whatHome == HomeState.clear)
            {
                clearPanel.SetActive(true);
            }

            askHomePanel.SetActive(false);
        }
        else if (whatNo == NoState.quit)
        {
            quitPanel.SetActive(false);
            pausedPanel.SetActive(true);
        }
    }
}
