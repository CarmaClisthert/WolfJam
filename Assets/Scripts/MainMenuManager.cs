using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Image background;

    [SerializeField]
    private Sprite howToPlay;
    [SerializeField]
    private GameObject[] buttons;
    // start, quit, start fr

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuManager(int i)
    {
        switch (i)
        {
            case 0://start
                background.sprite = howToPlay;
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                buttons[2].SetActive(true);
                break;
            case 1://quit
                Application.Quit();
                break;
            case 2://start fr
                SceneManager.LoadScene(1);
                break;
        }
    }
}
