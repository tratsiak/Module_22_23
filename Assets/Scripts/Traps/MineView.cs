using UnityEngine;

public class MineView : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;

    private void OnDestroy()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
    }
}
