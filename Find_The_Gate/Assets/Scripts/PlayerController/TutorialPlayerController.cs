using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Renderer playerColor;

    Rigidbody rigidBody;

    Vector3 movement;

    public float testValue;

    float horizontal;
    float vertical;

    public bool isSet;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerColor = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerColor.material.color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    horizontal = Random.Range(-1, 2);
        //    vertical = Random.Range(-1, 2);
        //}

        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space) && (TutorialManager.instance.order == 1 || TutorialManager.instance.order == 2) &&
            TutorialManager.instance.isStart == true)
        {
            playerColor.material.color = new Color(255f / 255f, 235f / 255f, 0);
            isSet = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            playerColor.material.color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
            isSet = false;
        }

    }

    void FixedUpdate()
    {
        //if (horizontal < 0)
        //    horizontal = -1;
        //else if (horizontal == 0)
        //    horizontal = 0;
        //else if (horizontal > 0)
        //    horizontal = 1;

        //if (vertical < 0)
        //    vertical = -1;
        //else if (vertical == 0)
        //    vertical = 0;
        //else if (vertical > 0)
        //    vertical = 1;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if ((TutorialManager.instance.order == 2 && isSet == true && TutorialManager.instance.isStart == true))
            StartCoroutine(Move(horizontal, vertical));
    }

    IEnumerator Move(float hor, float ver)
    {
        movement.Set(hor, ver, 0);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        rigidBody.MovePosition(transform.position + movement);

        yield return null;
    }
}
