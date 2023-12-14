using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class ImageController : MonoBehaviour
    {
        public static ImageController Instance { get; private set; }

        public RawImage Img;
        private Texture2D _mainTexture2D;

        private void Awake() => Instance = this;
        public void OnImageUpdate() => _mainTexture2D = (Texture2D)Img.mainTexture;

        public void OnEllipse()
        {
            if (_mainTexture2D == null) _mainTexture2D = (Texture2D)Img.mainTexture;
            var sourceTex = _mainTexture2D;

            var rW = sourceTex.width / 2;
            var rH = sourceTex.height / 2;
            var cx = sourceTex.width / 2;
            var cy = sourceTex.height / 2;

            var b = new Texture2D(sourceTex.width, sourceTex.height);
            for (var i = 0; i < sourceTex.height * sourceTex.width; i++)
            {
                var y = Mathf.FloorToInt(i / (float)sourceTex.width);
                var x = Mathf.FloorToInt(i - (float)(y * sourceTex.width));
                var c = sourceTex.GetPixel(x, y);
                b.SetPixel(x, y,
                    1 >= (x - cx) * (x - cx) / (float)(rW * rW) +
                    (y - cy) * (y - cy) / (float)(rH * rH)
                        ? c
                        : Color.clear);
            }
            b.Apply();
            Img.texture = b;
        }
        public void OnSquare()
        {
            if (_mainTexture2D == null) _mainTexture2D = (Texture2D)Img.mainTexture;
            var sourceTex = _mainTexture2D;

            var r = sourceTex.height < sourceTex.width ? sourceTex.height / 2 : sourceTex.width / 2;
            var h = r * 2;
            var w = r * 2;
            var sx = sourceTex.height > sourceTex.width ? 0 : (sourceTex.width - r * 2) / 2;
            var sy = sourceTex.height > sourceTex.width ? (sourceTex.height - r * 2) / 2 : 0;
            var ex = sx + r * 2;
            var ey = sy + r * 2;


            var b = new Texture2D(w, h);
            for (var i = 0; i < sourceTex.height * sourceTex.width; i++)
            {
                var y = Mathf.FloorToInt(i / (float)sourceTex.width);
                var x = Mathf.FloorToInt(i - (float)(y * sourceTex.width));
                var c = sourceTex.GetPixel(x, y);
                if (y >= sy && y <= ey && x >= sx && x <= ex)
                {
                    b.SetPixel(x - sx, y - sy, c);
                }
            }
            b.Apply();
            Img.texture = b;
        }
        public void OnCircle()
        {
            if (_mainTexture2D == null) _mainTexture2D = (Texture2D)Img.mainTexture;
            var sourceTex = _mainTexture2D;

            var r = sourceTex.height < sourceTex.width ? sourceTex.height / 2 : sourceTex.width / 2;
            var h = r * 2;
            var w = r * 2;
            var sx = sourceTex.height > sourceTex.width ? 0 : (sourceTex.width - r * 2) / 2;
            var sy = sourceTex.height > sourceTex.width ? (sourceTex.height - r * 2) / 2 : 0;
            var cx = sourceTex.width / 2;
            var cy = sourceTex.height / 2;
            var ex = sx + r * 2;
            var ey = sy + r * 2;

            var b = new Texture2D(w, h);
            for (var i = 0; i < sourceTex.height * sourceTex.width; i++)
            {
                var y = Mathf.FloorToInt(i / (float)sourceTex.width);
                var x = Mathf.FloorToInt(i - (float)(y * sourceTex.width));
                var c = sourceTex.GetPixel(x, y);
                if (y < sy || y > ey || x < sx || x > ex) continue;
                b.SetPixel(x - sx, y - sy, r * r >= (x - cx) * (x - cx) + (y - cy) * (y - cy) ? c : Color.clear);
            }
            b.Apply();
            Img.texture = b;
        }
    }
}
