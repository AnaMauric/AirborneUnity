using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Reflection;
using TMPro;


public class CoinsManager : MonoBehaviour
{

    public static int amountOfCoins = 0;
    public static int pickedUpCoins = 0; 

    public GameObject textMeshProGameObject;
    private static TextMeshProUGUI leftCoinsText;
    public static AudioSource aSrc = null;

    public static void pickedUp()
    {
        pickedUpCoins += 9;

        SetUpCoinsText();

        if (HasWon())
        {
            aSrc.Play(); // play winning sound

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

    // Start is called before the first frame update
    void Start()
    {
        amountOfCoins = transform.childCount;
        pickedUpCoins = 0;
        leftCoinsText = textMeshProGameObject.GetComponent<TextMeshProUGUI>();
        aSrc = GetComponent<AudioSource>();
        SetUpCoinsText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
