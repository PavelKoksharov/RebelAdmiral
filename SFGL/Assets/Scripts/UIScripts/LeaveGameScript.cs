using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveGameScript : MonoBehaviour
{
    public void LeaveGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
