using UnityEngine;

namespace EleCuit.Parts
{
    public interface IReadOnlyPart
    {
        PartData PartData { get; }
    }
    /// <summary>
    /// 電子回路部品
    /// </summary>
    public interface IPart : IReadOnlyPart
    {
        /// <summary>
        /// 電子回路部品の効果を発揮する
        /// </summary>
        void Affect();
    }
    public abstract class Part : MonoBehaviour, IPart
    {
        [SerializeField]
        private PartData m_partData;

        public PartData PartData => m_partData;

        public abstract void Affect();
    }
}