using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart() //could have a string argument here so that the level name is passed through the inspector. However since only one scene will be used in this project, this was considered
    { //unneeded
        SceneManager.LoadScene("MainScene");
    }
}
