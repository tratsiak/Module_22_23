using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IDamagable
{
    private const float MinDistanceToPointer = 0.1f;

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxHealth;

    [SerializeField] private CharacterView _characterViewController;
    [SerializeField] private GameObject _pointerPrefab;

    private Health _health;

    private NavMeshAgent _agent;

    private DirectionalRotation _rotator;

    private Pointer _pointer;

    private Vector3 _targetPosition;

    public float Health => _health.CurrentHealth;

    public float MaxHealth => _health.MaxHealth;

    public Vector3 CurrentVelocity => _agent.velocity;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _rotator = new DirectionalRotation(transform, _rotationSpeed);
        _health = new Health(_maxHealth);
        _pointer = new Pointer(_pointerPrefab);

        _targetPosition = transform.position;
    }

    private void Update()
    {
        _agent.SetDestination(_targetPosition);

        Vector3 directionToTarget = _targetPosition - transform.position;

        if (directionToTarget.magnitude < MinDistanceToPointer)
            _pointer.HidePointer();
        else
            _pointer.SetPointer(_targetPosition);

        if (_agent.velocity == Vector3.zero)
            return;

        _rotator.SetInputDirection(_agent.desiredVelocity);
        _rotator.Update(Time.deltaTime);
    }

    public void SetTargetPosition(Vector3 targetPosition) => _targetPosition = targetPosition;

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);

        if (_health.CurrentHealth <= 0)
        {
            _characterViewController.PlayDieAnimation();
        }
        else
            _characterViewController.PlayReactionAnimation();
    }
}
