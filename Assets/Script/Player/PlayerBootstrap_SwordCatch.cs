using UnityEngine;
using Kamatte.Core;

namespace Kamatte.Player
{
    [RequireComponent(typeof(PlayerController))]
    [DisallowMultipleComponent]
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] PlayerController playerController; 
        [SerializeField] PlayerHitBoxData playerHitBoxData;
        [SerializeField] Transform playerHeadTF;

        void Awake()
        {
            if (playerController == null)
            {
                playerController = GetComponent<PlayerController>();
                Debug.LogWarning("playerController isn't assigned in the Inspector");
            }
            if(playerHitBoxData == null)
            {
                Debug.LogError("playerHitBoxData isn't assigned in the Inspector");
            }
            if (playerHeadTF == null)
            {
                Debug.LogError("playerHeadTF isn't assigned in the Inspector");
            }
            playerController.Initialize(playerHitBoxData, playerHeadTF);
        }

        void Start()
        {
        }
    }
}