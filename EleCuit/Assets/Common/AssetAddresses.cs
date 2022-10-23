using System.Linq;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;

namespace EC
{

    public static class Adds
    {
        #region constant
        public const string Assets = "Assets/";
        public const string dUI = "Assets/Internals/dUnitility/Sources/UI/dUI/";
        public const string MasterJson = "Assets/Data/Data/Master/Json/";
        public const string Stocks = "Assets/Stocks/";
        public const string GUIProKitSprite = "Assets/Stocks/GUI PRO Kit - Casual Game/ResourcesData/Sprite/";
        #endregion

        #region public static
        /// <summary> Addressablesのアドレス存在確認 </summary>
        public static async UniTask<bool> Exist(string address)
            => (await Addressables.LoadResourceLocationsAsync(address)).Any();
        #endregion
    }

}
