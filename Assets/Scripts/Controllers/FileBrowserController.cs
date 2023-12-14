using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class FileBrowserController : MonoBehaviour
    {
        #region [BACKGROUND]
        [SerializeField] private RawImage _bgImage;
        private List<Texture> _bgTextures;
        private int _currentTextureIndex;

        public void SelectBackgroundImages()
        {
            _bgTextures = new List<Texture>();

            var paths = StandaloneFileBrowser.StandaloneFileBrowser.OpenFilePanel("Select Images", "", "jpg", true);
            foreach (var path in paths)
            {
                StartCoroutine(BgImageRoutine(new System.Uri(path).AbsoluteUri));
            }
        }
        private IEnumerator BgImageRoutine(string url)
        {
            var loader = new WWW(url);
            yield return loader;
            _bgTextures.Add(loader.texture);
        }
        #endregion
        #region [IMAGE]
        [SerializeField] private RawImage _outImage;

        public void OpenFileImage()
        {
            var paths = StandaloneFileBrowser.StandaloneFileBrowser.OpenFilePanel("Title", "", "jpg", false);
            if (paths.Length > 0)
            {
                StartCoroutine(OutImageRoutine(new System.Uri(paths[0]).AbsoluteUri));
            }
        }

        private IEnumerator OutImageRoutine(string url)
        {
            var loader = new WWW(url);
            yield return loader;
            _outImage.texture = loader.texture;

            ImageController.Instance.OnImageUpdate();
        }

        #endregion

        private IEnumerator Start()
        {
            while (true)
            {
                while (_bgTextures == null || _bgTextures.Count == 0) yield return new WaitForSeconds(1.0f);
                if (_currentTextureIndex == _bgTextures.Count - 1) _currentTextureIndex = 0;

                _bgImage.texture = _bgTextures[_currentTextureIndex];
                _currentTextureIndex++;

                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}