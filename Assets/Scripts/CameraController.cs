using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] Transform target;
    [SerializeField] public Vector4 distance = new Vector3(0f, 0.5f, -3f);
    [SerializeField] float smoothTime;

    Transform myT;

    public Vector3 velocity = Vector3.one;

    public bool thirdPerson = true;

    private void Awake() {
        myT = transform;
    }

    private void Start() {
        ChangeVisibilityOfTarget();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            thirdPerson = false;
            ChangeVisibilityOfTarget();
        } else if(Input.GetKeyDown(KeyCode.Alpha2)) {
            thirdPerson = true;
            ChangeVisibilityOfTarget();
        }
    }

    private void LateUpdate() {


        Vector3 toPos= target.position + (target.rotation * distance);
        if(thirdPerson) {
            myT.position = Vector3.SmoothDamp(myT.position, toPos, ref velocity, smoothTime);

            Quaternion modifiedRotation = Quaternion.Euler(target.rotation.eulerAngles.x, target.rotation.eulerAngles.y, 0.0f);

            Vector3 targetPosition = target.position + modifiedRotation * Vector3.forward * 12.5f;
            myT.LookAt(targetPosition, Vector3.up);
        } else {
            myT.position = target.position;
            myT.rotation = target.rotation;
        }
    }

    private void ChangeVisibilityOfTarget() {
        Component[] components = target.gameObject.GetComponentsInChildren(typeof(Renderer));
        foreach(Component component in components) {
            Renderer r = (Renderer) component;
            if(thirdPerson) {
                r.enabled = true;
            } else {
                r.enabled = false;
            }
        }
    }

}
