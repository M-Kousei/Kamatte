using UnityEngine;

namespace Kamatte.Core
{
    public class GameStateManager : MonoBehaviour    //  ゲーム状態が遷移に伴う変更指令を出す
    {
        public static GameStateManager Instance { get; private set; }

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            OnTitle();
        }

        public void OnTitle()    //  タイトル状態の処理
        {
            UIManager.Instance.ChangeUI(GameStateID.Title);
            ScreenFader.Instance.Init(0f);
        }

        public void OnShop()    //  ショップ状態の処理  
        {
            UIManager.Instance.ChangeUI(GameStateID.Shop);
        }

        public void OnSwordCatch()    //  ソードキャッチ状態
        {
            UIManager.Instance.ChangeUI(GameStateID.SwordCatch);
        }
    }
}