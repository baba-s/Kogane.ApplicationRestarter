#if UNITY_IOS
using JetBrains.Annotations;
using UnityEngine;

namespace Kogane.Internal
{
    [UsedImplicitly]
    internal class iOSRestarter : IApplicationRestarter
    {
        void IApplicationRestarter.Restart()
        {
            Application.Quit();
        }
    }
}

#endif