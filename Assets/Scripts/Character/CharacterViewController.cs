using UnityEngine;

public class CharacterViewController : MonoBehaviour
{
    private const int MinPercentToChangeAnimation = 30;
    private const int InjuredLayerIndex = 1;
    private const float TimeToEndReactionAnimation = 1.7f;
    private const string IsRunningAnimationKey = "IsRunning";
    private const string IsReactionAnimationKey = "IsDamaged";
    private const string IsDiedAnimationKey = "IsDied";

    [SerializeField] private ControlHub _controlHub;

    [SerializeField] private Animator _animator;

    [SerializeField] private Character _character;

    private int _isRunningHash;
    private int _isReactionHash;
    private int _isDiedHash;

    private float _time;

    private bool _isReactionAnimationPlayed;

    private void Awake()
    {
        _isRunningHash = Animator.StringToHash(IsRunningAnimationKey);
        _isReactionHash = Animator.StringToHash(IsReactionAnimationKey);
        _isDiedHash = Animator.StringToHash(IsDiedAnimationKey);
    }

    private void Update()
    {
        if (_isReactionAnimationPlayed)
        {
            _time += Time.deltaTime;

            if (_time > TimeToEndReactionAnimation)
            {
                _isReactionAnimationPlayed = false;

                _controlHub.EnableController();

                _time = 0;
            }

        }

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

    public void PlayReactionAnimation()
    {
        _controlHub.DisableController();

        _animator.SetTrigger(_isReactionHash);

        _isReactionAnimationPlayed = true;
    }

    public void PlayDieAnimation()
    {
        _controlHub.DisableController();

        _animator.SetBool(_isDiedHash, true);
    }

    private void PlayRunningAnimation() => _animator.SetBool(_isRunningHash, true);

    private void StopRunningAnimation() => _animator.SetBool(_isRunningHash, false);
}
