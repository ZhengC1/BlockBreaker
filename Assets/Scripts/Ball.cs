using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballAudioClips;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    Vector2 paddleBallGap;
    bool hasStarted = false;

    // Cached component reference
    AudioSource myAudioSource;

    void Start() {
        paddleBallGap = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }
    private void LaunchOnClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle() {
       Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
       transform.position = paddlePos + paddleBallGap;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (hasStarted) {
            AudioClip clip = ballAudioClips[UnityEngine.Random.Range(0, ballAudioClips.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
