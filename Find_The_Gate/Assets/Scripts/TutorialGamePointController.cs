using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGamePointController : MonoBehaviour
{
    public static int clearObj;

    AudioSource audioSource;

    public AudioClip goalPointSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = goalPointSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            TutorialManager.instance.clearObj += 1;
            Destroy(gameObject);
        }
    }
}
