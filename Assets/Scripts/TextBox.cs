using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textBoxText;
    public MonologueBrick currentText;
    public static TextBox Instance;
    string txt;
    public bool IsPlaying;
    public bool MinigameIsPlaying;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (currentText != null && IsPlaying == false)
                changeText(currentText);
        }
    }
    public void changeText(MonologueBrick _textBlock)
    {
        StartCoroutine(readText(_textBlock.Text));
    }

    IEnumerator readText(string _text)
    {
        IsPlaying = true;
        char[] tmp = new char[_text.Length];
        for (int i = 0; i < _text.Length; i++)
        {
            tmp[i] = _text[i];
            yield return new WaitForSeconds(0.05f);
            textBoxText.SetText(tmp);
        }
        yield return new WaitForSeconds(1);
        if (currentText.nextBrick != null)
        {
            currentText = currentText.nextBrick;
            changeText(currentText);
        }
        else
        {
            currentText = null;
            yield return new WaitForSeconds(1);
            textBoxText.SetText("");
        }
        IsPlaying = false;
    }
}
