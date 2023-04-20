using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI soundEffectsButtonText;
    [SerializeField] private TextMeshProUGUI musicButtonText;

    private void Awake()
    {
        Instance = this;
        soundEffectsButton.onClick.AddListener(() => SoundEffectsButtonPressed());
        musicButton.onClick.AddListener(() => MusicButtonPressed());
        closeButton.onClick.AddListener(() => CloseButtonPressed());
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        UpdateVisual();

        Hide();
    }

    private void KitchenGameManager_OnGamePaused(object sender, EventArgs e)
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);

    }

    private void SoundEffectsButtonPressed()
    {
        SoundManager.Instance.ChangeVolume();
        UpdateVisual();
    }

    private void MusicButtonPressed()
    {
        MusicManager.Instance.ChangeVolume();
        UpdateVisual();
    } 
    private void CloseButtonPressed()
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectsButtonText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f).ToString();
        musicButtonText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f).ToString();
    }
}