using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    GameOver
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    [SerializeField] private GameObject GameOverUi;
    [SerializeField] private int delay = 1;
    public GameState CurrentState { get; private set; }

    private Coroutine stateTransitionCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (GameOverUi != null)
        {
            GameOverUi.SetActive(false);
        }

        CurrentState = GameState.Playing;
    }

    private void Start()
    {
        Time.timeScale = 1;

        if (GameOverUi != null)
        {
            GameOverUi.SetActive(false);
        }
    }

    public void ChangeState(GameState newState)
    {
        if (CurrentState == newState) return;

        if (stateTransitionCoroutine != null)
        {
            StopCoroutine(stateTransitionCoroutine);
        }

        stateTransitionCoroutine = StartCoroutine(TransitionToState(newState));
    }

    public void ChangeToGameOver()
    {
        if (CurrentState != GameState.GameOver)
        {
            ChangeState(GameState.GameOver);
        }
    }

    private IEnumerator TransitionToState(GameState newState)
    {
        yield return new WaitForSeconds(delay);
        CurrentState = newState;
        HandleStateChange();
    }

    private void HandleStateChange()
    {
        switch (CurrentState)
        {
            case GameState.Playing:
                Time.timeScale = 1;
                if (GameOverUi != null)
                {
                    GameOverUi.SetActive(false);
                }
                break;

            case GameState.GameOver:
                Time.timeScale = 0;
                if (GameOverUi != null)
                {
                    GameOverUi.SetActive(true);
                }
                break;
        }
    }

    public void RestartGame()
    {
        CurrentState = GameState.Playing;
        Time.timeScale = 1;

        // Pastikan UI mati sebelum restart
        if (GameOverUi != null)
        {
            GameOverUi.SetActive(false);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}