using System;
using System.Windows.Forms;

namespace Assets.Scripts.StandaloneFileBrowser
{
    public class WindowWrapper : IWin32Window
    {
        public WindowWrapper(IntPtr handle) { Handle = handle; }
        public IntPtr Handle { get; }
    }
}