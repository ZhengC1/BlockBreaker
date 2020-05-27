using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip blockAudioClip;

    Level level;

    private void Start() {
        level = FindObjectOfType<Level>();
        level.IncrementBlockCount();
    }

    private void OnCollisionEnter2D(Collision2D col) {
        // destroy game object
        AudioSource.PlayClipAtPoint(blockAudioClip, Camera.main.transform.position);
        level.DecrementBlockCount();
        Destroy(gameObject);
    }
}
