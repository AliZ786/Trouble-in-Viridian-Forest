
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
    public int wH;
    // Start is called before the first frame update
    void Start()
    {
        wH = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void minusHP()
        {
            wH--;
        }

    public int wHP()
    {
        return wH;
    }
}
