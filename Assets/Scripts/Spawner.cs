using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public static float spawnRate;
    public static float ghostSpawn = 2f;
    public static float witchSpawn = 4f;
    float nextSpawn = 0.0f;
    public float timeElapsed = 0;
    public static bool specialMode = false;
    GameObject countdownTimer;


    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Time").GetComponent<TextMeshProUGUI>().text = "Special Timer: 0 ";
        countdownTimer = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            specialMode = true;

            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            spawnRate = 1f;
                
          
        }

        if (specialMode)
        {
            timeElapsed = timeElapsed + Time.deltaTime;
            countdownTimer.GetComponent<TextMeshProUGUI>().text = "Special Timer " + timeElapsed;
            
            if (timeElapsed > 3)
            {
                timeElapsed = 0;
                specialMode = false;
            }
        }

        else if (Time.time > nextSpawn && enemy.tag == "Ghost")
        {
            spawnRate = ghostSpawn;
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-6.1f, 6.1f);
            randY = Random.Range(-4f, 4f);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);

        }

        else if (Time.time > nextSpawn && enemy.tag == "Witch")
        {
            spawnRate = witchSpawn;
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-6.1f, 6.1f);
            randY = Random.Range(-4f, 4f);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);


        }


        if (Shooting.lives == 0)
        {

            SceneManager.LoadScene(4);
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
            Destroy(objs[0]);
            Cursor.visible = true;




        }



    }
}