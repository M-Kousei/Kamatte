using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Kamatte.Core
{
    public class ScreenFader : MonoBehaviour, IFadeConotroller    //  画面をフェードする
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
                LogUtility.Log(LogPrefix.ScreenFader, "画面のフェードに必要な参照が不足しています。", LogLevel.Warning);
            }
        }

        public void Init(float imageAlpha)
        {
            GameModeChagneEvents.OnChanged += SetModeChangeFade;
            canvasGroup.alpha = imageAlpha;
            fadeImage.raycastTarget = false;
        }

        public Task FadeOut(float duration, Color? fadeColor = null)    //  フェードアウト処理を開始する
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            SetFadeColor(fadeColor ?? Color.black);
            StartCoroutine(FadeCoroutine(0f, 1f, duration, tcs));
            return tcs.Task;
        }
       
        public Task FadeIn(float duration)    //  フェードイン処理を開始する    
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            StartCoroutine(FadeCoroutine(1f, 0f, duration, tcs));
            return tcs.Task;
        }

        private void SetModeChangeFade(GameMode prev, GameMode next)    //  ゲームモード変更時のフェードをセット
        {
            if(next == GameMode.SwordCatch)
            {
                FadeOut(1f);
            }
        }

        private void SetFadeColor(Color color)    //  フェードの色をセット
        {
            fadeImage.color = color;
        }

        private IEnumerator FadeCoroutine(float from, float to, float duration, TaskCompletionSource<bool> tcs)    //  フェードを行う
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
                yield return null;
            }

            canvasGroup.alpha = to;

            if (Mathf.Approximately(to, 0f))
            {
                canvas.enabled = false;
                canvasGroup.blocksRaycasts = false;
            }

            tcs.SetResult(true);
        }

        public void Deinit()
        {
            //  初期化解除処理
        }
    }
}