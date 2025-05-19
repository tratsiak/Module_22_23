using UnityEngine;

public class MineSFX : MonoBehaviour
{
    [SerializeField] private GameObject _mineSFXPrefab;

    private void OnDestroy()
    {
        Instantiate(_mineSFXPrefab, transform.position, Quaternion.identity);
    }
}
