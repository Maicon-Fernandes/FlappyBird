using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance { get; private set; }
    [FormerlySerializedAs("prefabs")]
    public List<GameObject> tubePrefabs;
    [HideInInspector]
    public int Points = 0;
    
    private bool isGameOver= false;

    public float tubeInterval = 1;
    public float tubeSpeed = 10;
    

    public float tubeOffSetX = 0;
    public Vector2 tubeOffSetY = new Vector2(0,0);
    



    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsGameActive()
    {
        return !isGameOver;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void endGame()
    {
        isGameOver = true;
        Debug.Log("GAME OVER, Your score is : " + Points + "point(s)");

        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay){
        yield return new WaitForSeconds(delay);
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
    
}
