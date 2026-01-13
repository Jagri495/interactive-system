using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ライブラリの追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class backButton : MonoBehaviour{
public void GoStart()
    {
        SceneManager.LoadScene("New Scene");
    }
}