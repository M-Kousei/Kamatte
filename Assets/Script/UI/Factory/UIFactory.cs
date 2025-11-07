using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Kamatte.UI.Buttons;
#if UNITY_EDITOR
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
#endif

namespace Kamatte.Core
{
    [CreateAssetMenu(menuName = "Factory/UIFactory")]
    public class UIFactory : ScriptableObject    //  UIコントローラーを生成する
    {
        [Serializable]
        public struct UIMap    //  シーンIDごとのコントローラープレハブ構造体
        {
            public ButtonControllerID buttonControllerID;
            public GameObject uiPrefab;
        }

        [SerializeField] private SceneToUIMap sceneToUIMap;
        private Dictionary<ButtonControllerID, GameObject> prefabDict;    //  シーンごとのUIプレハブ辞書

        [SerializeField] private UIMap[] uiMappings;    //  インスペクターからのアサイン用

        void OnEnable()
        {
            BuildUIMapping();    //  uiMappingを初期化
        }

#if UNITY_EDITOR
        void OnValidate()
        {
            EnsureAllEnumValuesExist();    //  配列要素数拡張
            AutoAssignPrefabs();    //  Enum対応Prefab自動登録
        }

        //  Enum対応Prefab自動登録
        private void AutoAssignPrefabs()
        {
            foreach (var controllerID in Enum.GetValues(typeof(ButtonControllerID)))
            {
                ButtonControllerID buttonControllerID = (ButtonControllerID)controllerID;
                string address = buttonControllerID.ToString();

                AddressableAssetSettings settings = AddressableAssetSettingsDefaultObject.Settings;
                AddressableAssetEntry foundEntry = null;

                foreach (var group in settings.groups)
                {
                    if (group == null) continue;

                    foundEntry = group.entries.FirstOrDefault(e => e != null && e.address == address);
                    if (foundEntry != null) break;
                }

                if (foundEntry == null)
                {
                    LogUtility.Log(LogPrefix.UiFactory, $"{address} に対応するAddressablesアセットが見つかりません。", LogLevel.Warning);
                    continue;
                }

                var path = AssetDatabase.GUIDToAssetPath(foundEntry.guid);
                var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);

                if (prefab == null)
                {
                    LogUtility.Log(LogPrefix.UiFactory, $"アドレス {address} に対応するPrefabが見つかりませんでした。", LogLevel.Warning);
                    continue;
                }

                int index = Array.FindIndex(uiMappings, m => m.buttonControllerID.Equals(buttonControllerID));
                if (index >= 0 && uiMappings[index].uiPrefab != prefab)
                {
                    uiMappings[index].uiPrefab = prefab;
                    LogUtility.Log(LogPrefix.UiFactory, $"{buttonControllerID} に {prefab.name} をAddressablesから自動割当しました。", LogLevel.Info);
                }

                GameObject uiPrefab = uiMappings[index].uiPrefab;
                if (uiPrefab != null && uiPrefab.name != buttonControllerID.ToString())
                {
                    uiMappings[index].uiPrefab = null;
                }
            }
        }

        //  配列の要素をEnumの要素数に拡張
        private void EnsureAllEnumValuesExist()
        {
            var enumValues = Enum.GetValues(typeof(ButtonControllerID)).Cast<ButtonControllerID>().ToArray();
            Dictionary<ButtonControllerID, UIMap> uniqueMap = new Dictionary<ButtonControllerID, UIMap>();

            foreach (var map in uiMappings)
            {
                if (!uniqueMap.ContainsKey(map.buttonControllerID))
                {
                    uniqueMap[map.buttonControllerID] = map;
                }
            }

            foreach (var id in enumValues)
            {
                if (!uniqueMap.ContainsKey(id))
                {
                    uniqueMap[id] = new UIMap
                    {
                        buttonControllerID = id,
                        uiPrefab = null
                    };
                }
            }

            uiMappings = uniqueMap.Values.ToArray();
        }

        //  stringでprefabを取得する
        private GameObject FindPrefabByName(string name)
        {
            string[] guids = AssetDatabase.FindAssets($"t:GameObject {name}");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                if (go != null && go.name == name)
                {
                    return go;
                }
            }
            return null;
        }
#endif

        //  シーンIDとUIControllerのペアの辞書を初期化
        void BuildUIMapping()
        {
            prefabDict = new();
            foreach (var map in uiMappings)
            {
                if (map.uiPrefab != null)
                {
                    prefabDict[map.buttonControllerID] = map.uiPrefab;
                }
            }
        }

        //  GameStateIDに対応したUIコントローラーを生成
        public IUIController CreateUI(GameStateID gameStateID)
        {
            if (!sceneToUIMap.TryGetControllerID(gameStateID, out var buttonControllerID))
            {
                LogUtility.Log(LogPrefix.UiFactory, $"SceneID {gameStateID} に対応する ButtonControllerID が見つかりません", LogLevel.Warning);
                return null;
            }

            if (!prefabDict.TryGetValue(buttonControllerID, out var prefab))
            {
                LogUtility.Log(LogPrefix.UiFactory, $"シーンIDに対応したUIコントローラーのプレハブがありません SceneID : {gameStateID}", LogLevel.Warning);
                return null;
            }

            var instance = Instantiate(prefab);
            var controller = instance.GetComponent<IUIController>();
            if (controller == null)
            {
                LogUtility.Log(LogPrefix.UiFactory, $"UIController doesn't have Controller Conponet UIController : {instance}", LogLevel.Error);
            }

            return controller;
        }
    }
}