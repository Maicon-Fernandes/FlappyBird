using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tubeMover : MonoBehaviour
{
    public float xDestroyTube = -30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var gameManager = Gamemanager.instance;
        if (gameManager.IsGameOver())
        {
            return;
        }

        float x = Gamemanager.instance.tubeSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);
    
        //Destroy gameobject
        if (transform.position.x <= xDestroyTube)
        {
            Destroy(gameObject);
        }
    }
}
