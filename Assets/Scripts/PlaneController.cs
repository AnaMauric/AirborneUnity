using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlaneController : MonoBehaviour {
    [Header("Plane Stats")]
    [Tooltip("How much the throttle ramps up or down.")]
    public float throttleIncrement = 1f;
    [Tooltip("Maximum engine thrust when at 100% throttle.")]
    public float maxThrust = 600f;
    [Tooltip("How responsive the plane is when rolling, pitching and yawing.")]
    public float responsiveness = 3f;
    [Tooltip("How much lift force this plane generates as it gains speed.")]
    public float lift = 300f;

    // Fuel Consupmtion is in FuelManager script

    public GameObject explosion = null;

    public GameObject fire = null;

    Rigidbody rb;
    //[SerializeField] Text text;

    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;

    public RawImage pointer = null;

    public GameObject textMeshProGameObject;
    private TextMeshProUGUI timeText;

    private float time = 0.0f;

    private float roller = 0f;

    private void Awake() {
        rb = GetComponent<Rigidbody>();

        // Time displayed in bottom left timer
        timeText = textMeshProGameObject.GetComponent<TextMeshProUGUI>();
    }


    private float responseModifier {
        get {
            return (rb.mass / 5f) * responsiveness;
        }
    }

    private void HandleInputs(){
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        //if (FuelManager.fuel < 0f)
        //{
        //    throttle = 0f;
        //    return;
        //}
        if (Input.GetKey(KeyCode.Space))
        {
            throttle += throttleIncrement;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            throttle -= throttleIncrement;
        }
            
        throttle = Mathf.Clamp(throttle, 0f, 100f);

        // Hardcoded position of middle fire behind airplane - when the throttle is bigger it gets mroe out
        Vector3 newFirePos = new Vector3(0f, 0f, 9f + (100f - throttle) / 75f);
        fire.transform.localPosition = Vector3.Lerp(fire.transform.localPosition, newFirePos, Time.deltaTime * 3);
    }

    private void Update() {

        // If player has won we don't want to decrement fuel and increment time, since game is over, but he is still flying for few seconds
        if (CoinsManager.HasWon() == false)
        {
            time += Time.deltaTime;
            FuelManager.fuel -= Time.deltaTime * FuelManager.fuelConsumption * throttle;
        }

        if(FuelManager.HasEmptyFuel()) { // GameOver because of empty fuel
            gameObject.SetActive(false); // hides player
            GameObject instance = Instantiate(explosion, transform.position, Quaternion.identity); // instantiate particle system
            instance.GetComponent<ExplosionDestroyRestart>().isNewInstance = true;
        }
        PlayerPrefs.SetFloat("score", time);

        HandleInputs();
        UpdateInfo();
    }

    private void FixedUpdate() {

        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(-transform.right * pitch * responseModifier);
        rb.AddTorque(-transform.forward * roll * responseModifier);

        rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);

        //if (yaw == 0)
        //{
        //    roller /= 1.1f;
        //}
        //else
        //{
        //    roller = -yaw;
        //}
        //Quaternion newRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, roller * 45.0f);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 0.021f);

        //rb.AddTorque(-transform.right * pitch * responseModifier);
        //rb.AddTorque(transform.up * yaw * responseModifier);

        //rb.AddForce(transform.forward * maxThrust * throttle);
        //rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);

    }

    private void UpdateInfo() {
        //text.text = "Throttle: " + throttle.ToString("F0") + "%\n";
        //text.text += "Speed: " + (rb.velocity.magnitude * 13.6f).ToString("F0") + "km/h\n";
        //text.text += "Altitude: " + transform.position.y.ToString("F0") + " m\n";
        //text.text += "Score: " + time.ToString("F1") + "s\n";
        //text.text += "Fuel: " + FuelManager.fuel.ToString("F1") + "l";

        pointer.rectTransform.localEulerAngles = new Vector3(0f, 0f, 105f - 210f * FuelManager.fuel / FuelManager.initialFuel);

        TimeSpan ts = TimeSpan.FromSeconds(time);
        string timeString = ts.ToString(@"mm\:ss");
        timeText.text = timeString;

    }

}
