using System.Collections.Generic;
using UnityEngine;
using PolyAndCode.UI;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Demo controller class for Recyclable Scroll Rect. 
/// A controller class is responsible for providing the scroll rect with datasource. Any class can be a controller class. 
/// The only requirement is to inherit from IRecyclableScrollRectDataSource and implement the interface methods
/// </summary>

//Dummy Data model for demostraion
public struct ContactInfo
{
    public string Name;
    public string Gender;
    public string id;
}

public class RecyclableScrollerDemo : MonoBehaviour, IRecyclableScrollRectDataSource
{
    [SerializeField]
    RecyclableScrollRect _recyclableScrollRect;

    [SerializeField]
    private int _dataLength;
    GameObject panel;
    GameObject content;
    //Dummy data List
    private List<ContactInfo> _contactList = new List<ContactInfo>();
    private string SearchItem;
    public Text text;
    GameObject UpdateListReference;
    GameObject cell1, cell2, cell3, cell4;
    //Recyclable scroll rect's data source must be assigned in Awake.
    private void Awake()
    {
        InitData();
         panel= GameObject.Find("Panel");
        content = GameObject.Find("Content");
        //    GetInputValue("N");
        _recyclableScrollRect.DataSource = this;
    }
    private void Start()
    {
        UpdateListReference = GameObject.Find("Plane");
        int i = 0;
        StartCoroutine(waitforme());
    }
    IEnumerator waitforme()
    {
        yield return new WaitForSeconds(2);
        int i = 0;
        foreach(Transform child in content.transform)
        {
            if (i == 0)
                cell1 = child.gameObject;
            if (i == 1)
                cell2 = child.gameObject;
            if (i == 2)
                cell3 = child.gameObject;
            else
                cell4 = child.gameObject;
            i++;
        }

    }
    //Initialising _contactList with dummy data 
    private void InitData()
    {
        if (_contactList != null) _contactList.Clear();

        string[] genders = { "Male", "Female" };
        /*   for (int i = 0; i < _dataLength; i++)
           {
               ContactInfo obj = new ContactInfo();
               obj.Name = "Name";
               obj.Gender = genders[Random.Range(0, 2)];
               obj.id = "Student : " + (i+1);
               _contactList.Add(obj);
           }*/
        ContactInfo obj = new ContactInfo();
        obj.Name = "Thomas";
        obj.Gender = "Male";
        obj.id = "Student : 1";
        _contactList.Add(obj);
        obj.Name = "Megan";
        obj.Gender = "Female";
        obj.id = "Student : 2";
        _contactList.Add(obj);
        obj.Name = "Louise";
        obj.Gender = "Female";
        obj.id = "Student : 3";
        _contactList.Add(obj);
        obj.Name = "Tim";
        obj.Gender = "Male";
        obj.id = "Student : 4";
        _contactList.Add(obj);
    }

    #region DATA-SOURCE

    /// <summary>
    /// Data source method. return the list length.
    /// </summary>
    public int GetItemCount()
    {
        return _contactList.Count;
    }

    /// <summary>
    /// Data source method. Called for a cell every time it is recycled.
    /// Implement this method to do the necessary cell configuration.
    /// </summary>
    public void SetCell(ICell cell, int index)
    {
        //Casting to the implemented Cell
        var item = cell as DemoCell;
        item.ConfigureCell(_contactList[index], index);
    }

    public void SearchButtonListener()
    {
        //    GetInputValue(text.text);
        cell1.SetActive(false);
        cell2.SetActive(false);
        cell3.SetActive(false);
        cell4.SetActive(false);
        int i = 0, j = 0, k = 0, v = 0;
        if ((text.text == "T" || text.text=="Th" || text.text=="Tho" || text.text=="Thom" || text.text=="Thoma" || text.text=="Thomas" || text.text==""))
        {
            i++;
            cell1.SetActive(true);
        }
        if((text.text == "M" || text.text == "Me" || text.text == "Meg" || text.text == "Mega" || text.text == "Megan" || text.text==""))
        {
            if (i == 0)
                cell2.transform.position = cell1.transform.position;
            cell2.SetActive(true);
            j++;
        }
        if((text.text == "L" || text.text == "Lo" || text.text == "Lou" || text.text == "Loui" || text.text == "Louis" || text.text == "Louise" || text.text==""))
        {
            if (i == 0 && j == 0)
                cell3.transform.position = cell1.transform.position;
            cell3.SetActive(true);
            k++;
        }
        if((text.text == "T" || text.text == "Ti" || text.text == "Tim" || text.text==""))
        {
            if (i == 1 && j == 0)
                cell4.transform.position = cell2.transform.position;
            else if (i == 0)
                cell4.transform.position = cell1.transform.position;
            cell4.SetActive(true);
        }

    }

    public void GetInputValue(string input)
    {
        //   SearchItem = text.ToString();
        SearchItem = input;
        List<ContactInfo> Temp = new List<ContactInfo>();
    //    Debug.Log("ins " + SearchItem);
        if (SearchItem.Length > 0)
        {
            for (int j = 0; j < _contactList.Count; j++)
            {
                int i = 0;
                while (_contactList[j].Name[i] == SearchItem[i])
                {
                    i++;
                    if (i == SearchItem.Length)
                    {
                        Temp.Add(_contactList[j]);
                        break;
                    }
                }
            }
            Debug.Log("Count=" + Temp.Count);
            _contactList.Clear();
            for (int i = 0; i < Temp.Count; i++)
            {
                _contactList.Add(Temp[i]);

            }
            Temp.Clear();
            
        }
        else
        {
            InitData();
        }
        _recyclableScrollRect.DataSource = this;
        UpdateListReference.GetComponent<UpdateList>().updateList();
        
    }
    #endregion
}