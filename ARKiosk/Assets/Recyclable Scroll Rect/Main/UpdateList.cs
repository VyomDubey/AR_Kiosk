using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateList : MonoBehaviour
{
    // Start is called before the first frame update
 //   GameObject FindRectObject;
    GameObject canvas;
    void Start()
    {
      //  FindRectObject = GameObject.Find("Recyclable Scroll Controller");
        canvas = GameObject.Find("Panel");
    }

    public void updateList()
    {
        
        canvas.SetActive(false);
        //  FindRectObject.SetActive(false);
        //  FindRectObject.SetActive(true);
        Debug.Log("Did It!!");
       // canvas.SetActive(true);
    }
}
