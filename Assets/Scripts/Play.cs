using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButtonScript : MonoBehaviour {

    public Vector3 normalScale = new Vector3(1, 1, 1);
    public Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1.1f);
 
    private RectTransform rectTransform;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

    }

    void OnClick() {
        SceneManager.LoadScene("SampleScene");
        FuelManager.fuel = FuelManager.initialFuel;
    }


}
