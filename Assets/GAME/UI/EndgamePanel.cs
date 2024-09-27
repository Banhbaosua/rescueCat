using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndgamePanel : MonoBehaviour
{
    [SerializeField] Button button;
    
    void Start()
    {
        button.onClick.AddListener(LoadLevel);
    }

    void LoadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level0");
    }
}
