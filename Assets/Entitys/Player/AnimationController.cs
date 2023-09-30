using UnityEngine;
using Spine.Unity;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private SkeletonAnimation _animator;
    [SerializeField] private AnimationReferenceAsset _idle, _run, _kick, _slide;

    private void Start()
    {
        _movement.OnMove += Flip;
        _movement.OnSlide += () => SetAnitmation(_slide);
        _movement.OnStay += () => SetAnitmation(_idle);
    }

    private void SetAnitmation(AnimationReferenceAsset anim, bool isLooping = true, float timescale = 1)
    {
        if (anim.name == _animator.AnimationName) return;
        _animator.state.SetAnimation(0, anim, isLooping).TimeScale = timescale;
    }

    private void Flip(Vector2 value)
    {
        if (value.x > 0) _animator.Skeleton.ScaleX = 1;
        else if (value.x < 0) _animator.Skeleton.ScaleX = -1; 
        SetAnitmation(_run);
    }
}
