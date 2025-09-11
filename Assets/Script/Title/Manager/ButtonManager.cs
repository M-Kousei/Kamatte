using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Kamatte.Utility;

namespace Kamatte.UI
{
    public class ButtonManager : MonoBehaviour    //  ボタン管理スクリプト
    {
        [System.Serializable]
        public class ButtonMapping
        {
            public ButtonID id;
            public Button button;

#if UNITY_EDITOR
            public void OnValidate()
            {
                button = SceneManager.GetActiveScene()
                    .GetRootGameObjects()
                    .SelectMany(go => go.GetComponentsInChildren<Button>(true))
                    .FirstOrDefault(b => string.Equals(b.name, id.ToString(), StringComparison.Ordinal));
                if (button != null)
                {
                    LogUtility.Log($"[AutoAssign] {id} に {button.name} を自動割当しました。", LogLevel.Info);
                }
                else
                {
                    LogUtility.Log($"[AutoAssign] {id} に対応するボタンが見つかりませんでした。", LogLevel.Warning);
                }
            }
#endif
        }

        [SerializeField] private ButtonMapping[] buttonMapping;
        
        private Dictionary<ButtonID, Button> buttonMap = new();

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (buttonMapping == null || buttonMapping.Length == 0)
            {
                return;
            }

            foreach (var mapping in buttonMapping)
            {
                if(mapping == null)
                {
                    continue;
                }
                if (mapping.button == null || mapping.button.name != mapping.id.ToString())
                {
                    mapping.OnValidate();
                }
            }
        }
#endif
        void Awake()
        {
            InitializeButtons();
        }

        private void InitializeButtons()    //  ボタンを初期化する
        {
            buttonMap.Clear(); // 先に初期化しておく
            foreach (ButtonMapping mapping in buttonMapping)
            {
                if (mapping.button != null)
                {
                    buttonMap[mapping.id] = mapping.button;
                }
            }
        }

        public void Register(ButtonID titleButtonID, Action callback)    //    ボタン反応入れ
        {
            if (buttonMap.TryGetValue(titleButtonID, out Button button))
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => callback?.Invoke());
            }
            else
            {
                LogUtility.Log($"[ButtonManager] ボタンが見つかりません: {titleButtonID}", LogLevel.Warning);
            }
        }

        public void SetInteractable(ButtonID titleButtonID, bool interactable)    //  ボタン反応するかどうかを設定
        {
            if (buttonMap.TryGetValue(titleButtonID, out var button))
            {
                button.interactable = interactable;
            }
        }

        public void DisableAllButtons()    //  ボタン全部反応不可能にする
        {
            foreach (var btn in buttonMap.Values)
            {
                btn.interactable = false;
            }
        }

        public void EnableAllButtons()    //  ボタン全部反応可能にする
        {
            foreach (var btn in buttonMap.Values)
            {
                btn.interactable = true;
            }
        }
    }
}
