using UnityEngine;

public class PlayerCharacterController : Controller
{
    private const int RightMouseButtonKey = 1;
    private const float MinDistanceToPointer = 0.1f;

    private LayerMask _mask;

    private Character _character;

    private GameObject _pointer;


    public PlayerCharacterController(Character character, LayerMask mask, GameObject pointer)
    {
        _character = character;
        _mask = mask;

        _pointer = Object.Instantiate(pointer);
    }

    protected override void UpdateLogic()
    {
        if (Input.GetMouseButtonDown(RightMouseButtonKey))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _mask))
            {
                SetPointer(hitInfo.point);

                SetTargetPosition(hitInfo.point);
            }
        }

        Vector3 directionToPointer = _pointer.transform.position - _character.transform.position;

        if (directionToPointer.magnitude < MinDistanceToPointer)
            RemovePointer();
    }

    private void SetPointer(Vector3 position)
    {
        _pointer.transform.position = position;

        _pointer.SetActive(true);
    }

    private void RemovePointer()
    {
        _pointer.SetActive(false);
    }

    private void SetTargetPosition(Vector3 targetPosition) => _character.SetTargetPosition(targetPosition);
}
