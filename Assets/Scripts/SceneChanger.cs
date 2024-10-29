using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject _panelLoading;
    [SerializeField] private float _durationShowPanel;
    [SerializeField] private int _currentIndexGameScene;
    [SerializeField] private int _nextIndexGameScene;


    public void HideLoadingPanel() => ShowPanel(false);

    public void LoadGameScene() => StartCoroutine(LoadScene(_currentIndexGameScene));

    public void LoadNextGameScene() => StartCoroutine(LoadScene(_nextIndexGameScene));

    public void LoadMainScene() => StartCoroutine(LoadScene(0));

    public void ShowPanel(bool isShow)
    {
        ActivatePanel(true);

        if (isShow)
            _panelLoading.GetComponent<Image>().DOFade(0, _durationShowPanel).OnComplete(() => ActivatePanel(false));
        else
            _panelLoading.GetComponent<Image>().DOFade(1, _durationShowPanel);
    }

    private IEnumerator LoadScene(int index)
    {
        Time.timeScale = 1.0f;
        ShowPanel(false);

        yield return new WaitForSeconds(_durationShowPanel);
        SceneManager.LoadScene(index);
    }

    private void ActivatePanel(bool isActivate) => _panelLoading.SetActive(isActivate);

}