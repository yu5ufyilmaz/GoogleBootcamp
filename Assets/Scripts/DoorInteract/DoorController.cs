using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorBody;
    public float openAngle = 90f;
    public float closeAngle = 0f;
    private Quaternion initialRotation;
    private bool isOpen = false;

    private void Start()
    {
        initialRotation = doorBody.localRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
            Quaternion targetRotation = isOpen ? initialRotation * Quaternion.Euler(0f, openAngle, 0f) : initialRotation;
            doorBody.localRotation = targetRotation;
        }
    }
}