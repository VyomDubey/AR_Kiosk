using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void StartButtonClick()
    {
        SceneManager.LoadScene("InstructionScene");
    }
    public void NextButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
