using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnClick : MonoBehaviour
{
    // Start is called before the first frame update
    public void BtnPlay()
    {
        SceneManager.LoadScene("Scenery 1");
    }

    public void BtnRanking()
    {
        //TO DO Ranking
    }

    // Update is called once per frame
    public void BtnExit()
    {
        Application.Quit();
    }
}
