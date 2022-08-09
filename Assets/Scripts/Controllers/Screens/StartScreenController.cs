using UnityEngine;
using System;

public class StartScreenController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public Action OnStartScreenDestroy;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _animator.SetTrigger("StartFiller");
        }
    }

    private void DestroyStartScreen()
    {
        OnStartScreenDestroy?.Invoke();
        Destroy(gameObject);
    }
}
