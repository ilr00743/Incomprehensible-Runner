using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public event Action Finished;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            StartCoroutine(FinishAfterSeconds());
        }
    }

    private IEnumerator FinishAfterSeconds()
    {
        yield return new WaitForSeconds(1f);
        Finished?.Invoke();
    }
}
