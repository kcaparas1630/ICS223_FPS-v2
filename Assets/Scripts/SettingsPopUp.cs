using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI difficultyValue;
    [SerializeField] private Slider sliderValue;
    [SerializeField] private OptionsPopUp options;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Open()
    {
        gameObject.SetActive(true);
        sliderValue.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(sliderValue.value);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void OnOkButton()
    {
        PlayerPrefs.SetInt("difficulty", (int)sliderValue.value);
        Close();
        options.Open();
    }
    public void OnCancelButton()
    {
        Close();
        options.Open();
    }
    public void UpdateDifficulty(float difficulty)
    {
        difficultyValue.text = "Difficulty: " +((int)difficulty).ToString();
    }
    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }
}
