using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIService : MonoSingleton<UIService> {

    /*private enum MenuState { GAME, PAUSED, GAMEOVER, NEXTLEVEL }
    private MenuState currentMenuState = MenuState.GAME;*/

    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject NextLevelScreen;

    [SerializeField] private GameObject GODefaultButton;
    [SerializeField] private GameObject NLDefaultButton;

    private EventSystem eventSystem;

    private void Start() {
        eventSystem = EventSystem.current;
    }

    public void DisplayGameOverScreen() {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
        eventSystem.SetSelectedGameObject(GODefaultButton);
    }

    public void DisplayNextLevelScreen() {
        Time.timeScale = 0;
        NextLevelScreen.SetActive(true);

        // arranging the buttons is must lol
        // they will be there only enable and disable depending on shit
        // this method will take input of what powers to display
    }

    public void OnTryAgainButtonClicked() {
        LevelService.Instance.TryAgain();
        Time.timeScale = 1;
    }

    public void OnNextLevelButtonClicked(int power) {
        LevelService.Instance.NextLevel((BomberStats.Power)power);
        Time.timeScale = 1;
    }

}
