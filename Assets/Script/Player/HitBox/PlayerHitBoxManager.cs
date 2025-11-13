using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;

namespace Kamatte.Player
{
    public class PlayerHitBoxMgr    //  ヒットボックス管理者
    {
        public List<HitBoxData> _hitBoxes;                       //  ヒットボックスデータ
        Dictionary<HitBoxID, HitBoxData> _hitbBoxDictionary;     //  当たり判定一覧
        public Transform _playerHeadTF;                                   //  プレイヤーの頭
        public HitBoxData _activeBox = null;                            //  アクティブになってる当たり判定

        HitBoxID activeID = HitBoxID.Unknown;                       //  アクティブにするボックスID

        float elapsed;    //  経過時間

        public PlayerHitBoxMgr(PlayerHitBoxData hitBoxData, Transform playerHead)    //  コンストラクタ
        {
            _hitbBoxDictionary = new Dictionary<HitBoxID, HitBoxData>();
            foreach (var box in hitBoxData.playerHitBoxes)
            {
                _hitbBoxDictionary[box.id] = box;
            }
            _playerHeadTF = playerHead;
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

        public void Update()    //  毎フレーム実行処理
        {
            Debug.Log(77);
            if (_activeBox == null) return;
            var hits = Physics.OverlapBox(ResolveCenter(_playerHeadTF), _activeBox.size * 0.5f);    //  gpt とここから
            foreach (var h in hits)
            {
                if (h.CompareTag("Sword"))
                {
                    LogUtility.Log(LogPrefix.playerHitBoxController, "白刃取り成功", LogLevel.Info);
                    SwordCatchEventBus.CatchSuccess();
                }
            }
        }

        public Vector3 ResolveCenter(Transform owner) => _activeBox.anchorType switch    //  当たり判定の中心地を返す
        {
            HitBoxAnchorType.Transform => owner.position + owner.rotation * _activeBox.offset,
            HitBoxAnchorType.Bone => _activeBox.boneTransform.position + _activeBox.boneTransform.rotation * _activeBox.offset,
            HitBoxAnchorType.World => _activeBox.worldCenter != null ? _activeBox.worldCenter : Vector3.zero,
            _ => owner.position
        };
    }
}