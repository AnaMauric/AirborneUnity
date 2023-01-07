using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Reflection;
using TMPro;


public class CoinsManager : MonoBehaviour
{

    public static int amountOfCoins = 0;
    public static int pickedUpCoins = 0; // liters

    public GameObject textMeshProGameObject;
    private static TextMeshProUGUI leftCoinsText;

    public static void pickedUp()
    {
        pickedUpCoins += 1;

        SetUpCoinsText();

        if (HasWon())
        {
            Debug.Log("you've won the game bro");
            SceneManager.LoadScene("MainMenu");
        }

    }

    public static void SetUpCoinsText()
    {
        int leftCoins = amountOfCoins - pickedUpCoins;

        leftCoinsText.text = leftCoins.ToString();
    }

    public static bool HasWon()
    {
        return pickedUpCoins == amountOfCoins;
    }

    public static void WonGame()
    {
        SceneManager.LoadScene("MainMenu");
    }


    // Start is called before the first frame update
    void Start()
    {
        amountOfCoins = transform.childCount;
        leftCoinsText = textMeshProGameObject.GetComponent<TextMeshProUGUI>();
        SetUpCoinsText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
