using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{

    private Rigidbody thisRigidBody;

    public float forceJump = 10;

    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0;

    public AudioSource[] Sounds = new AudioSource[3];

    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isGameActive = Gamemanager.instance.IsGameActive();
        jumpCooldown -= Time.fixedDeltaTime;
        bool canJump = jumpCooldown <= 0 && isGameActive;
        if (canJump){
            bool isJump = Input.GetKey(KeyCode.Space);
            if (isJump){
                Jump();
            }
        }
        if (isGameActive == false)
        {
            this.thisRigidBody.velocity = Vector3.zero;
            thisRigidBody.useGravity = isGameActive;
        }
    }

    private void Jump(){
        Sounds[0].Play();
        // cooldown reset
        jumpCooldown = jumpInterval;
        //reset forceDown
        this.thisRigidBody.velocity = Vector3.zero;
        // add force jump
        thisRigidBody.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);

    }

    private void OnTriggerEnter(Collider other)
    {
        bool isSensor = other.gameObject.CompareTag("sensor");
        if (isSensor)
        {
            Sounds[1].Play();
            var gameManager = Gamemanager.instance;
            gameManager.Points++;
            gameManager.tubeSpeed += 0.2f;
            gameManager.tubeInterval -= 0.1f;


        }
}
    private void OnCollisionEnter(Collision other)
    {
        Sounds[2].Play();
        Gamemanager.instance.endGame();
    }

}
