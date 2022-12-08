using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
