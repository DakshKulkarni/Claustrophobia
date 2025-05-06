using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRLineVisualController : MonoBehaviour
{
    private XRInteractorLineVisual lineVisual;
    private bool isHovering = false;

    private void Awake()
    {
        lineVisual = GetComponent<XRInteractorLineVisual>();
        if (lineVisual == null)
        {
            Debug.LogError("XRInteractorLineVisual component is missing!");
            return;
        }

        // Disable Line Renderer at the start
        lineVisual.enabled = false;
    }

    private void Update()
    {
        if (isHovering)
        {
            lineVisual.enabled = true;  // Enable the line renderer when hovering over a grabbable object
        }
        else
        {
            lineVisual.enabled = false;  // Disable the line renderer when not hovering over a grabbable object
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throwable") || other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            isHovering = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Throwable") || other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            isHovering = false;
        }
    }
}
