using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Tooltip("This is a class that is used as the monobehaviour that inializes the managers in all of the scriptable objects")]
public class ScriptableObjectsInitializer : MonoBehaviour
{
    private void Awake()
    {
        EventManager.Instance.OnGameStart.Raise();
    }

    private void OnDisable()
    {
    }
}