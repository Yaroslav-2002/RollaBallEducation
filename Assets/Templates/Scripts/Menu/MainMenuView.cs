using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class MainMenuView : View
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;
    [SerializeField] private int _sceneIndex;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;

    public override void Initialize()
    {
        _settingsButton.onClick.AddListener(() => ViewManager.Show<SettingsMenu>());
        _playButton.onClick.AddListener(PlayGame);
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        StartCoroutine(LoadAsynchronously(_sceneIndex));
    }

    private void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    private IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}