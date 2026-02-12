using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;
using Kamatte.SwordCatch;

namespace Kamatte.Player
{
    public class PlayerHitBoxMgr    //  ヒットボックス管理者
    {
        Dictionary<HitBoxID, HitBoxData> _hitbBoxDictionary;    //  当たり判定一覧
        HitBoxData _activeBox = null;    //  アクティブになってる当たり判定
        PlayerController controller;
        public Transform _playerHeadTF;    //  プレイヤーの頭
        Animator _swordSwingerAnimator;    //  アニメーター
        HitBoxID activeID = HitBoxID.Unknown;                       //  アクティブにするボックスID
        Vector3 StarEffectPos;

        StateWriter_SwordCatch stateWriter;

        float elapsed;    //  経過時間

        public HitBoxData ActiveBox => _activeBox;

        public PlayerHitBoxMgr(PlayerHitBoxData hitBoxData, PlayerController playerController, Animator SwordSwingerAnim, Transform playerHead, Vector3 starEffectPos, StateWriter_SwordCatch writer)    //  コンストラクタ
        {
            _hitbBoxDictionary = new Dictionary<HitBoxID, HitBoxData>();
            foreach (var box in hitBoxData.playerHitBoxes)
            {
                _hitbBoxDictionary[box.id] = box;
            }
            controller = playerController;
            _swordSwingerAnimator = SwordSwingerAnim;
            _playerHeadTF = playerHead;
            StarEffectPos = starEffectPos;

            stateWriter = writer;
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
                activeID = box.id;
                LogUtility.Log(LogPrefix.playerHitBoxController, $"{id} ヒットボックス有効", LogLevel.Info);
            }
        }

        public void DisableHitBox(HitBoxID id)    //  当たり判定無効化
        {
            if (activeID.Equals(id))
            {
                _activeBox = null;
                LogUtility.Log(LogPrefix.playerHitBoxController, $"{id} ヒットボックス無効", LogLevel.Info);
                _swordSwingerAnimator.SetBool("isCatched", false);
                controller.isCatching = false;
            }
        }

        public void Update()    //  毎フレーム実行処理
        {
            if (_activeBox == null) return;
            var hits = Physics.OverlapBox(ResolveCenter(_playerHeadTF), _activeBox.size * 0.5f);    //  gpt とここから
            foreach (var h in hits)
            {
                if (h.CompareTag("Sword") && !controller.isHited)
                {
                    Debug.Log(controller.isCatching);
                    stateWriter.ChangeIsCatchState(true);
                    controller.isCatching = true;
                    EffectAPIWindow.Play(new EffectKey(GameMode.SwordCatch, EffectKind.CatchSword), StarEffectPos);

                    controller.PlayCatchSound();
                    LogUtility.Log(LogPrefix.playerHitBoxController, "白刃取り成功", LogLevel.Info);
                    SwordCatchEventBus.CatchSuccess();
                    _swordSwingerAnimator.SetBool("isCatched", true);
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