#if UNITY_EDITOR
using UnityEditor;

namespace Kogane.Internal
{
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