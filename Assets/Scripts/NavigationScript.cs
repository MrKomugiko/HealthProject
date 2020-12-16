using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationScript : MonoBehaviour
{
    public void OnClick_Back()
    {
        SceneManager.LoadScene("LandingStartScene");
    }
    public void OnClick_GoToBMIPage()
    {
        SceneManager.LoadScene("BmiScene");
    }

    public void OnClick_GoToHistoryPage()
    {
        SceneManager.LoadScene("HistoryScene");
    }

    public void OnClick_BACK(string destination){
        SceneManager.LoadScene(destination);
    }
}
