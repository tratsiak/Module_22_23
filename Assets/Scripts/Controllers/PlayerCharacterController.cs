using UnityEngine;

public class PlayerCharacterController : Controller
{
    private const int RightMouseButtonKey = 1;

    private LayerMask _mask;

    private Character _character;

    public PlayerCharacterController(Character character, LayerMask mask)
    {
        _character = character;
        _mask = mask;
    }

    protected override void UpdateLogic()
    {
        if (Input.GetMouseButtonDown(RightMouseButtonKey))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _mask))
                SetTargetPosition(hitInfo.point);
        }
    }

    private void SetTargetPosition(Vector3 targetPosition) => _character.SetTargetPosition(targetPosition);
}
