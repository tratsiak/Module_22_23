using UnityEngine;

public class ControlHub : MonoBehaviour
{
    [SerializeField] private Character _character;

    [SerializeField] private LayerMask _walkableMask;

    [SerializeField] private GameObject _pointerPrefab;

    private Controller _controller;

    private void Awake()
    {
        _controller = new PlayerCharacterController(_character, _walkableMask, _pointerPrefab);

        _controller.Enable();
    }

    private void Update()
    {
        _controller.Update();
    }

    public void EnableController() => _controller.Enable();

    public void DisableController() => _controller.Disable();
}
