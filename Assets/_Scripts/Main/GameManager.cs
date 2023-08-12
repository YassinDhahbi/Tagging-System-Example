using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ButtonsManager buttonsManager;

    public void LoadCurrentScene(float delay)
    {
        Invoke(nameof(LoadScene), delay);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateNumberOfButtons()
    {
        buttonsManager.SyncColorWithNumber();
        EventManager.Instance.OnGameEnd.Raise(buttonsManager.IsTargetReached());
    }

    public void AddButton(GameObject button)
    {
        if (button.TryGetComponent(out InteractableButton interactable))
        {
            buttonsManager.AddButton(interactable);
        }
    }

    public void ShowWinPanel(GameObject winPanel)
    {
        winPanel.SetActive(buttonsManager.IsTargetReached());
    }
}

[System.Serializable]
public class ButtonsManager
{
    public int currentNumberOfPressedButtons;

    [SerializeField]
    private List<InteractableButton> listOfInteractableButtons;

    [SerializeField]
    private List<Image> listOfIndicators;

    [SerializeField]
    private Color pressedColor;

    [SerializeField]
    private Color releasedColor;

    [SerializeField]
    private GameObject indicatorPrefab;

    [SerializeField]
    private Transform UiHolder;

    public void SyncColorWithNumber()
    {
        var currentPressedBtns = 0;
        foreach (var item in listOfInteractableButtons)
        {
            if (item.GetIsPressed())
            {
                currentPressedBtns++;
            }
        }
        currentNumberOfPressedButtons = currentPressedBtns;
        ResetColor();
        for (int i = 0; i < currentNumberOfPressedButtons; i++)
        {
            listOfIndicators[i].color = pressedColor;
        }
    }

    public bool IsTargetReached()
    {
        return currentNumberOfPressedButtons == listOfInteractableButtons.Count;
    }

    private void ResetColor()
    {
        foreach (var item in listOfIndicators)
        {
            item.color = releasedColor;
        }
    }

    public void AddButton(InteractableButton interactable)
    {
        listOfInteractableButtons.Add(interactable);
        Image currentImage = Object.Instantiate(indicatorPrefab, UiHolder).GetComponent<Image>();
        currentImage.color = releasedColor;
        listOfIndicators.Add(currentImage);
    }
}