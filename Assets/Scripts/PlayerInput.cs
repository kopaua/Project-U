using System;
using UnityEngine;
using Zenject;

public class PlayerInput : ITickable, IInitializable
{
    public event Action OnMouseDown;
    public event Action OnMouseUp;

    [Inject] private SignalBus _signalBus;

    private Camera _camera;

    public void Initialize()
    {
        _camera = Camera.main;
    }

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown?.Invoke();
            RaycastFromCamera();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp?.Invoke();
        }
    }

    public Vector3 RaycastFromCamera()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
