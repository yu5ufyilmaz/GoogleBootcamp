using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public DoorController doorController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorController.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorController.enabled = false;
        }
    }
}