using System.Collections.Generic;
using UnityEngine;
using Kamatte.Scenes;
using Kamatte.UI.Interface;
using Kamatte.UI.Factory;

public class UIManager : MonoBehaviour    //  包括的なUI管理をする
{
    private Dictionary<SceneID, IUIController> uiCache = new();
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

    //  シーン単位でUIを変更する
    public void ChangeUI(SceneID sceneID)
    {
        currentUIController?.Deinit();    //  現在のUIを無効果


        if (!uiCache.TryGetValue(sceneID, out var ui))
        {
            ui = uiFactory.CreateUI(sceneID);
            uiCache[sceneID] = ui;
        }
        currentUIController = ui;
        currentUIController.Init();  // 新しいUIを初期化
    }
}