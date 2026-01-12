using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void GoGameScene()
    {
        SceneManager.LoadScene("Record_Scene");
    }
}