using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CellObject : MonoBehaviour
{
    public void IncorrectAnswer()
    {
        transform.DOShakePosition(10f, strength: new Vector3(4, 0, 0), vibrato: 3, randomness: 0, snapping: false, fadeOut: true) ;
    }
}
