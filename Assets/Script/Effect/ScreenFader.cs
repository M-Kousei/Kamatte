using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Kamatte.Logging;

namespace Kamatte.Fading
{
    public class ScreenFader : MonoBehaviour    //  画面をフェードする
    {
        public static ScreenFader Instance { get; private set; }

        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Canvas canvas;
        [SerializeField] private Image fadeImage;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (canvas == null || fadeImage == null || canvasGroup == null)
            {
                LogUtility.Log(LogPrefix.screenFader, "画面のフェードに必要な参照が不足しています。", LogLevel.Warning);
            }
        }

        public async Task FadeOut(float duration, Color? fadeColor = null)    //  フェードアウト処理を開始する
        {
            SetFadeColor(fadeColor ?? Color.black);
            await Fade(0, 1, duration);
        }
       
        public async Task FadeIn(float duration)    //  フェードイン処理を開始する    
        {
            await Fade(1, 0, duration);
        }

        private void SetFadeColor(Color color)    //  フェードの色をセット
        {
            fadeImage.color = color;
        }

        private async Task Fade(float from, float to, float duration)    //  フェードを行う
        {
            canvasGroup.blocksRaycasts = true;
            canvas.enabled = true;

            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / duration);
                float alpha = Mathf.Lerp(from, to, t);
                canvasGroup.alpha = alpha;
                await Task.Yield(); // 非同期待機（メインスレッドにやさしい）
            }

            canvasGroup.alpha = to;

            if (Mathf.Approximately(to, 0f))
            {
                canvas.enabled = false;
                canvasGroup.blocksRaycasts = false;
            }
        }
    }
}