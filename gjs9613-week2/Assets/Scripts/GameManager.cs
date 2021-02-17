using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public TextMesh text;
    public int score = 0;
    public int targetScore = 1;
    private int currentLvl = 1;
    
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(gameObject);
        
        //find and arrange all barriers
        GameObject[] barriers = GameObject.FindGameObjectsWithTag("Barrier");

        for (int i = 0; i < barriers.Length; i++)
        {
            float rand = Random.Range(1, 3);
Debug.Log(rand);
            //fancy ternary oo la la (if rand is greater than 0.5, yPos is -14, otherwise it's -16)
            int yPos = rand >= 2 ? -14 : -16;
            barriers[i].transform.localPosition = new Vector2(Random.Range(-71, -73) - i*3, yPos);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.localPosition = new Vector2(10.26f, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;

        if (score >= targetScore || SceneManager.GetActiveScene().name == "3")
        {
            currentLvl++;
            targetScore++;
            Debug.Log(currentLvl);
            SceneManager.LoadScene(currentLvl.ToString());
        }
    }
}
