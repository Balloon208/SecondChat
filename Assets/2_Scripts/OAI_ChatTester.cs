using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class OAI_ChatTester : MonoBehaviour
{
    private string postText;
    string ReqestText = "";
    OAI_Chat OAI_Chat;
    // Start is called before the first frame update
    void Start()
    {
        OAI_Chat = this.gameObject.GetComponent<OAI_Chat>();
        this.gameObject.GetComponent<OAI_Chat>().CompletedRepostEvent = delegate (string _string) { ReqestText = _string; };
    }

    public void Reqest(Text text)
    {
        ReqestText = text.text;
        Test();
    }

    private async void Test()
    {
        //OAI_Chat.ReqestStringData(b);
        //Debug.Log(b);
        postText = (await this.gameObject.GetComponent<OAI_Chat>().AsyncReqesStringtData(ReqestText, _sendMessageDebugLog: true));

        string addlike = postText.Substring(0, 1);
        Debug.Log(addlike);
        if (addlike == "+")
        {
            PlayerStatus.friendshiplevel += 10;
        }
        if (addlike == "-")
        {
            PlayerStatus.friendshiplevel -= 10;
        }
    }
}