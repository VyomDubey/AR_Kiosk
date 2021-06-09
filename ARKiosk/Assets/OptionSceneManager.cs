using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionSceneManager : MonoBehaviour
{
    GameObject helpPanel;
    bool toggle = false;
    void Start()
    {
        helpPanel = GameObject.Find("Help_2");
        helpPanel.SetActive(false);
    }

    public void OnHelpButtonClick()
    {
        if(!toggle)
        {
            helpPanel.SetActive(true);
        }
        else
        {
            helpPanel.SetActive(false);
        }
        toggle = !toggle;
    }

    public void ARModelButtonClick()
    {
        SceneManager.LoadScene("StudentScene");
    }
}
