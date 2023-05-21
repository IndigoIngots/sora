using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIText : MonoBehaviour
{
    public static bool isClearOnce = false;
    public static bool GetisClearOnce()
    {
        return isClearOnce;
    }
    bool isSecond = false;

    [SerializeField] Image Fade_Background;
    [SerializeField] Image Fade_Display;
    [SerializeField] Image NextPage;

    Tween SendText;

    bool isChoice1 = false;
    bool isChoice2 = false;
    bool isChoice3 = false;
    bool isChoice4 = false;
    bool isChoice5 = false;
    bool isChoice6 = false;
    bool isChoice7 = false;

    [SerializeField] GameObject Buttons;
    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;
    [SerializeField] GameObject Button3;
    [SerializeField] GameObject Button4;
    [SerializeField] GameObject Button5;
    [SerializeField] Text _textB1;
    [SerializeField] Text _textB2;
    [SerializeField] Text _textB3;
    [SerializeField] Text _textB4;
    [SerializeField] Text _textB5;

    [SerializeField] AudioClip ClicSE;
    //�������肷��p�̃e�L�X�g
    [SerializeField]
    private Text _nameText;

    //�������肷��p�̃e�L�X�g
    [SerializeField]
    private Text _textM = default;

    //�������肷��p�̃e�L�X�g
    [SerializeField]
    private Image _sora = default;
    [SerializeField]
    private Image _flower = default;

    //SE��炷���߂̂��
    [SerializeField]
    private AudioSource _audioSource = default;

    [SerializeField]
    private AudioSource BGM = default;

    //SE��炳�Ȃ�����
    private static readonly string[] INVALID_CHARS = {
  " ", "�@", "!", "?", "�I", "�H", ".", ",", "�A", "�B", "�c"
};

    //�ŏ��̃t�F�[�h���Ă鎞�Ƀ��b�Z�[�W�𑗂�Ȃ��悤�ɂ��邽��
    bool isStart = false;
    bool isComplete = false;

    [System.Serializable] //�����������inspector�ɕ\�������B
    public struct CharaStatus
    {
        public string charaName;
        [TextArea] public string speak;
        public int FaceNum;
    }

    [SerializeField] CharaStatus[] Talk1;
    [SerializeField] CharaStatus[] Route1;
    [SerializeField] CharaStatus[] Route2;
    [SerializeField] CharaStatus[] Route3;
    [SerializeField] CharaStatus[] Route4;

    [SerializeField] CharaStatus[] Route5;
    [SerializeField] CharaStatus[] Route6;
    [SerializeField] CharaStatus[] Route7;
    [SerializeField] CharaStatus[] Route8;

    [SerializeField] CharaStatus[] Route9;
    [SerializeField] CharaStatus[] Route10;
    [SerializeField] CharaStatus[] Route11;

    [SerializeField] CharaStatus[] RouteA;
    [SerializeField] CharaStatus[] RouteB;


    void EndMessage()
    {
        Invoke("MakeComplete", 0.1f);
        NextPage.gameObject.SetActive(true);
    }

    void MakeComplete()
    {
        isComplete = true;
    }

    void CompleteText()
    {
        SendText.Complete();
    }

    void Start()
    {
        isSecond = HomeController.GetisTwice();
        //isSecond = true;

        if (isSecond == true)
        {
            DOTween.ToAlpha(
    () => _sora.color,
    color => _sora.color = color,
    150/255f, 0f);

            DOTween.ToAlpha(
    () => _flower.color,
    color => _flower.color = color,
    150/255f, 0f);
        }
        else
        {
            DOTween.ToAlpha(
    () => _sora.color,
    color => _sora.color = color,
    1f, 0f);

            DOTween.ToAlpha(
    () => _flower.color,
    color => _flower.color = color,
    1f, 0f);
        }

        Fade_Display.color = new Color(0f, 0f, 0f, 1f);
        DOTween.ToAlpha(
            () => Fade_Display.color,
            color => Fade_Display.color = color,
            0f, 1.5f);
        //�Ŋ��ɂQ�b�ɂ��Ă���
        Invoke("StartSpeak", 1);
        Buttons.transform.DOScaleX(0f, 0f);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isStart == true && isComplete == false)
        {
            CompleteText();
        }
    }

    void StartSpeak()
    {
        StartCoroutine("Talking1");
    }

    IEnumerator Talking1()
    {
        isStart = true;
        for (int i = 0; i < Talk1.Length; i++)
        {
            isComplete = false;
            DOText(Talk1[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        //�I������
        Choice1();
        yield return null;
    }

    
    void Choice1()
    {
        NextPage.gameObject.SetActive(false);
        if (isChoice1 == true && isChoice2 == true && isChoice3 == true)
        {
            Button4.SetActive(true);
        }
        else
        {
            Button4.SetActive(false);
        }

        _nameText.text = "";
        _textM.text = "";

        _textB1.text = "�����̎v���o";
        _textB2.text = "�����̎v���o";
        _textB3.text = "�搶�̎v���o";
        _textB4.text = "�����̎�";

        Buttons.transform.DOScaleX(0f, 0f);
        Buttons.transform.DOScaleX(1f, 0.2f);
    }

    void Choice2()
    {
        NextPage.gameObject.SetActive(false);
        if (isChoice5 == true && isChoice6 == true && isChoice7 == true)
        {
            Button4.SetActive(true);
        }
        else
        {
            Button4.SetActive(false);
        }

        _nameText.text = "";
        _textM.text = "";

        _textB1.text = "���Ƃ̎�";
        _textB2.text = "�\���Ɋ��ӂ��Ă��鎖";
        _textB3.text = "�Y����Ȃ��v���o�̎�";
        _textB4.text = "���c������";

        Buttons.transform.DOScaleX(0f, 0f);
        Buttons.transform.DOScaleX(1f, 0.2f);
    }

    [SerializeField] Text tellText;
    void Choice3()
    {
        NextPage.gameObject.SetActive(false);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(false);
        Button5.SetActive(true);

        _nameText.text = "";
        _textM.text = "";

        tellText.text = "";
        tellText.DOText("����`����H", 0.75f).SetEase(Ease.Linear);

        if (isSecond == true)
        {
            _textB5.text = "�\���ɑ΂���z��";
        }
        else
        {
            _textB5.text = "�\���ɑ΂���v��";
        }


        Buttons.transform.DOScaleX(0f, 0f);
        Buttons.transform.DOScaleX(1f, 0.2f);
    }

    public void PushButton1()
    {
        if (isChoice4 == false)
        {
            StartCoroutine("SpeakRoute1");
        }
        else
        {
            StartCoroutine("SpeakRoute5");
        }
        Buttons.transform.DOScaleX(0f, 0.1f);
    }


    public void PushButton2()
    {
        if (isChoice4 == false)
        {
            StartCoroutine("SpeakRoute2");
        }
        else
        {
            StartCoroutine("SpeakRoute6");
        }
        Buttons.transform.DOScaleX(0f, 0.1f);
    }


    public void PushButton3()
    {
        if (isChoice4 == false)
        {
            StartCoroutine("SpeakRoute3");
        }
        else
        {
            StartCoroutine("SpeakRoute7");
        }
        Buttons.transform.DOScaleX(0f, 0.1f);
    }


    public void PushButton4()
    {
        if (isChoice4 == false)
        {
            StartCoroutine("SpeakRoute4");
        }
        else
        {
            StartCoroutine("SpeakRoute8");
        }
        Buttons.transform.DOScaleX(0f, 0.1f);
    }

    public void PushButton5()
    {
        if (isSecond == true)
        {
            StartCoroutine("SpeakRoute10");
        }
        else
        { 
            StartCoroutine("SpeakRoute9");
        }
        Buttons.transform.DOScaleX(0f, 0.1f);
    }

    IEnumerator SpeakRoute1()
    {
        for (int i = 0; i < Route1.Length; i++)
        {
            isComplete = false;
            DOText(Route1[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        //�I������
        isChoice1 = true;
        Choice1();
        yield return null;
    }

    IEnumerator SpeakRoute2()
    {
        for (int i = 0; i < Route2.Length; i++)
        {
            isComplete = false;
            DOText(Route2[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        //�I������
        isChoice2 = true;
        Choice1();
        yield return null;
    }

    IEnumerator SpeakRoute3()
    {
        for (int i = 0; i < Route3.Length; i++)
        {
            isComplete = false;
            DOText(Route3[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        //�I������
        isChoice3 = true;
        Choice1();
        yield return null;
    }

    IEnumerator SpeakRoute4()
    {
        for (int i = 0; i < Route4.Length; i++)
        {
            isComplete = false;
            DOText(Route4[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        //�I������
        isChoice4 = true;
        Choice2();
        yield return null;
    }

    IEnumerator SpeakRoute5()
    {
        for (int i = 0; i < Route5.Length; i++)
        {
            isComplete = false;
            DOText(Route5[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        //�I������
        isChoice5 = true;
        Choice2();
        yield return null;
    }

    IEnumerator SpeakRoute6()
    {
        for (int i = 0; i < Route6.Length; i++)
        {
            isComplete = false;
            DOText(Route6[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        //�I������
        isChoice6 = true;
        Choice2();
        yield return null;
    }

    IEnumerator SpeakRoute7()
    {
        for (int i = 0; i < Route7.Length; i++)
        {
            isComplete = false;
            DOText(Route7[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        //�I������
        isChoice7 = true;
        Choice2();
        yield return null;
    }

    IEnumerator SpeakRoute8()
    {
        for (int i = 0; i < Route8.Length; i++)
        {
            isComplete = false;
            DOText(Route8[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        //�I������

        Choice3();
        yield return null;
    }

    IEnumerator SpeakRoute9()
    {
        for (int i = 0; i < Route9.Length; i++)
        {
            isComplete = false;
            DOText(Route9[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        DOTween.ToAlpha(
            () => _sora.color,
            color => _sora.color = color,
            0f, 3f);

        DOTween.ToAlpha(
            () => _flower.color,
            color => _flower.color = color,
            0f, 3f);

        isComplete = false;
        DOText(Route11[0]);

        yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
        yield return null;

        Fade_Background.color = new Color(0f, 0f, 0f, 0f);
        DOTween.ToAlpha(
            () => Fade_Background.color,
            color => Fade_Background.color = color,
            1f, 1.5f);

        for (int i = 0; i < Route10.Length; i++)
        {
            isComplete = false;
            DOText(Route10[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        Fade_Display.color = new Color(0f, 0f, 0f, 0f);
        DOTween.ToAlpha(
            () => Fade_Display.color,
            color => Fade_Display.color = color,
            1f, 1.5f);

        BGM.DOFade(0, 1.5f);

        //�P���ڃN���A�t���O
        isClearOnce = true;
        Invoke("ChangeScene", 1.5f);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
        yield return null;
    }

    IEnumerator SpeakRoute10()
    {
        for (int i = 0; i < RouteA.Length; i++)
        {
            isComplete = false;
            DOText(RouteA[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        _textM.text = "";
        NextPage.gameObject.SetActive(false);

        BGM.DOFade(0, 1.5f);
        Fade_Background.color = new Color(0f, 0f, 0f, 0f);
        DOTween.ToAlpha(
            () => Fade_Background.color,
            color => Fade_Background.color = color,
            1f, 1.5f);

        DOTween.ToAlpha(
            () => _sora.color,
            color => _sora.color = color,
            0f, 1f);

        yield return new WaitForSeconds(2);
        yield return null;

        Background2.gameObject.SetActive(true);

        DOTween.ToAlpha(
    () => Fade_Background.color,
    color => Fade_Background.color = color,
    0f, 1.5f);

        yield return new WaitForSeconds(2);
        yield return null;

        for (int i = 0; i < RouteB.Length; i++)
        {
            isComplete = false;
            DOText(RouteB[i]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && isStart == true && isComplete == true);
            yield return null;
        }

        DOTween.ToAlpha(
    () => Fade_Display.color,
    color => Fade_Display.color = color,
    1f, 1.5f);
        Invoke("ChangeScene", 1.5f);
        yield return null;
    }

    [SerializeField] Image Background2;

    void ChangeScene()
    {
        SceneManager.LoadScene("Home");
    }

    /// <summary>
    /// DOText(��������)�����s
    /// </summary>

    void DOText(CharaStatus charaStatus)
    {
        if (charaStatus.charaName == "�\��" && isSecond == true)
        {
            _textM.color = new Color(10 / 255f, 10 / 255f, 10 / 255f, 150 / 255f);
            _nameText.color = new Color(1, 1, 1, 150 / 255f);
        }
        else
        {
            _textM.color = new Color(10 / 255f, 10 / 255f, 10 / 255f, 255 / 255f);
            _nameText.color = new Color(1, 1, 1, 1);
        }

        NextPage.gameObject.SetActive(false);

        _nameText.text = charaStatus.charaName;

        _textM.text = "";

        _sora.sprite = Faces[charaStatus.FaceNum];

        //�ω��O�̃e�L�X�g
        var beforeText = _textM.text;

        //����������s
        SendText = _textM.DOText(charaStatus.speak, 1)
          .SetEase(Ease.Linear)
          .OnUpdate(() =>
          {//�X�V�����x�Ɏ��s�����(���e�L�X�g���ύX���ꂽ���ł͂Ȃ�)
           //���݂̃e�L�X�g���擾�A�ω����Ă��Ȃ���Ώ������Ȃ�
              var currentText = _textM.text;
              if (beforeText == currentText)
              {
                  return;
              }

              //�V���ɒǉ����ꂽ�������擾
              var newChar = currentText[currentText.Length - 1].ToString();

              //SE��炳�Ȃ���łȂ���Ζ炷
              if (!INVALID_CHARS.Contains(newChar))
              {
                  _audioSource.PlayOneShot(ClicSE);

              }
              //���̃`�F�b�N�p�Ƀe�L�X�g�X�V
              beforeText = currentText;
          })
          .OnComplete(EndMessage);
    }

    [SerializeField] Sprite[] Faces;
}
