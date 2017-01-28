using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour {

    public float TimeDelay = 4.0f;
    public float StartTime;

    public GameObject StartButton;

    void Start ()
    {
        StartTime = Time.time;
    }

    void Update ()
    {
        if (StartTime + TimeDelay < Time.time)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetTouch(0).pressure == 1.0f)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene(1);
            }
        }
    }
}
