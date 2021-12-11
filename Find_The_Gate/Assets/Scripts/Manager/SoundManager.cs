using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource audioSource;

    public AudioClip titleBgm;
    public AudioClip mainBgm;
    public AudioClip tutorialBgm;

    public bool soundPaused = false;
    bool playOnce;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (soundPaused == true && playOnce == false)
        {
            audioSource.Pause();
            playOnce = true;
        }
        else if (soundPaused == false && playOnce == true)
        {
            audioSource.Play();
            playOnce = false;
        }
    }

    public IEnumerator SelectBGM(string name)
    {
        if (name == "TitleScene")
        {
            audioSource.clip = titleBgm;
            yield return new WaitForSeconds(0.2f);
            audioSource.Play();
        }
        else if (name == "TutorialScene")
        {
            audioSource.clip = tutorialBgm;
            yield return new WaitForSeconds(0.2f);
            audioSource.Play();
        }
        else if (name == "MainGameScene")
        {
            audioSource.clip = mainBgm;
            yield return new WaitForSeconds(0.2f);
            audioSource.Play();
        }
    }
}
