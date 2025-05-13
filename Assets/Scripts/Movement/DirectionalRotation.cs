using UnityEngine;

public class DirectionalRotation
{
    private Transform _transform;

    private float _rotationSpeed;
    private float _minMagnitudeToRotate;

    private Vector3 _currentDirection;

    public DirectionalRotation(Transform transform, float rotationSpeed)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    public Quaternion CurrentRotation => _transform.rotation;

    public void Update(float deltaTime)
    {
        if (_currentDirection.magnitude < _minMagnitudeToRotate)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(_currentDirection.normalized);

        float step = _rotationSpeed * deltaTime;

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
    }

    public void SetInputDirection(Vector3 inputDirection) => _currentDirection = inputDirection;
}
