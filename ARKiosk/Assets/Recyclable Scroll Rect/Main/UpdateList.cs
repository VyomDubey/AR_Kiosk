using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateList : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject FindRectObject;
    void Start()
    {
        FindRectObject = GameObject.Find("Recyclable Scroll Controller");
    }

    public void updateList()
    {
        FindRectObject.SetActive(false);
        FindRectObject.SetActive(true);
    }
}
