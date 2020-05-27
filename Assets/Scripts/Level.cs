using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] int blockCount; // Serialized for debugging
    SceneLoader sceneLoader;
    public void IncrementBlockCount() {
        blockCount++; 
    }

    public void DecrementBlockCount() {
        blockCount--; 
    }
 
    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>(); 
    }

    private void Update() {
        if (blockCount < 1) {
            sceneLoader.LoadNextScene();
        }
    }
}
