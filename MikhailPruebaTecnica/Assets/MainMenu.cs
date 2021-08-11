using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int currentShip;
    public GameObject rocket;
    public GameObject ship;
    public GameObject ufo;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("fromScene", 0);
        currentShip = PlayerPrefs.GetInt("cShip", 0);

        if(currentShip == 0)
        {
            rocket.SetActive(true);
        }
        else if (currentShip == 1)
        {
            ship.SetActive(true);
        }
        else if (currentShip == 2)
        {
            ufo.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShipMinus()
    {
        if (currentShip == 0)
        {
            rocket.SetActive(false);
            ufo.SetActive(true);
            currentShip = 2;
            PlayerPrefs.SetInt("cShip", 2);
        }
        else if (currentShip == 1)
        {
            ship.SetActive(false);
            rocket.SetActive(true);
            currentShip = 0;
            PlayerPrefs.SetInt("cShip", 0);
        }
        else if (currentShip == 2)
        {
            ufo.SetActive(false);
            ship.SetActive(true);
            currentShip = 1;
            PlayerPrefs.SetInt("cShip", 1);
        }
    }

    public void ShipPlus()
    {
        if (currentShip == 0)
        {
            rocket.SetActive(false);
            ship.SetActive(true);
            currentShip = 1;
            PlayerPrefs.SetInt("cShip", 1);
        }
        else if (currentShip == 1)
        {
            ship.SetActive(false);
            ufo.SetActive(true);
            currentShip = 2;
            PlayerPrefs.SetInt("cShip", 2);
        }
        else if (currentShip == 2)
        {
            ufo.SetActive(false);
            rocket.SetActive(true);
            currentShip = 0;
            PlayerPrefs.SetInt("cShip", 0);
        }
    }
}
