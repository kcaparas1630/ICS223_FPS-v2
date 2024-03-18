using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopUp options;
    [SerializeField] private SettingsPopUp settings;
    [SerializeField] private GameOverPopup gameOverPopup;
    private int popupsActive = 0;
    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, UpdateHealth);
        Messenger.AddListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, OnPopupClosed);

    }
    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, UpdateHealth);
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, OnPopupClosed);

    }
    public void ShowGameOverPopup()
    {
        gameOverPopup.Open();
    }
    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }
    private void UpdateHealth(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
    }
    public void UpdateHealthBar(float healthPercentage)
    {
        UpdateHealth(healthPercentage);
    }
    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            Cursor.visible = false; // hide cursor
            crossHair.gameObject.SetActive(true); // show the crosshair
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
        }
        else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // let cursor move freely
            Cursor.visible = true; // show the cursor
            crossHair.gameObject.SetActive(false); // turn off the crosshair
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
        }
    }
    private void OnPopupOpened()
    {
        if (popupsActive == 0)
        {
            SetGameActive(false);
        }
        popupsActive++;
    }
    private void OnPopupClosed()
    {
        popupsActive--;
        if (popupsActive == 0)
        {
            SetGameActive(true);
        }
    }
    private void OnGameActive()
    {
        Debug.Log("Game is now active!");
    }

    private void OnGameInactive()
    {
        Debug.Log("Game is now inactive!");
    }
    // Start is called before the first frame update
    void Start()
    {
        //UpdateScore(score);
        UpdateHealth(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (popupsActive == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!options.IsActive() && !settings.IsActive())
                {
                    options.Open();
                }
                else
                {
                    options.Close();
                }
            }
        }

    }
}
