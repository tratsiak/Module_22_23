using UnityEngine;

public class PlayerCharacterController : Controller
{
    private LayerMask _mask;

    private AgentCharacter _character;

    public PlayerCharacterController(AgentCharacter character, LayerMask mask)
    {
        _character = character;
        _mask = mask;
    }

    protected override void UpdateLogic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _mask))
            {
                SetTargetPosition(hitInfo.point);
            }
        }
    }

    private void SetTargetPosition(Vector3 targetPosition) => _character.SetTargetPosition(targetPosition);
}
