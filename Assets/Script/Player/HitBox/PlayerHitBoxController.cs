using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;

namespace Kamatte.Player
{
    public class PlayerHitBoxMgr    //  ヒットボックス管理者
    {
        public List<HitBoxData> _hitBoxes;                       //  ヒットボックスデータ
        Dictionary<HitBoxID, HitBoxData> _hitbBoxDictionary;     //  当たり判定一覧
        Transform _leftHandTransform;                            //  プレイヤーの左手のトランスフォーム
        Transform _rightHandTransform;                           //  プレイヤーの右手のトランスフォーム
        HitBoxData _activeBox = null;                            //  アクティブになってる当たり判定

        HitBoxID activeID = HitBoxID.None;                       //  アクティブにするボックスID

        public PlayerHitBoxMgr(PlayerHitBoxData hitBoxData, Transform rightHandTF, Transform leftHandTF)    //  コンストラクタ
        {
            foreach (var box in hitBoxData.playerHitBoxes)
            {
                _hitbBoxDictionary[box.id] = box;
            }
                _hitBoxes = hitBoxData.playerHitBoxes;
            _rightHandTransform = rightHandTF;
            _leftHandTransform = leftHandTF;
        }

        void Initalize()    //  初期化
        {
            _hitbBoxDictionary = new Dictionary<HitBoxID, HitBoxData>();
        }

        public void EnableHitBox(HitBoxID id)    //  当たり判定有効化
        {
            if (_hitbBoxDictionary.TryGetValue(id, out var box))
            {
                _activeBox = box;
                LogUtility.Log(LogPrefix.playerHitBoxController, $"{id} ヒットボックス有効", LogLevel.Info);
            }
        }

        public void DisableHitBox(HitBoxID id)    //  当たり判定無効化
        {
            if (activeID.Equals(id))
            {
                _activeBox = null;
                LogUtility.Log(LogPrefix.playerHitBoxController, $"{id} ヒットボックス無効", LogLevel.Info);
            }
        }

        public void Update(TimeContext time)    //  毎フレーム実行処理
        {
            if (_activeBox == null) return;

            Vector3 center = (_leftHandTransform.position + _rightHandTransform.position) * 0.5f + _activeBox.offset;
            var hits = Physics.OverlapBox(center, _activeBox.size * 0.5f);

            foreach (var h in hits)
            {
                if (h.CompareTag("Sword"))
                {
                    LogUtility.Log(LogPrefix.playerHitBoxController, "白刃取り成功", LogLevel.Info);
                    SwordCatchEventBus.CatchSuccess();
                }
            }
        }
    }
}