using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Animator transitionAnim;
    public string SceneName;
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game close");
    }

    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneName);

    }
}
