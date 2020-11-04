using UnityEngine;

public class MouseObj : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 100))
        {
            transform.position = hit.point;
        }
        
        print(transform.position);
    }
}