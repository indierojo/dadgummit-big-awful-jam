using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Canvas selectAgeMenu;
    public Canvas questionOne;
    public Canvas questionTwo;
    public Canvas questionThree;
    public Canvas testStart;
    public Canvas successMenu;
    public Canvas failScreen;
    public Button playButton;
    public Button exitButton;

    public int questionNumber;

	// Use this for initialization
	void Start () {
        selectAgeMenu = selectAgeMenu.GetComponent<Canvas>();
        questionOne = questionOne.GetComponent<Canvas>();
        questionTwo = questionTwo.GetComponent<Canvas>();
        questionThree = questionThree.GetComponent<Canvas>();
        failScreen = failScreen.GetComponent<Canvas>();
        successMenu = successMenu.GetComponent<Canvas>();
        testStart = testStart.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

        selectAgeMenu.enabled = false;
        questionOne.enabled = false;
        questionTwo.enabled = false;
        questionThree.enabled = false;
        failScreen.enabled = false;
        testStart.enabled = false;
        successMenu.enabled = false;

        questionNumber = 0;
    }
	
    public void PlayPress()
    {
        playButton.enabled = false;
        exitButton.enabled = false;
        selectAgeMenu.enabled = false;
        questionOne.enabled = false;
        questionTwo.enabled = false;
        questionThree.enabled = false;
        failScreen.enabled = false;
        testStart.enabled = false;
        successMenu.enabled = false;

        switch (questionNumber)
        {
            case 0:
                selectAgeMenu.enabled = true;
                break;
            case 1:
                testStart.enabled = true;
                break;
            case 2:
                questionOne.enabled = true;
                break;
            case 3:
                questionTwo.enabled = true;
                break;
            case 4:
                questionThree.enabled = true;
                break;
            case 5:
                successMenu.enabled = true;
                break;
        }
        
    }

    public void BackPress()
    {
        playButton.enabled = true;
        exitButton.enabled = true;
        selectAgeMenu.enabled = false;
        questionOne.enabled = false;
        questionTwo.enabled = false;
        questionThree.enabled = false;
        failScreen.enabled = false;
        testStart.enabled = false;
        successMenu.enabled = false;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CorrectButton()
    {
        questionNumber += 1;
        PlayPress();
    }

    public void WrongButton()
    {
        failScreen.enabled = true;
        selectAgeMenu.enabled = false;
        questionOne.enabled = false;
        questionTwo.enabled = false;
        questionThree.enabled = false;
        testStart.enabled = false;
        successMenu.enabled = false;
    }

}
