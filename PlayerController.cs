using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    public GameObject WhiteGraphics;
    public RuntimeAnimatorController BlackWave, BlackIdle;
    public int Counter;
    public bool IsWaving;
    public AudioClip[] WaveSound;

    public AudioSource Source;

    void Start()
    {
        Source.GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayerWave();
    }

    // waves on click
    void PlayerWave()
    {
        if (Input.GetKey(KeyCode.Mouse0) == true)
        {
            IsWaving = true;
            WhiteGraphics.GetComponent<Animator>().runtimeAnimatorController = BlackWave;

            Source.GetComponent<AudioSource>().clip = WaveSound[UnityEngine.Random.Range(0, WaveSound.Length)];
            Source.PlayOneShot(WaveSound[UnityEngine.Random.Range(0, WaveSound.Length)]);
        }
        if (Input.GetKey(KeyCode.Mouse0) == false)
        {
            IsWaving = false;
                WhiteGraphics.GetComponent<Animator>().runtimeAnimatorController = BlackIdle;
        }
    }
}