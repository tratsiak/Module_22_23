using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private LayerMask _walkableMask;

    [SerializeField] private AgentCharacter _agentCharacter;

    private Controller _controller;

    private void Awake()
    {
        _controller = new PlayerCharacterController(_agentCharacter, _walkableMask);

        _controller.Enable();
    }

    private void Update()
    {
        _controller.Update();
    }
}
