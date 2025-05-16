using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionDamage;
    [SerializeField] private float _timeToDetonation;

    private bool _isDetonating;

    private void Update()
    {
        if (_isDetonating)
            StartCoroutine(Detonate());
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagableObject = other.GetComponent<IDamagable>();

        if (damagableObject != null)
            _isDetonating = true;
    }

    private IEnumerator Detonate()
    {
        yield return new WaitForSeconds(_timeToDetonation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            IDamagable damagableObject = collider.GetComponent<IDamagable>();

            damagableObject?.TakeDamage(_explosionDamage);
        }

        Destroy(gameObject);
    }
}
