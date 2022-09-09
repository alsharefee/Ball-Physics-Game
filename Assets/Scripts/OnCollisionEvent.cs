using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEvent : MonoBehaviour
{
    public string eventTagName;
    public UnityEvent OnCollisionEnterEvent;
    public UnityEvent OnCollisionExitEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(eventTagName))
            OnCollisionEnterEvent.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(eventTagName))
            OnCollisionExitEvent.Invoke();
    }
}
