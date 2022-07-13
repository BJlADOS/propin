using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dialogue : MonoBehaviour
{
    [System.Serializable]
    private struct DialogueData
    {
        public List<string> Lines;
    }
    public TextAsset DialogueFile;
    public Sprite SpeakerIcon;
    public string SpeakerName;
    private DialogueData Data;
    private int CurrentLineIndex = 0;
    private DialogueUI UI;
    private void Awake()
    {
        Data = JsonUtility.FromJson<DialogueData>(DialogueFile.text);
    }

    private void Start()
    {
        UI = DialogueUI.Instance;
    }

    public void Advance()
    {
        if (CurrentLineIndex >= Data.Lines.Count)
        {
            CurrentLineIndex = 0;
        }
        UI.SetSpeakerIcon(SpeakerIcon);
        UI.SetSpeakerName(SpeakerName);
        UI.SetText(Data.Lines[CurrentLineIndex]);
        CurrentLineIndex++;
    }

    public void PlayerLeft()
    {
        CurrentLineIndex = 0;
        UI.Hide();
    }
}


