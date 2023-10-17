using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    IEnumerator Load()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("StartGame");
    }

    private void Awake()
    {
        StartCoroutine(Load());
    }
}
