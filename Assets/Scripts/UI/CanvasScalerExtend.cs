using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerExtend : MonoBehaviour
{
    private CanvasScaler _canvasScaler;

    private void Awake()
    {
        _canvasScaler = GetComponent<CanvasScaler>();
    }

    private void Start()
    {
        _canvasScaler.referenceResolution = new Vector2(Screen.height, Screen.width);
    }
}
