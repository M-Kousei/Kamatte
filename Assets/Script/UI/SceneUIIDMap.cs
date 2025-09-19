using System;
using UnityEngine;
using Kamatte.Scenes;
using Kamatte.UI.Buttons;

[CreateAssetMenu(menuName = "Mapping/SceneUIIDMap")]
public class SceneToUIMap : ScriptableObject    //  SceneIDと他のUIIDを変換するためのMap
{
    [Serializable]
    public struct Mapping    //  ID変換用Map
    {
        public SceneID sceneID;
        public ButtonControllerID controllerID;
    }

    [SerializeField] private Mapping[] mappings;

    //  SceneIDに対応するコントローラーを抽出する
    public bool TryGetControllerID(SceneID sceneID, out ButtonControllerID controllerID)
    {
        foreach (var map in mappings)
        {
            if (map.sceneID == sceneID)
            {
                controllerID = map.controllerID;
                return true;
            }
        }
        controllerID = default;
        return false;
    }
}