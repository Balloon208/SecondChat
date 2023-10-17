using UnityEngine.SceneManagement;

public class BadEnd : ChatManager
{
    protected override void End()
    {
        // 호감도 넣기..
        SceneManager.LoadScene("BAD");
    }
}