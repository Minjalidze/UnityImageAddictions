using System;

namespace Assets.Scripts.StandaloneFileBrowser
{
    public class StandaloneFileBrowser
    {
        private static readonly IStandaloneFileBrowser PlatformWrapper;

        static StandaloneFileBrowser()
        {
            PlatformWrapper = new StandaloneFileBrowserWindows();
        }

        public static string[] OpenFilePanel(string title, string directory, string extension, bool multiselect)
        {
            var extensions = string.IsNullOrEmpty(extension) ? null : new[] { new ExtensionFilter("", extension) };
            return OpenFilePanel(title, directory, extensions, multiselect);
        }
        public static string[] OpenFilePanel(string title, string directory, ExtensionFilter[] extensions, bool multiselect)
        {
            return PlatformWrapper.OpenFilePanel(title, directory, extensions, multiselect);
        }
        public static void OpenFilePanelAsync(string title, string directory, string extension, bool multiselect, Action<string[]> cb)
        {
            var extensions = string.IsNullOrEmpty(extension) ? null : new[] { new ExtensionFilter("", extension) };
            OpenFilePanelAsync(title, directory, extensions, multiselect, cb);
        }
        public static void OpenFilePanelAsync(string title, string directory, ExtensionFilter[] extensions, bool multiselect, Action<string[]> cb)
        {
            PlatformWrapper.OpenFilePanelAsync(title, directory, extensions, multiselect, cb);
        }
        public static string[] OpenFolderPanel(string title, string directory, bool multiselect)
        {
            return PlatformWrapper.OpenFolderPanel(title, directory, multiselect);
        }
        public static void OpenFolderPanelAsync(string title, string directory, bool multiselect, Action<string[]> cb)
        {
            PlatformWrapper.OpenFolderPanelAsync(title, directory, multiselect, cb);
        }
        public static string SaveFilePanel(string title, string directory, string defaultName, string extension)
        {
            var extensions = string.IsNullOrEmpty(extension) ? null : new[] { new ExtensionFilter("", extension) };
            return SaveFilePanel(title, directory, defaultName, extensions);
        }
        public static string SaveFilePanel(string title, string directory, string defaultName, ExtensionFilter[] extensions)
        {
            return PlatformWrapper.SaveFilePanel(title, directory, defaultName, extensions);
        }
        public static void SaveFilePanelAsync(string title, string directory, string defaultName, string extension, Action<string> cb)
        {
            var extensions = string.IsNullOrEmpty(extension) ? null : new[] { new ExtensionFilter("", extension) };
            SaveFilePanelAsync(title, directory, defaultName, extensions, cb);
        }
        public static void SaveFilePanelAsync(string title, string directory, string defaultName, ExtensionFilter[] extensions, Action<string> cb)
        {
            PlatformWrapper.SaveFilePanelAsync(title, directory, defaultName, extensions, cb);
        }
    }
}