using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    public GameObject leftGoalPoint;
    public GameObject rightGoalPoint;
    public GameObject upGoalPoint;
    public GameObject downGoalPoint;
    public GameObject map;
    public GameObject goalPoints;

    public Image firstGoalImage;
    public Image secondGoalImage;
    public Image thirdGoalImage;
    public Image fourthGoalImage;

    AudioSource audioSource;

    public AudioClip completeSound;

    public TutorialPlayerController player;
    public SoundManager soundManager;

    public Text tutorialText;
    public Image textBackground;

    public int order = 1;
    public int done;
    public int clearObj;
    public bool isStart;

    bool isAudioPlayed;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        player = GameObject.Find("Player").GetComponent<TutorialPlayerController>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SoundManager.instance.SelectBGM("TutorialScene"));
        audioSource.clip = completeSound;
        firstGoalImage.enabled = false;
        secondGoalImage.enabled = false;
        thirdGoalImage.enabled = false;
        fourthGoalImage.enabled = false;
        StartCoroutine(TutorialText(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isSet == true && order == 1 && isStart == true)
        {
            audioSource.Play();
            done = 1;
            order = 2;
            isStart = false;
            StartCoroutine(TutorialText(2));
        }
        else if (player.isSet == true && order == 2 && done == 1 && isStart == true)
        {
            if (clearObj == 1 && isAudioPlayed == false)
            {
                audioSource.Play();
                isAudioPlayed = true;
                firstGoalImage.color = new Color(0, 255f / 255f, 0);
            }
            else if (clearObj == 2 && isAudioPlayed == true)
            {
                audioSource.Play();
                isAudioPlayed = false;
                secondGoalImage.color = new Color(0, 255f / 255f, 0);
            }
            else if (clearObj == 3 && isAudioPlayed == false)
            {
                audioSource.Play();
                isAudioPlayed = true;
                thirdGoalImage.color = new Color(0, 255f / 255f, 0);
            }
            else if (clearObj == 4 && isAudioPlayed == true)
            {
                audioSource.Play();
                isAudioPlayed = false;
                fourthGoalImage.color = new Color(0, 255f / 255f, 0);
                done = 2;
                order = 3;
                isStart = false;
                StartCoroutine(TutorialText(3));
            }
        }
    }

    IEnumerator TutorialText(int orderNum)
    {
        if (orderNum == 1)
        {
            order = 1;
            yield return new WaitForSeconds(0.5f);
            tutorialText.text = "안녕하세요";
            yield return new WaitForSeconds(2.5f);
            tutorialText.text = "게임을 시작하기에 앞서";
            yield return new WaitForSeconds(2.5f);
            tutorialText.text = "게임 방법을 알려드리겠습니다";
            yield return new WaitForSeconds(2.5f);
            tutorialText.text = "먼저 컨트롤러 좌측의 버튼을 꾹 눌러보세요";
            yield return new WaitForSeconds(3f);
            tutorialText.enabled = false;
            textBackground.enabled = false;
            isStart = true;
        }
        else if (orderNum == 2 && done == 1)
        {
            order = 2;
            yield return new WaitForSeconds(0.5f);
            tutorialText.enabled = true;
            textBackground.enabled = true;
            tutorialText.text = "좋습니다";
            yield return new WaitForSeconds(2.5f);
            tutorialText.text = "이번에는 좌측 버튼을 누른 채로";
            yield return new WaitForSeconds(2.5f);
            tutorialText.text = "컨트롤러를 양옆과 앞뒤로 기울여서";
            yield return new WaitForSeconds(2.5f);
            tutorialText.text = "맵에 보이는 초록색 목표 지점들로 가보세요";
            yield return new WaitForSeconds(2.5f);
            tutorialText.enabled = false;
            textBackground.enabled = false;
            map.gameObject.SetActive(true);
            goalPoints.gameObject.SetActive(true);
            firstGoalImage.enabled = true;
            secondGoalImage.enabled = true;
            thirdGoalImage.enabled = true;
            fourthGoalImage.enabled=true;
            isStart = true;
        }
        else if (orderNum == 3 && done == 2)
        {
            order = 3;
            yield return new WaitForSeconds(0.5f);
            tutorialText.enabled = true;
            textBackground.enabled = true;
            tutorialText.text = "좋습니다";
            yield return new WaitForSeconds(2.5f);
            tutorialText.text = "이전까지의 방법들로";
            yield return new WaitForSeconds(2.5f);
            tutorialText.text = "미로에서 출구를 찾으시면 됩니다";
            yield return new WaitForSeconds(2.5f);
            tutorialText.text = "메인 메뉴로 돌아갑니다";
            yield return new WaitForSeconds(2.5f);
            tutorialText.enabled = false;
            textBackground.enabled = false;
            SceneManager.LoadScene(0);
        }
    }
}
