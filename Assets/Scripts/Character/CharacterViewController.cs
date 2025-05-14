using UnityEngine;

public class CharacterViewController : MonoBehaviour
{
    private const int MinPercentToChangeAnimation = 30;
    private const int InjuredLayerIndex = 1;

    [SerializeField] private Animator _animator;

    [SerializeField] private Character _character;

    [SerializeField] private ControlHub _controlHub;

    private void Update()
    {
        float healthPercent = (_character.Health / _character.MaxHealth) * 100f;

        if (healthPercent < MinPercentToChangeAnimation)
            _animator.SetLayerWeight(InjuredLayerIndex, 1);
        else
            _animator.SetLayerWeight(InjuredLayerIndex, 0);

        if (_character.CurrentVelocity.magnitude > 0)
            PlayRunningAnimation();
        else
            StopRunningAnimation();
    }

    private void PlayRunningAnimation() => _animator.SetBool("IsRunning", true);

    private void StopRunningAnimation() => _animator.SetBool("IsRunning", false);
}
