using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class Loading : MonoBehaviour
{
    public GameObject[] LvlGameObject;

    private Image MyImage;

    public UnityEvent ShowRestart;

    private int Lvl = 0;

    private void Start()
    {
        MyImage = GetComponent<Image>();

        OutLoading();
        
        LoadLevel();
    }

    public void InLoading()
    {
        Fade(1);
    }
    public void OutLoading()
    {
        Fade(0);
    }

    public void LoadLevel()
    {
        var Transparency = DOTween.Sequence();

        Transparency.Join(MyImage.material.DOFade(1, 1f));

        if (Lvl != 3)
        {
            StartCoroutine(WaitAndLoadLvl());
            Transparency.Append(MyImage.material.DOFade(0, 1f));
        }
        else
        {
            ShowRestart.Invoke();
        }
            
    }

    public void CriatePrifabLvl(int numberLvl)
    {
        Instantiate(LvlGameObject[numberLvl], new Vector3(0,0,0), Quaternion.identity, GameObject.Find("Interface").transform);
    }

    IEnumerator WaitAndLoadLvl()
    {
        yield return new WaitForSeconds(1f);

        if (true)
        {
            if (Lvl != 3)
                Lvl++;
            else
                Lvl = 0;

            switch (Lvl)
            {
                case 1:
                    CriatePrifabLvl(0);
                    break;
                case 2:
                    CriatePrifabLvl(1);
                    break;
                case 3:
                    CriatePrifabLvl(2);
                    break;
            }
        }
    }

    public void ResetLevel()
    {
        Lvl = 0;
    }

    private void Fade(float Transparency)
    {
        if (Transparency >= 0 && Transparency <= 1)
            MyImage.material.DOFade(Transparency, 1f);      
        //MyImage.material.DOFade(Transparency, 1f);
        else
            Debug.LogError("Invalid value Fade in loading");

    }

}
