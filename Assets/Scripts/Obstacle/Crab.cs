using System;
using UnityEngine;
using DG.Tweening;

public class Crab : Obstacle
{
    private Tweener _tweener;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _tweener = _transform.DOMove(new Vector3(GetTargetPositionX(1f), 0f, transform.position.z), 2.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo).SetUpdate(UpdateType.Fixed);    
    }

    private void OnDisable()
    {
        _tweener.Kill();
    }

    private float GetTargetPositionX(float startPositionX)
    {
        return _transform.position.x < startPositionX ? 3f:-3f;
    }
}
