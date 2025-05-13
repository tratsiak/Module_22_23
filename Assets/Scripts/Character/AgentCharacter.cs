using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private NavMeshAgent _agent;

    private DirectionalRotation _rotator;

    private Vector3 _targetPosition;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _rotator = new DirectionalRotation(transform, _rotationSpeed);

        _targetPosition = transform.position;
    }

    private void Update()
    {
        _agent.SetDestination(_targetPosition);

        if (_agent.velocity == Vector3.zero)
            return;

        _rotator.SetInputDirection(_agent.desiredVelocity);
        _rotator.Update(Time.deltaTime);
    }

    public void SetTargetPosition(Vector3 targetPosition) => _targetPosition = targetPosition;
}
