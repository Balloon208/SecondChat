using UnityEngine.SceneManagement;

public class HappyEnd : ChatManager
{
    protected override void End()
    {
        // ȣ���� �ֱ�..
        SceneManager.LoadScene("HAPPY");
    }
}