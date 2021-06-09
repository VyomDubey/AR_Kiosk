using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContentData : MonoBehaviour
{

    public GameObject data;
    public List<string> Names=new List<string>();
    public Text text;
    public int i = 0;
    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    Dictionary<string, GameObject> SearchList = new Dictionary<string, GameObject>();
    private void Start()
    {
        StartCoroutine(Read());
      //  Read();
    }

//    void Read()
    IEnumerator Read()
    {
        TextAsset theList = (TextAsset)Resources.Load("test", typeof(TextAsset));
        var arrayString = theList.text.Split('\n');
        foreach(var line in arrayString)
        {
            Names.Add(line);
        }
        for (i = 0; i < Names.Capacity; i++)
        {
            dictionary.Add(Names[i], i);
            GameObject g = Instantiate(data, transform);
            g.gameObject.name = Names[i];
            g.GetComponentInChildren<Text>().text = Names[i];
            SearchList.Add(Names[i], g);
            g.GetComponentInChildren<Button>().onClick.AddListener(ButtonListener);
        }
        yield return null;
    }
    private void ButtonListener()
    {
        string character = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        int _cellIndex = dictionary[character];
        PlayerPrefs.SetInt("Character", _cellIndex);
        SceneManager.LoadScene("OptionScene");
    //    Debug.Log("Index : " + _cellIndex + ", Name : " + _contactInfo.Name + ", Gender : " + _contactInfo.Gender);
    }
    public void SearchButtonListener()
    {
        GetInputValue(text.text);
    }
    void GetInputValue(string SearchItem)
    {
        List<string> Temp = new List<string>();
        //    Debug.Log("ins " + SearchItem);
        for(int i=0;i<Names.Count;i++)
        {
            SearchList[Names[i]].SetActive(false);
        }
        if (SearchItem.Length > 0)
        {
            for (int j = 0; j < Names.Count; j++)
            {
                int i = 0;
                while (Names[j][i] == SearchItem[i])
                {
                    i++;
                    if (i == SearchItem.Length)
                    {
                        Temp.Add(Names[j]);
                        SearchList[Names[j]].SetActive(true);
                        break;
                    }
                }
            }
            Debug.Log("Count=" + Temp.Count);
         /*   _contactList.Clear();
            for (int i = 0; i < Temp.Count; i++)
            {
                _contactList.Add(Temp[i]);

            }*/
            Temp.Clear();

        }
        else
        {
            for(int i = 0;i < Names.Count;i++)
            {
                SearchList[Names[i]].SetActive(true);
            }
           // InitData();
        }
     //   _recyclableScrollRect.DataSource = this;
     //   UpdateListReference.GetComponent<UpdateList>().updateList();

    }
}
