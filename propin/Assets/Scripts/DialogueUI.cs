using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TextMeshProUGUI SpeakerName;
    public Image SpeakerIcon;
    public static DialogueUI Instance
    {
        get => _instance;
    }
    private static DialogueUI _instance;

    private void Awake()
    {
        _instance = this;
        Hide();
    }

    public void SetSpeakerIcon(Sprite icon)
    {
        SpeakerIcon.sprite = icon;
    }

    public void SetSpeakerName(string name)
    {
        SpeakerName.text = name;
    }

    public void SetText(string text)
    {
        if (!gameObject.activeInHierarchy)
        {
            Show();
        }
        Text.text = text;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
