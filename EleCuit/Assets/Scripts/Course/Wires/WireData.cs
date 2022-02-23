using System;
using UnityEngine;

namespace EleCuit.Course.Wire
{
    [CreateAssetMenu(menuName = "Scriptable/Create WireData")]
    public class WireData : ScriptableObject, IEquatable<WireData>
    {
        [SerializeField]
        private WireType m_type;
        [SerializeField]
        private Sprite m_sprite;
        [SerializeField]
        private Sprite m_icon;

        public WireType Type => m_type;
        public Sprite Sprite => m_sprite;
        public Sprite Icon => m_icon;

        public bool Equals(WireData other)
        {
            if (other is null) return false;
            else return m_type.Equals(other.m_type);
        }

        public override bool Equals(object other) =>
            other is WireData otherWire ? Equals(otherWire) : base.Equals(other);
        public override int GetHashCode()
        {
            return m_type.GetHashCode();
        }
    }
}