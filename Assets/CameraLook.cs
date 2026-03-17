using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float cameraSensitivity = 100f;
    [SerializeField] private float minLookDist;
    [SerializeField] private float maxLookDist;

    float camlookDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camlookDistance = transform.localRotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        camlookDistance = Mathf.Clamp(camlookDistance + Mouse.current.delta.x.ReadValue() * cameraSensitivity, minLookDist, maxLookDist);
        transform.localRotation = Quaternion.Euler(0f, camlookDistance, 0f);
    }
}
