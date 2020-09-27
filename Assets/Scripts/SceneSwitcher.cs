using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public int scene;
    private bool winState = false;

    void Update()
    {
        if (winState == true)
        {
            winState = false;
            SceneSwitch();
        }
    }

    public void setWinState(bool set)
    {
        winState = set;
    }

    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("player crossed");
        //if (other.gameObject.tag == "player")
        SceneSwitch();
    }
    */

    public void SceneSwitch()
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
