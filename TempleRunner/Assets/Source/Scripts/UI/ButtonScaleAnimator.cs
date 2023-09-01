using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScaleAnimator : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Vector3 _targetScale;
    [SerializeField] private float _animationDuration;

    private void Start()
    {
        if (_button == null)
            _button = GetComponent<Button>();

        AnimateScale();
    }

    private void AnimateScale()
    {
        transform.DOScale(_targetScale, _animationDuration)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
