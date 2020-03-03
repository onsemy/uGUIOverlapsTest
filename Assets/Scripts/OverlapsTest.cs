using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlapsTest : MonoBehaviour
{
    [SerializeField] protected Button btnGC;

    [SerializeField] protected Image imgFood;

    private RectTransform _gcRectTransform;
    private RectTransform _foodRectTransform;

    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        if (null != btnGC)
        {
            _gcRectTransform = btnGC.transform as RectTransform;
        }

        if (null != imgFood)
        {
            _foodRectTransform = imgFood.transform as RectTransform;
        }
    }

    private void Update()
    {
        if (RectOverlaps(_gcRectTransform, _foodRectTransform))
        {
            Debug.Log($"Overlapped!");
        }
    }
    
    private bool RectOverlaps(RectTransform rectTrans1, RectTransform rectTrans2)
    {
        var b1 = RectTransformUtility.CalculateRelativeRectTransformBounds(_canvas.transform, rectTrans1);
        var b2 = RectTransformUtility.CalculateRelativeRectTransformBounds(_canvas.transform, rectTrans2);

        Debug.Log($"bound1: {b1} / bound2: {b2}");
        return b1.Intersects(b2);
    }
}
