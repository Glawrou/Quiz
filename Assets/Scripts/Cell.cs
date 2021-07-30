using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    private string NameCell;

    public SetSprite SetSprite;

    public UnityEvent IncorrectAnswer;

    public UnityEvent TrueAnswer;

    public UnityEvent DestrouParent;

    public GameObject Stars;

    public bool BounceStart;

    private string Answer;

    private void Start()
    {
        if(BounceStart == true)
        {
            Bounce();
        }
    }

    public void SetCell(GroupObject[] _groupObject, int _group, int _item)
    { 
        ItemObject _itemObject = _groupObject[_group].ItemObjects[_item];

        SetNameCell(_itemObject.NameObject);
        SetSpriteCell(_itemObject.SpriteObject);
    }


    public void SetNameCell(string _nameCell)
    {
        NameCell = _nameCell;
    }

    public void SetSpriteCell(Sprite _spriteCell)
    {
        SetSprite.Invoke(_spriteCell);
    }

    public void SetAnswer(string _answer)
    {
        Answer = _answer;
    }

    public void Bounce()
    {
        transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0f), 1f);
    }

    public void CheckingTheAnswer()
    { 
        if(Answer == NameCell)
        {
            Instantiate(Stars, (Vector3)transform.position + new Vector3(0, 0, -3), Quaternion.Euler(0,180,0));
            GameObject.Find("Panelloading").GetComponent<Loading>().LoadLevel();
            DestrouParent.Invoke();
        }
        else
        {
            IncorrectAnswer.Invoke();
        }
    }

}

[System.Serializable]
public class SetSprite : UnityEvent<Sprite> { }

