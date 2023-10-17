using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChatManager : MonoBehaviour
{
    #region Variable
    // ������!
    public TextAsset data;
    protected AllData datas;
    //�����, ������, �ѿ���
    public List<string> cName = new List<string>() { "�����", "������", "�ѿ���" };

    // UI!
    public Text TextName;
    public TypeEffect TextSentence;
    public Image Portrait;

    // �ι�
    public List<Sprite> Profiles1;
    public List<Sprite> Profiles2;
    public List<Sprite> Profiles3;
    public List<Sprite> Profiles4;

    public Image InMoL1;
    public Image InMoL2;
    public Image InMoL3;

    public Image BG;
    public List<Sprite> BGS;
    // �Է�!
    public KeyCode NextInput;

    // �ε��� ����!
    protected int NextIndex = 0;

    // �ִϸ��̼�
    public Animator CharacterPanel;
    public Animator BranchPanel1;
    public Animator BranchPanel2;

    protected bool onBranch1;
    protected bool onBranch2;
    protected bool checkBranch;

    public Text tx1;
    public Text tx2;

    // ��� ����Ʈ
    protected string[] backgroundlist = new string[] { "LINE", "CLASS", "FOOD", "SUNSETALLEY", "NIGHTMARE", "BLO", "GROUND", "SUMMERLINE", "SUMMERNIGHT", "SUNSETLINE", "SIBAL" };

    Dictionary<string, Dictionary<string, Sprite>> profiles;
    protected float timer = 0;
    protected int mode = 0;

    #endregion

    #region Utility
    private IEnumerator setWaitT()
    {
        print("setWaitT");
        CharacterPanel.SetBool("isShow", true);
        yield return new WaitForSeconds(0.7f);

        BranchPanel1.SetBool("isBranch", true);
        BranchPanel2.SetBool("isBranch", true);
    }

    private IEnumerator setWaitF()
    {
        print("setWaitF");
        yield return new WaitForSeconds(0.7f);
        BranchPanel1.SetBool("isBranch", false);
        BranchPanel2.SetBool("isBranch", false);
        yield return new WaitForSeconds(0.5f);

        CharacterPanel.SetBool("isShow", false);
    }

    
    protected IEnumerator Timer()
    {
        while (true)
        {
            //print(timer);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    protected void Setprofiles()
    {
        profiles = new Dictionary<string, Dictionary<string, Sprite>>
        {
            {
                "�����", new Dictionary<string, Sprite>
                {
                    { "IDLE", Profiles1[0] },
                    { "SMILE", Profiles1[1] },
                    { "TALK", Profiles1[2] },
                    { "FLUTTER", Profiles1[3] },
                    { "BORING", Profiles1[4] },
                    { "ANGRY", Profiles1[5] }
                }
            },
            {
                "������", new Dictionary<string, Sprite>
                {
                    { "IDLE", Profiles2[0] },
                    { "SMILE", Profiles2[1] },
                    { "TALK", Profiles2[2] },
                    { "ANGRY", Profiles2[3] }
                }
            },
            {
                "�ѿ���", new Dictionary<string, Sprite>
                {
                    { "IDLE", Profiles3[0] },
                    { "SMILE", Profiles3[1] },
                    { "TALK", Profiles3[2] },
                    { "FLUTTER", Profiles3[3] },
                    { "EMBARRASSMENT", Profiles3[4] },
                    { "ANGRY", Profiles3[5] }
                }
            }
        };
    }

    protected void Changebackground()
    {
        for (int i = 0; i < backgroundlist.Length; i++)
        {
            if (datas.story[NextIndex].SubInfo == backgroundlist[i].ToString())
            {
                BG.color = new Color(1, 1, 1, 1);
                BG.sprite = BGS[i];
                return;
            }
        }
        BG.color = new Color(0, 0, 0, 255 / 255f);
        return;
    }

    protected virtual void End()
    {
        // ȣ���� �ֱ�..
        if (PlayerStatus.friendshiplevel >= 80)
        {
            SceneManager.LoadScene("PlayingGameEndingHAPPY");
        }
        else if (PlayerStatus.friendshiplevel >= 40)
        {
            SceneManager.LoadScene("PlayingGameEndingNORMAL");
        }
        else if (PlayerStatus.friendshiplevel < 40)
        {
            SceneManager.LoadScene("PlayingGameEndingBAD");
        }
    }

    #endregion

    protected void Awake()
    {
        datas = JsonUtility.FromJson<AllData>(data.text);

        print(datas.story[NextIndex].Info);
        TextName.text = datas.story[NextIndex].Info;
        TextSentence.SetMsg(datas.story[NextIndex].Contents);
        Portrait.sprite = Profiles4[0];

        Setprofiles();
        StartCoroutine(Timer());
    }

    protected void Update()
    {
        Next();
    }

    protected void Next()
    {
        // �ι�
        if (datas.story[NextIndex].Info == "�����̼�")
        {
            InMoL1.color = Color.clear;
            InMoL2.color = Color.clear;
            InMoL3.color = Color.clear;
        }
        if (datas.story[NextIndex].Info == cName[0])
        {
            Portrait.sprite = Profiles1[0];
            InMoL1.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            InMoL2.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            InMoL3.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
        }
        else if (datas.story[NextIndex].Info == cName[1])
        {
            Portrait.sprite = Profiles2[0];
            InMoL1.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            InMoL2.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
            InMoL3.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
        }
        else if (datas.story[NextIndex].Info == cName[2])
        {
            Portrait.sprite = Profiles3[0];
            InMoL1.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            InMoL2.color = new Color(166 / 255f, 166 / 255f, 166 / 255f, 255 / 255f);
            InMoL3.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
        }
        else
        {
            Portrait.sprite = Profiles4[0];
        }

        // ���
        Changebackground();

        if(datas.story[NextIndex].Code == "NARRATION")
        {
            InMoL1.sprite = Profiles1[0];
            InMoL2.sprite = Profiles2[0];
            InMoL3.sprite = Profiles3[0];
        }

       
        // ���� �����Ϳ� ���� sprite ���� �����մϴ�.
        string info = datas.story[NextIndex].Info;
        string subContents = datas.story[NextIndex].SubContents;

        if (profiles.ContainsKey(info) && profiles[info].ContainsKey(subContents))
        {
            if (info == "�����")
            {
                InMoL1.sprite = profiles[info][subContents];
            }
            else if (info == "������")
            {
                InMoL2.sprite = profiles[info][subContents];
            }
            else if (info == "�ѿ���")
            {
                InMoL3.sprite = profiles[info][subContents];
            }
        }

        if (datas.story[NextIndex + 1].Code != "END" && (Input.GetKeyUp(NextInput) || checkBranch)) // ���� ���丮�� ���ᰡ �ƴϸ鼭, �������� ���� �Է� �Ǵ� �귣ġ�� ������ �Ͽ�����. ���� ��� �߿��� ������ �Լ��� ���� ���õȴ�.
        {
            while (datas.story[NextIndex + 1].Flag != mode)  // �б����� ���� mode�� ���ϸ�, ���࿡ �ٸ� �б��� ��ȭâ�� �����ٸ� ���� �Ѱܹ�����
            {
                if(datas.story[NextIndex + 1].Flag == 0)
                {
                    mode = 0;
                    break;
                }
                print(NextIndex);
                NextIndex++;
            }
            print(mode);

            //print(NextIndex + " " + onBranch1 + " " + onBranch2);
            if (datas.story[NextIndex + 1].Code == "SELECT") // SELECT �� �б��� ���� ����̴�, ������ �Ͽ��� �������� �Ѿ �� �ִ�.
            {
                if (TextSentence.isAnim)
                {
                    TextSentence.SetMsg("");
                    return;
                }
                tx1.text = datas.story[NextIndex + 1].Contents;
                tx2.text = datas.story[NextIndex + 2].Contents;
                StartCoroutine(setWaitT());

                if (onBranch1 || onBranch2)
                {
                    StartCoroutine(setWaitF());
                }

                checkBranch = false;

                if (onBranch1)
                {
                    while (datas.story[NextIndex].Flag != 1)
                    {
                        NextIndex++;
                    }
                    mode = 1;

                    onBranch1 = false;
                }
                else if (onBranch2)
                {
                    while (datas.story[NextIndex].Flag != 2)
                    {
                        NextIndex++;
                    }
                    mode = 2;

                    onBranch2 = false;
                }
                else
                    return;

                checkBranch = false;
            }
            else // �б��� ��尡 �ƴϸ� �Ѿ��.
            {
                NextIndex++;

                //print(NextIndex);
                //print("������.");

            }

            if (TextSentence.isAnim)
            {
                TextSentence.SetMsg("");
                NextIndex--;
                return;
            }
            else
            {
                if (NextIndex >= datas.story.Length)
                {
                    //print("��");
                    return;
                }

                PrintText();
            }
        }
        else if(datas.story[NextIndex+1].Code == "END")
        {
            End();
        }
    }

    protected void PrintText()
    {
        TextName.text = datas.story[NextIndex].Info;
        TextSentence.SetMsg(datas.story[NextIndex].Contents);
    }

    public void OnBranch1()
    {
        if (datas.story[NextIndex + 1].Code == "SELECT")
        {
            print("����");
            checkBranch = true;
            onBranch1 = true;
        }
    }

    public void OnBranch2()
    {
        if (datas.story[NextIndex + 1].Code == "SELECT")
        {
            print("����");
            checkBranch = true;
            onBranch2 = true;
        }
    }
}

[Serializable]
public class AllData
{
    public ScenarioData[] story;
}

[Serializable]
public class ScenarioData
{
    public string Code;
    public int Flag;
    public string Info;
    public string SubInfo;
    public string SubContents;
    public string Contents;
}