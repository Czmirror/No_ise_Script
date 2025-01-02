using Cysharp.Threading.Tasks;

namespace _No_ise.Scripts.UI.Window
{
    public interface IWindowUI
    {
        UniTask Initialize();

        UniTask ShowUI(float duration);

        UniTask HideUI(float duration);
    }
}
