using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopUp : BasePopup
{
    [SerializeField] private TextMeshProUGUI difficultyValue;
    [SerializeField] private Slider sliderValue;
    [SerializeField] private OptionsPopUp options;

    override public void Open()
    {
        base.Open();
        sliderValue.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(sliderValue.value);
    }
    override public void Close()
    {
        base.Close();
    }
    public void OnOkButton()
    {
        PlayerPrefs.SetInt("difficulty", (int)sliderValue.value);
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)sliderValue.value);
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
