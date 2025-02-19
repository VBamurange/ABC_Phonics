using UnityEngine;

public class FrontText : MonoBehaviour
{
    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (arCamera != null)
        {
            transform.LookAt(transform.position + arCamera.transform.rotation * Vector3.forward, arCamera.transform.rotation * Vector3.up);
        }
    }
}
