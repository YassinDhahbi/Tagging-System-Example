using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "Event Manager", menuName = "Managers/Event Manager")]
public class EventManager : ScriptableObjectSingleton<EventManager>
{
    #region No Parameter GameEvents

    public GameEvent OnButtonPressed;
    public GameEvent OnButtonReleased;

    #endregion No Parameter GameEvents

    #region Parametered GameEvents

    public GameObjectGameEvent OnGameStart;

    #endregion Parametered GameEvents

    [ContextMenu("Start game")]
    public void StartGame()
    {
    }
}