using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteSpawning : MonoBehaviour
{
    public GameObject NewSpawn;
    public GameObject White;

    public RuntimeAnimatorController WhiteWave;

    public Transform[] SP = new Transform[17];

    public PlayerController Player;
    public float SpawnInterval = 20;
    public float SpawnLifetime = 3;
    private float StartTime;

    void Start()
    {
        StartTime = Time.time;
    }

    void Update()
    {
            if (StartTime + SpawnInterval < Time.time)
            {
                Spawn();
                StartTime = Time.time;
            }
            Kill();

        // potential score system
        if (GameObject.Find("White(Clone)") != null && Player.IsWaving == true)
        {
            Player.Counter++;
            print("Score!");
            print(Player.Counter);
        }
        else if (GameObject.Find("White(Clone)") == null && Player.IsWaving == true)
        {
            Player.Counter--;
            print("Miss...");
        }
        else if (GameObject.Find("White(Clone)") == null && Player.IsWaving == false)
        {
            print("Nothing.");
        }
        else if (GameObject.Find("White(Clone)") != null && Player.IsWaving == false)
        {
            Player.Counter--;
            print("Didn't kill");
        }
    }

    void Spawn()
    {
        int RandomPlace = Random.Range(0, SP.Length);

        // create an instance of the white spawn at a random spawn point
        NewSpawn = Instantiate(White, SP[RandomPlace].transform.position, SP[RandomPlace].transform.rotation);
        NewSpawn.transform.localScale = SP[RandomPlace].transform.localScale;

        // assigns the waving animation to the new white spawn
        NewSpawn.GetComponent<Animator>().runtimeAnimatorController = WhiteWave;
    }

    // kills the new white spawn after a set time or a click, or a touch
    void Kill()
    {
        if (StartTime + SpawnLifetime < Time.time || Input.GetKey(KeyCode.Mouse0) || Input.GetTouch(0).pressure == 1.0f)
        {
            Destroy(NewSpawn, 0.5f);
        }
    }

    // fun infinite loop escape
    /*void Escape()
    {
        int SafeEscape = 0;
        while (true)
        {
            SafeEscape++;
            if (SafeEscape < 10000)
            {
                break;
            }
        }
    }*/
} 