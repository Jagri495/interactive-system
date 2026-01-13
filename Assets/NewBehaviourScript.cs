using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ライブラリの追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneButton : MonoBehaviour
{
    public void GoResult()
    {
        SceneManager.LoadScene("Record_Scene");
    }
}
