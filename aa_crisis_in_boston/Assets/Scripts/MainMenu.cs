// this script is for switching to the game from the title screen
// add a fully responsive menu soon
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private string _SceneName = "TRAIN_STATION"; // Insert Name of Scene to load
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            LoadScene(_SceneName);
        }
    }
}
