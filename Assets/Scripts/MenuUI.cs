using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUI : MonoBehaviour 
{
    public TMP_InputField usernameInput;

    private void Start()
    {
        usernameInput.onEndEdit.AddListener(onEndEditUsernameInput);
    }

    private void onEndEditUsernameInput(string input)
    {
        GameManager.Instance.username = input;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
