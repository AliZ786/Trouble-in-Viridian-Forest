using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    AudioSource pokeball;
    public int witchHealth = 3;
    public static int lives = 5;
    public int level = 0;
    public int target = 50;

    [SerializeField]
    float shootSpeed = 0.3f;
    float shootTimer = 0;
    int ghosts;

    // Start is called before the first frame update
    void Start()
    {
        //restarts values when playing the game
        lives = 5;
        Score.scoreValue = 0;
        target = 50;
        level = 0;
        Movement.moveSpeed = 1f;
        Spawner.specialMode = false;
        Spawner.ghostSpawn = 2f;
        Spawner.witchSpawn = 4f;
       

        pokeball = this.transform.GetComponent<AudioSource>();
        GameObject.Find("Lives").GetComponent<TextMeshProUGUI>().text = "Lives: " + lives;
        GameObject.Find("Level").GetComponent<TextMeshProUGUI>().text = "Level: " + level;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            pokeball.Play();
            pokeball.volume = 1.0f;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

            ghosts = 0;
            if (hits.Length != 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {

                    if (hits[i].collider.gameObject.tag == "Ghost")
                    {
                        ghosts++;
                        Debug.Log(hits[i].collider.gameObject.name);
                        Destroy(hits[i].collider.gameObject);
                        hits[i].collider.attachedRigidbody.AddForce(Vector2.up);
                        Score.scoreValue += 3;
                    }

                    else if (hits[i].collider.gameObject.tag == "Witch")
                    {
                        Debug.Log(hits[i].collider.gameObject.name);
                        hits[i].collider.GetComponent<Witch>().minusHP();
                        if (hits[i].collider.GetComponent<Witch>().wHP() == 0)
                        {
                            Destroy(hits[i].collider.gameObject);
                            hits[i].collider.attachedRigidbody.AddForce(Vector2.up);
                            Score.scoreValue += 5;

                        }

                    }

                }
            }
            else
            {
                pokeball.volume = 0f;
                lives--;
                Score.scoreValue -= 1;
                GameObject.Find("Gengar").GetComponent<Animation>().Play();
                Debug.Log(lives);
                Debug.Log("Mois");
            }



            if (ghosts > 1)
            {
                for (int i = 0; i < ghosts; i++)
                {
                    Score.scoreValue += 2.5;
                }
            }

            if (Score.scoreValue >= target)
            {
                level++;
                target += 50;
                Movement.moveSpeed++;
            }
            if(Score.scoreValue < 0)
                {
                Score.scoreValue = 0;
            }

        }
        else if (Spawner.specialMode)

        {


            shootTimer += Time.deltaTime;
            if (shootTimer > shootSpeed)
            {
                shootTimer = 0;

                if (Input.GetMouseButton(0))
                {
                    pokeball.Play();
                    pokeball.volume = 1.0f;

                    Vector3 newMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 newmousePos2D = new Vector2(newMousePos.x, newMousePos.y);

                    RaycastHit2D[] hits = Physics2D.RaycastAll(newmousePos2D, Vector2.zero);

                    ghosts = 0;
                    if (hits.Length != 0)
                    {
                        for (int i = 0; i < hits.Length; i++)
                        {

                            if (hits[i].collider.gameObject.tag == "Ghost")
                            {
                                ghosts++;
                                Debug.Log(hits[i].collider.gameObject.name);
                                Destroy(hits[i].collider.gameObject);
                                hits[i].collider.attachedRigidbody.AddForce(Vector2.up);
                                Score.scoreValue += 1;
                            }

                            else if (hits[i].collider.gameObject.tag == "Witch")
                            {
                                Debug.Log(hits[i].collider.gameObject.name);
                                hits[i].collider.GetComponent<Witch>().minusHP();
                                if (hits[i].collider.GetComponent<Witch>().wHP() == 0)
                                {
                                    Destroy(hits[i].collider.gameObject);
                                    hits[i].collider.attachedRigidbody.AddForce(Vector2.up);
                                    Score.scoreValue += 1;

                                }

                            }

                        }
                    }
                    else
                    {
                        pokeball.volume = 0f;
                        Score.scoreValue -= 2;
                        GameObject.Find("Gengar").GetComponent<Animation>().Play();
                        Debug.Log(lives);
                        Debug.Log("Mois");
                    }

                    if (ghosts > 1)
                    {
                        for (int i = 0; i < ghosts; i++)
                        {
                            Score.scoreValue += 2.5;
                        }
                    }

                    if (Score.scoreValue >= target)
                    {
                        level++;
                        target += 50;
                        Movement.moveSpeed++;
                    }

                    if(Score.scoreValue < 0)
                {
                        Score.scoreValue = 0;
                    }


                }
                   
            }
        }

        GameObject.Find("Lives").GetComponent<TextMeshProUGUI>().text = "Lives: " + lives;
        GameObject.Find("Level").GetComponent<TextMeshProUGUI>().text = "Level: " + level;

    }

}


