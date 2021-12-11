using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState { ready, game, clear };

    [SerializeField] Transform playerPosition;
    [SerializeField] Transform goalPosition;

    [SerializeField] List<GameObject> stageList;
    [SerializeField] List<Transform> startPointList;
    [SerializeField] List<Transform> goalPointList;

    public GameState whatState = GameState.ready;

    public static int stage = 1;

    public float time = 0;

    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(whatState)
        {
            case GameState.ready:
                time = 0;
                StartCoroutine(SelectStage(stage));

                if (stageList[stage - 1].activeSelf == true)
                {
                    playerPosition.position = startPointList[stage - 1].position;
                    goalPosition.position = goalPointList[stage - 1].position;
                }
                break;
            case GameState.game:
                time += Time.deltaTime;
                break;
            case GameState.clear:
                break;
        }
    }

    IEnumerator SelectStage(int stageNumber)
    {
        if (stageNumber == 1)
        {
            stageList[0].SetActive(true);
        }
        else if (stageNumber == 2)
        {
            stageList[0].SetActive(false);
            stageList[1].SetActive(true);
        }
        else if (stageNumber == 3)
        {
            stageList[1].SetActive(false);
            stageList[2].SetActive(true);
        }
        else if (stageNumber == 4)
        {
            stageList[2].SetActive(false);
            stageList[3].SetActive(true);
        }
        else if (stageNumber == 5)
        {
            stageList[3].SetActive(false);
            stageList[4].SetActive(true);
        }
        else if (stageNumber == 6)
        {
            stageList[4].SetActive(false);
            stageList[5].SetActive(true);
        }
        else if (stageNumber == 7)
        {
            stageList[5].SetActive(false);
            stageList[6].SetActive(true);
        }
        else if (stageNumber == 8)
        {
            stageList[6].SetActive(false);
            stageList[7].SetActive(true);
        }
        else if (stageNumber == 9)
        {
            stageList[7].SetActive(false);
            stageList[8].SetActive(true);
        }
        else if (stageNumber == 10)
        {
            stageList[8].SetActive(false);
            stageList[9].SetActive(true);
        }

        yield return null;
    }
}
