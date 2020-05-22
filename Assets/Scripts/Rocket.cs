using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;

    bool thrusting = false;
    bool playingSound = false;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        ProcessInput();
    }

    private void ProcessInput() {

        if (Input.GetKey(KeyCode.Space)) {
            print("Space pressed");
            rigidBody.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            audioSource.Stop();
        }

        if (Input.GetKey(KeyCode.A)) {
            print("Left pressed");
            transform.Rotate(Vector3.forward);
        } else if (Input.GetKey(KeyCode.D)) {
            print("Right pressed");
            transform.Rotate(-Vector3.forward);
        }
    }
}
