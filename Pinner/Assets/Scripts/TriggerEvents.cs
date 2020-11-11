using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public UnityEvent enterEvent, stayEvent, exitEvent;
    private MeshRenderer mesh;
    
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        enterEvent.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        stayEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        exitEvent.Invoke();
    }
}
