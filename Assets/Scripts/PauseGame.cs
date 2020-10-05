using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject Pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ExitAll()
    {
        Application.Quit();
    }

    public void Exittomenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);
    }
}
