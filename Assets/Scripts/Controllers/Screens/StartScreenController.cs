using UnityEngine;
using System;

public class StartScreenController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public Action OnDestroyStart;
    public Action OnDestroyEnd;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _animator.SetTrigger("StartFiller");
            OnDestroyStart?.Invoke();
        }
    }

    private void DestroyStartScreen()
    {
        OnDestroyEnd?.Invoke();
        Destroy(gameObject);
    }
}
