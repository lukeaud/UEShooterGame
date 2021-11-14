using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    //private NightCounter m_nightCounter = NightCounter.Instance;

    [SerializeField]
    private GameObject m_firstVictim;

    [SerializeField]
    private GameObject m_secondVictim;

    [SerializeField]
    private GameObject m_thirdVictim;

    public int CharacterCounter = 8;

    public int m_WoodCount = 8;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Update()
    {
        Debug.Log($"NIGHT COUNT {NightCounter.Instance.NightCount}");
        Debug.Log($"WOOD COUNT {m_WoodCount}");
    }

    public void LoadMinigame()
    {
        SceneManager.LoadScene("WoodchuckScene", LoadSceneMode.Additive);
        NightCounter.Instance.NightCount++;
    }

    public void UnloadMinigame()
    {
        SceneManager.UnloadSceneAsync("WoodchuckScene");

        switch(NightCounter.Instance.NightCount)
        {
            case 1:
                {
                    m_firstVictim.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    m_secondVictim.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    m_thirdVictim.gameObject.SetActive(false);
                    break;
                }
            case 4:
                {
                    QuitGame();
                    break;
                }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("CampsiteScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
    public void ResumeGame()
    {
        //Clare 
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseMenu()
    {

    }

}
