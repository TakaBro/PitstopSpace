using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnClick : MonoBehaviour
{
    public Image blackImg;
    public Animator anim;
    public Button firstBtn;

    public void Start(){
        firstBtn?.Select();
    }

    public void BtnMenu()
    {
        StartCoroutine(Fading("Menu"));
    }

    public void BtnPlay()
    {
        StartCoroutine(Fading("Scenery 1"));
    }

    public void BtnCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    IEnumerator Fading(string scene)
    {
        Debug.Log("FADE");
        anim.SetBool("fade", true);
        yield return new WaitUntil(()=>blackImg.color.a==1);
        SceneManager.LoadScene(scene);
    }
}
