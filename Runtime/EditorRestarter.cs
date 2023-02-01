#if UNITY_EDITOR
using JetBrains.Annotations;
using UnityEditor;

namespace Kogane.Internal
{
    [UsedImplicitly]
    internal class EditorRestarter : IApplicationRestarter
    {
        void IApplicationRestarter.Restart()
        {
            EditorApplication.ExitPlaymode();
            EditorApplication.delayCall += () => EditorApplication.EnterPlaymode();
        }
    }
}

#endif