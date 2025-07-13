using UnityEngine;

namespace Gameplay.Configs.Meta.Wallet
{
    [CreateAssetMenu(menuName = "Configs/Meta/Wallet/NewCostsConfig", fileName = "CostsConfig")]
    public class CostsConfig : ScriptableObject
    {
        [field: SerializeField] public int WinCost { get; private set; } = 10;
        [field: SerializeField] public int LoseCost { get; private set; } = 5;
        [field: SerializeField] public int ResetCost { get; private set; } = 30;
    }
}

