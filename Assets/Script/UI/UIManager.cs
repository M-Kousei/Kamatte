using System.Collections.Generic;
using UnityEngine;

namespace Kamatte.Core
{
    public class UIManager : MonoBehaviour    //  包括的なUI管理をする
    {
        private Dictionary<GameStateID, IUIController> uiCache = new();
        [SerializeField] private UIFactory uiFactory;
        public static UIManager Instance { get; private set; }


        private IUIController currentUIController;


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

        //  ゲームステート単位でUIを変更する
        public void ChangeUI(GameStateID gameStateID)
        {
            currentUIController?.Deinit();    //  現在のUIを無効果

            if (!uiCache.TryGetValue(gameStateID, out var ui))
            {
                ui = uiFactory.CreateUI(gameStateID);
                uiCache[gameStateID] = ui;
            }

            currentUIController = ui;
            currentUIController.Init();    //  新しいUIを初期化
        }
    }
}