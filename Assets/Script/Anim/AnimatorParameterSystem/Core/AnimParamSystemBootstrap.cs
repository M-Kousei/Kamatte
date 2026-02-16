using System.Collections.Generic;
using UnityEngine;
using Kamatte.Core;
using Kamatte.Player;

namespace Kamatte.SwordCatch
{
    public class AnimParamSystemBootstrap_SwordCatch : MonoBehaviour    //  
    {
        [System.Serializable]
        class AnimatorBinding    //  
        {
            public AnimatorRole role;
            public Animator animator;
        }
        
        [SerializeField] List<AnimatorBinding> animatorBindings;
        Dictionary<AnimatorRole, Animator> animatorMap;

        AnimParamRead paramRead;
        AnimParamSet paramSet;

        AnimParamFacade_SwordCatch paramFacade;
        AnimParam_Player playerParam;
        AnimParam_Swinger swingerParam;

        void Awake()
        {
            BuildDictionary();
            
            paramRead = new AnimParamRead();
            paramSet = new AnimParamSet();

            GeneratePlayerSystem();
            GenerateSwingerSystem();

            paramFacade = new(playerParam, swingerParam);

            ServiceLocator.Register<AnimParamFacadeBase>(paramFacade);
        }

        void BuildDictionary()
        {
            animatorMap = new Dictionary<AnimatorRole, Animator>();

            foreach (var bind in animatorBindings)
            {
                if (!animatorMap.ContainsKey(bind.role))
                {
                    animatorMap.Add(bind.role, bind.animator);
                }
                else
                {
                    Debug.LogWarning($"Duplicate AnimatorRole: {bind.role}");
                }
            }
        }

        void GeneratePlayerSystem()
        {
            PlayerParam_Catch catchParam = new(animatorMap[AnimatorRole.Player], "Catch");
            
            PlayerAnimParamContext ctx = new PlayerAnimParamContext(catchParam);

            playerParam = new AnimParam_Player(animatorMap[AnimatorRole.Player], paramRead, paramSet,ctx);
        }

        void GenerateSwingerSystem()
        {
            SwingerParam_NormalSwing normalSwingParam = new(animatorMap[AnimatorRole.SwordSwinger], "NormalSwing");
            SwingerParam_FastSwing fastSwingParam = new(animatorMap[AnimatorRole.SwordSwinger], "FastSwing");
            SwingerParam_DelaySwing delaySwingParam = new(animatorMap[AnimatorRole.SwordSwinger], "DelaySwing");
            SwingerParam_IsHited isHitedParam = new(animatorMap[AnimatorRole.SwordSwinger], "IsHited");
            SwingerParam_IsCatch isCatchParam = new(animatorMap[AnimatorRole.SwordSwinger], "IsCatch");

            SwingerAnimParamContext ctx = new(normalSwingParam, fastSwingParam, delaySwingParam, isHitedParam, isCatchParam);

            swingerParam = new AnimParam_Swinger(animatorMap[AnimatorRole.SwordSwinger], paramRead, paramSet, ctx);
        }
    }
}