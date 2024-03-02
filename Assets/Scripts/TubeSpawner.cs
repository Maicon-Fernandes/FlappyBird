using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{

    private float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var gameManager = Gamemanager.instance;
        if (gameManager.IsGameOver()){
            return;
        }
        cooldown -= Time.deltaTime;
        if(cooldown <= 0f)
        {
            cooldown = gameManager.tubeInterval;

            int prefabIndex = Random.Range(0, gameManager.tubePrefabs.Count);
            GameObject prefab = gameManager.tubePrefabs[prefabIndex];

            float x = gameManager.tubeOffSetX;
            float y = Random.Range(gameManager.tubeOffSetY.x, gameManager.tubeOffSetY.y);
            float z = -2;

            Vector3 position = new Vector3(x,y,z);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, prefab.transform.rotation);

            
        }
    }
}
