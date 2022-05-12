using UnityEngine;
using DG.Tweening;

public class Crab : Obstacle
{
    private void OnEnable()
    {
        transform.DOMove(new Vector3(GetTargetPositionX(1f), 0f, transform.position.z), 2.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo).SetUpdate(UpdateType.Fixed);
    }

    private float GetTargetPositionX(float startPositionX)
    {
        return transform.position.x < startPositionX ? 3f:-3f;
    }
}
