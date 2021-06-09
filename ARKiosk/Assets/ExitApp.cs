using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApp : MonoBehaviour
{
    GameObject ExitPanel;
    private void Start()
    {
        ExitPanel = GameObject.Find("EXIT");
        ExitPanel.SetActive(false);
    }
    public void OnPanelClick()
    {
        ExitPanel.SetActive(true);
    }
    public void OnExitClick()
    {
        Application.Quit();
    }
}
