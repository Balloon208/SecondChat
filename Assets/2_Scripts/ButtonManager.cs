using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        for(int i = 0; i < PlayerStatus.friendshiplevel.Length; i++)
        {
            PlayerStatus.friendshiplevel[i] = 20;
        }
        
        SceneManager.LoadScene("PlayingGame");
    }

    public void Movescene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void ShowStart() { }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
