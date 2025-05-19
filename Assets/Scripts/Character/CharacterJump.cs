using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CharacterJump : MonoBehaviour
{
    [SerializeField] private float _jumpDuration;
    [SerializeField] private float _jumpHeight;

    private NavMeshAgent _agent;

    public bool IsJumping { get; private set; }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (IsJumping == false && _agent.isOnOffMeshLink)
        {
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        IsJumping = true;

        OffMeshLinkData linkData = _agent.currentOffMeshLinkData;

        Vector3 startPos = linkData.startPos;
        Vector3 endPos = linkData.endPos;

        float elapsedTime = 0f;

        while (elapsedTime < _jumpDuration)
        {
            float time = elapsedTime / _jumpDuration;
            float height = Mathf.Sin(time * Mathf.PI) * _jumpHeight;

            _agent.transform.position = Vector3.Lerp(startPos, endPos, time) + Vector3.up * height;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _agent.CompleteOffMeshLink();
        IsJumping = false;
    }
}
