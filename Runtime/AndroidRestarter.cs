#if UNITY_ANDROID
using JetBrains.Annotations;
using UnityEngine;

namespace Kogane.Internal
{
    [UsedImplicitly]
    internal class AndroidRestarter : IApplicationRestarter
    {
        void IApplicationRestarter.Restart()
        {
            // https://blog.nekonium.com/unity-restart-for-android/
            using var unityPlayer = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" );
            const int kIntent_FLAG_ACTIVITY_CLEAR_TASK = 0x00008000;
            const int kIntent_FLAG_ACTIVITY_NEW_TASK = 0x10000000;

            var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>( "currentActivity" );
            var pm = currentActivity.Call<AndroidJavaObject>( "getPackageManager" );
            var intent = pm.Call<AndroidJavaObject>( "getLaunchIntentForPackage", Application.identifier );

            intent.Call<AndroidJavaObject>( "setFlags", kIntent_FLAG_ACTIVITY_NEW_TASK | kIntent_FLAG_ACTIVITY_CLEAR_TASK );
            currentActivity.Call( "startActivity", intent );
            currentActivity.Call( "finish" );
            var process = new AndroidJavaClass( "android.os.Process" );
            var pid = process.CallStatic<int>( "myPid" );
            process.CallStatic( "killProcess", pid );
        }
    }
}

#endif