using UnityEngine;
using Kamatte.Scenes;
using Kamatte.Fading;

namespace Kamatte.GameState
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
            UIManager.Instance.ChangeUI(SceneID.Title);
            ScreenFader.Instance.Init(0f);
        }
        public void OnShop()    //  ショップ状態の処理  
        {
            UIManager.Instance.ChangeUI(SceneID.Shop);
        }
    }
}