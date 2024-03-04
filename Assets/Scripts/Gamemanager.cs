using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance { get; private set; }
    [FormerlySerializedAs("prefabs")]
    public List<GameObject> tubePrefabs;
    [HideInInspector]
    public int Points = 0;
    public Text text__;

    public GameObject pauseMenu;
    public bool isPaused;
    
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
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        text__.text = "Points : " + Points.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
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

    private void PauseMenu()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }


}
