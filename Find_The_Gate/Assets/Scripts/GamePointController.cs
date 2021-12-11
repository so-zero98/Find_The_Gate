using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePointController : MonoBehaviour
{
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
            GameManager.instance.whatState = GameManager.GameState.clear;
        }
    }
}
