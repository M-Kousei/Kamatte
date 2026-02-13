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


        void Awake()
        {
            BuildDictionary();
            
            paramRead = new AnimParamRead();
            paramSet = new AnimParamSet();

            GeneratePlayerSystem();

            paramFacade = new(playerParam);

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
    }
}