using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NormalEnd : ChatManager
{
    protected override void End()
    {
        // ȣ���� �ֱ�..
        SceneManager.LoadScene("NORMAL");
    }
}