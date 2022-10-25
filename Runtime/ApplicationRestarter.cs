using Kogane.Internal;

namespace Kogane
{
    public static class ApplicationRestarter
    {
        private static readonly IApplicationRestarter m_restarter =
#if UNITY_EDITOR
            new EditorRestarter();
#elif UNITY_ANDROID
            new AndroidRestarter();
#else
            null;
#endif

        public static void Restart()
        {
            m_restarter?.Restart();
        }
    }
}