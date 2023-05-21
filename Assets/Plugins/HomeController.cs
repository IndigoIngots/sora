using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    bool isOnce = false;
    public static bool isTwice = false;
    public static bool GetisTwice()
    { 
        return isTwice;
    }

    [SerializeField] Image Fade_Display;
    [SerializeField] AudioSource BGM;

    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;

    [SerializeField] Image Sora;
    [SerializeField] Image Flower;


    void Awake()
    {
        isOnce = UIText.GetisClearOnce();

        if (isOnce == true)
        {
            Button2.SetActive(true);

            DOTween.ToAlpha(
    () => Sora.color,
    color => Sora.color = color,
    150 / 255f, 0f);

            DOTween.ToAlpha(
    () => Flower.color,
    color => Flower.color = color,
    150 / 255f, 0f);
        }
        else
        {
            Button2.SetActive(false);
        }
    }

    public void PushStart2()
    {
        isTwice = true;
        PushStart();
    }

    // Start is called before the first frame update
    void Start()
    {
        Fade_Display.color = new Color(0f, 0f, 0f, 1f);
        DOTween.ToAlpha(
            () => Fade_Display.color,
            color => Fade_Display.color = color,
            0f, 1.5f);
    }

    public void PushStart()
    {
        Fade_Display.color = new Color(0f, 0f, 0f, 0f);
        DOTween.ToAlpha(
            () => Fade_Display.color,
            color => Fade_Display.color = color,
            1f, 1.5f);

        BGM.DOFade(0, 1.5f);

        Invoke("ChangeScene", 1.5f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }
}
