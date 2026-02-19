using UnityEngine;

namespace Kamatte.Core
{
    public class BootTitleBGM : MonoBehaviour   //  タイトルBGM起動クラス
    {
        [SerializeField] private BGMData _bootBGM;

        void Start()
        {
            Time.timeScale = 0.5f;
            BGMManager.Instance.Play(_bootBGM);
        }
    }
}