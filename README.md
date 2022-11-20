# Kogane Application Restarter

アプリケーションを再起動できるパッケージ

## 使用例

```cs
using Kogane;
using UnityEngine;

public sealed class Example : MonoBehaviour
{
    private void Start()
    {
        ApplicationRestarter.Restart();
    }
}
```

## 対応しているプラットフォーム

* Unity Editor
* Android