using UnityEngine.SceneManagement;

public class BadEnd : ChatManager
{
    protected override void End()
    {
        // ȣ���� �ֱ�..
        SceneManager.LoadScene("BAD");
    }
}