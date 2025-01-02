using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace _No_ise.Scripts.UI.Logo
{
    public class LogoAnimation : MonoBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;
        [SerializeField] private float _spacing = -416;
        [SerializeField] private float _endSpacing = -300;
        [SerializeField] private float _duration = 100;
        [SerializeField] private float _speed = 1;

        private void Reset()
        {
            _horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
        }

        private void Awake()
        {
            _horizontalLayoutGroup.spacing = _spacing;
            HorizeontalMoveLogo().Forget();
        }

        public async UniTask HorizeontalMoveLogo()
        {
            while (_horizontalLayoutGroup.spacing < _endSpacing)
            {
                _horizontalLayoutGroup.spacing += _speed;
                await UniTask.Delay(TimeSpan.FromMilliseconds(_duration));
            }
        }
    }
}
