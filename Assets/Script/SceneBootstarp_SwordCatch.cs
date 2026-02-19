using UnityEngine;
using Kamatte.Core;
using TMPro;
using UnityEngine.UI;

namespace Kamatte.SwordCatch
{
    public class SceneBootstarp_SwordCatch : MonoBehaviour
    {
        [SerializeField] StateHolder_SwordCatch stateHolder;    //  ミニゲームのStateを集約してる、Reader層から呼ばれる。
        StateReader_SwordCatch stateReader;    //  下位クラスからStateClassへのFacade、Judgeインスタンスからアクセス可否を判断する。
        StateReadJudge_SwordCatch readJudge;    //  アクセスが適正かを判断する関数をReader層から呼ばれる。

        FadeOutStep fadeOutStep;

        ResultDisplay resultDisplay;
        [SerializeField] GameObject resultRoot;
        [SerializeField] TextMeshProUGUI playerPowerTxt;
        [SerializeField] Button RetryButton;

        StopAudio stopAudio;
        [SerializeField] AudioSource BgmSource;

        void Awake()
        {
            if (stateHolder == null)
            {
                Debug.LogError("stateHolder isn't assigned in the Inspector");
            }

            readJudge = new StateReadJudge_SwordCatch();
            stateReader = new StateReader_SwordCatch(stateHolder, readJudge);

            fadeOutStep = new FadeOutStep();
            resultDisplay = new ResultDisplay(resultRoot, playerPowerTxt, stateReader);
            stopAudio = new StopAudio(BgmSource);
        }

        void Start()
        {
            RetryButton.onClick.AddListener(Retry);
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().pushTask.PushStep(resultDisplay);
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().pushTask.PushStep(stopAudio);
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().pushTask.PushStep(fadeOutStep);
        }

        void Retry()
        {
            SceneUtility.LoadScene(SceneNameMap.GetName(SceneID.Shop));
        }
        void OnDestroy()
        {
            RetryButton.onClick.RemoveAllListeners();
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().removeTask.RemoveStep(resultDisplay);
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().removeTask.RemoveStep(stopAudio);
            ServiceLocator.Resolve<GameModeAPIFacadeBase>().removeTask.RemoveStep(fadeOutStep);
        }

    }
}