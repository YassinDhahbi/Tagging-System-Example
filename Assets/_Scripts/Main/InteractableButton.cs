using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    [SerializeField]
    private bool isPressed;

    private void Start()
    {
        EventManager.Instance.OnGameStart.Raise(gameObject);
    }

    public void SetIsPressed(bool state)
    {
        isPressed = state;
    }
}