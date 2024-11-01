using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour

{
    public Text hightScoreText;
    public InputField inputName;

    

    int hightScore;
    string nameText;
    public string highScoreName;

    // Start is called before the first frame update
    void Start()
    {
        inputName.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        hightScore = ScoreManager.Instance.highScore;
        nameText = ScoreManager.Instance.enterName;
        highScoreName = ScoreManager.Instance.highScoreName;
        hightScoreText.text = $"Best Score : " + highScoreName + " : " + hightScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValueChangeCheck()
    {
        nameText = inputName.text;
        ScoreManager.Instance.enterName = nameText;
        ScoreManager.Instance.SaveHighScore();
        Debug.Log("Value Changed ");
    }

    public void StartNew()
    {
        ScoreManager.Instance.SaveHighScore();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ScoreManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
