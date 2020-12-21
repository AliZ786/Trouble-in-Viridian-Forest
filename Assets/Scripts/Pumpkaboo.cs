using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkaboo : MonoBehaviour
{
    public GameObject pumpkaboo;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pumpkaboo, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

      
        }

    void OnCollisionEnter2D()
    {
        Debug.Log("OnCollisionEnter2D");
    }


}


