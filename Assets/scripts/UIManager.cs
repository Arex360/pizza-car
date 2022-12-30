using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject deleiverScreen;
    void Start()
    {
        instance = this;
    }
    public void ShowWinScreen(){
        winScreen.SetActive(true);
        Invoke(nameof(LevelUp),2f);
    }
    public void ShowLoseScreen(){
        loseScreen.SetActive(true);
        Invoke(nameof(Reload),2f);
    }
    public void ShowDeleiverScreen(){
        deleiverScreen.SetActive(true);
        Invoke(nameof(_hideDeleiverScreen),1.5f);
    }
    private void _hideDeleiverScreen(){
        deleiverScreen.SetActive(false);
    }
    private void LevelUp(){
        int nextScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        nextScene = Mathf.Clamp(nextScene,0,2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
    private void Reload(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

}
