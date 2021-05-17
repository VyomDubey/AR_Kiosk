using System.Collections.Generic;
using UnityEngine;
using PolyAndCode.UI;

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

    //Dummy data List
    private List<ContactInfo> _contactList = new List<ContactInfo>();
    private string SearchItem;
    GameObject UpdateListReference;
    //Recyclable scroll rect's data source must be assigned in Awake.
    private void Awake()
    {
        InitData();
    //    GetInputValue("N");
        _recyclableScrollRect.DataSource = this;
    }
    private void Start()
    {
        UpdateListReference = GameObject.Find("Plane");
    }
    //Initialising _contactList with dummy data 
    private void InitData()
    {
        if (_contactList != null) _contactList.Clear();

        string[] genders = { "Male", "Female" };
        for (int i = 0; i < _dataLength; i++)
        {
            ContactInfo obj = new ContactInfo();
            obj.Name = "Name";
            obj.Gender = genders[Random.Range(0, 2)];
            obj.id = "Student : " + (i+1);
            _contactList.Add(obj);
        }
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

    public void GetInputValue(string input)
    {
        SearchItem = input;
        List<ContactInfo> Temp = new List<ContactInfo>();
        if (input.Length > 0)
        {
            for (int j = 0; j < _contactList.Count; j++)
            {
                int i = 0;
                while (_contactList[j].Name[i] == input[i])
                {
                    i++;
                    if (i == input.Length)
                    {
                        Temp.Add(_contactList[j]);
                        break;
                    }
                }
            }
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
    //    UpdateListReference.GetComponent<UpdateList>().updateList();
        
    }
    #endregion
}