using UnityEngine;
using Zenject;

public class PlayerInput : ITickable, IInitializable
{
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
            _signalBus.Fire<MouseDown>();
            Debug.Log("Click");
            RaycastFromCamera();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _signalBus.Fire<MouseUp>();
        }
    }

    private void RaycastFromCamera()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //  _inputState.InteractOnCLick(hit);
        }
    }
}
