using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;
    float audioFadeRate = 2.5f;
    float audioStartVolume = 1f;

    [SerializeField] float rocketThrustSpeed = 100f;
    [SerializeField] float rocketRotationSpeed = 100f;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        Thrust();
        Rotate();
    }

    void OnCollisionEnter(Collision collision) {
        switch (collision.gameObject.tag) {
            case "Friendly":
                print("OK");
                break;
            case "Fuel":
                print("Fuel");
                break;
            default:
                print("Dead");
                // Kill the player
                break;
        }
    }

    private void Thrust() {     
        float thrustSpeedThisFrame = rocketThrustSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector3.up * thrustSpeedThisFrame);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
            audioSource.volume = audioStartVolume;
        } else {
            FadeAudioOut();
        }
    }

    private void Rotate() {
        rigidBody.freezeRotation = true;
        float rotationSpeedThisFrame = rocketRotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * rotationSpeedThisFrame);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-Vector3.forward * rotationSpeedThisFrame);
        }
        rigidBody.freezeRotation = false;
    }

    private void FadeAudioOut() {
        if (audioSource.volume > 0) {
            audioSource.volume -= audioFadeRate * Time.deltaTime;
            if (audioSource.volume <= 0) {
                audioSource.Stop();
            }
        }
    }
}
