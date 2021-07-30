using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Find : MonoBehaviour
{

    public Text MyText;

    public GroupObject[] GroupObject;

    public Cell[] _cell;  

    private void Start()
    {
        SetCellCompanet();
    }


    public void SetCellCompanet()
    {
        List<string> NameItem = new List<string>();

        int RandomGroup = Random.Range(0, GroupObject.Length);      

        foreach (var item in _cell)
        {
            bool ThereRepetitions = false;

            int RandomItem = 0;

            if (NameItem.Count == 0)
            {
                RandomItem = Random.Range(0, GroupObject[RandomGroup].ItemObjects.Length);
                NameItem.Add(GroupObject[RandomGroup].ItemObjects[RandomItem].NameObject);
            }
            else
            {
                while (ThereRepetitions == false)
                {
                    ThereRepetitions = true;

                    RandomItem = Random.Range(0, GroupObject[RandomGroup].ItemObjects.Length);

                    foreach (var name in NameItem)
                    {                         
                        if (name == GroupObject[RandomGroup].ItemObjects[RandomItem].NameObject)
                        {
                            ThereRepetitions = false;
                        }
                    }

                    if (ThereRepetitions == true)
                    {
                        NameItem.Add(GroupObject[RandomGroup].ItemObjects[RandomItem].NameObject);                      
                    }
                        
                }
            }

            item.SetCell(GroupObject, RandomGroup, RandomItem);

            SetWhatToLookFor(NameItem);
        }
    }

    public void DestroyMe()
    {
        StartCoroutine(CurotineDestrouMe());
    }

    public void SetWhatToLookFor(List<string> NameItem)
    {
        List<string> FindObject = new List<string>();

        string _nameObj = NameItem[Random.Range(0, NameItem.Count)];

        if(FindObject.Count == 0)
        {
            FindObject.Add(_nameObj);
        }
        else
        {
            bool ThereRepetitions = false;

            foreach (var item in FindObject)
            {
                while (ThereRepetitions == false)
                {
                    ThereRepetitions = true;

                    if (item == _nameObj)
                    {
                        ThereRepetitions = false;
                    }

                    if(ThereRepetitions == true)
                    {
                        FindObject.Add(_nameObj);
                    }
                    else
                    {
                        _nameObj = NameItem[Random.Range(0, NameItem.Count)];
                    }
                }
            }
        }

        foreach (var item in _cell)
        {
            item.SetAnswer(_nameObj);
        }

        MyText.text = "Find " + _nameObj;
    }

    IEnumerator CurotineDestrouMe()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}


[System.Serializable]
public class ItemObject
{

    public string NameObject;

    public Sprite SpriteObject;

}

[System.Serializable]
public class GroupObject
{
    public string NameGroupObject;

    public ItemObject[] ItemObjects;
}



