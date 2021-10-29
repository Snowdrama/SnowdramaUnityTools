using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.UI
{
    public class PauseMenuOptions : MonoBehaviour
    {
        public void QuitApplication()
        {
#if !UNITY_EDITOR
#if !UNITY_WEBGL
        Application.Quit();
#endif
#endif
        }
    }
}
