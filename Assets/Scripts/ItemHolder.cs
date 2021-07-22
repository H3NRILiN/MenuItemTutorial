using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[SelectionBase]
public class ItemHolder : MonoBehaviour
{

    public Transform m_ItemShowcase;

    private void Start()
    {
        m_ItemShowcase.
            DOLocalMoveY(0.3f, 1f).
            SetEase(Ease.InOutQuad).
            SetLoops(-1, LoopType.Yoyo);

        m_ItemShowcase.
            DOLocalRotate(new Vector3(0, 360, 0), 1, RotateMode.FastBeyond360).
            SetRelative().
            SetEase(Ease.Linear).
            SetLoops(-1);

    }
}
