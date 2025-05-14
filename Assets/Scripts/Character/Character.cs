using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IDamagable
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxHealth;

    [SerializeField] private CharacterViewController _characterViewController;

    private HealthController _healthController;

    private NavMeshAgent _agent;

    private DirectionalRotation _rotator;

    private Vector3 _targetPosition;

    public float Health => _healthController.CurrentHealth;

    public float MaxHealth => _healthController.MaxHealth;

    public Vector3 CurrentVelocity => _agent.velocity;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;

        _rotator = new DirectionalRotation(transform, _rotationSpeed);
        _healthController = new HealthController(_maxHealth);

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

    public void TakeDamage(float damage)
    {
        _healthController.TakeDamage(damage);

        if (_healthController.CurrentHealth <= 0)
        {
            _characterViewController.PlayDieAnimation();
        }
        else
            _characterViewController.PlayReactionAnimation();
    }
}
