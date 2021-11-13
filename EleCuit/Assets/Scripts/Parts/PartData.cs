using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EleCuit.Parts
{
    /// <summary>
    /// 部品のマスターデータ
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable/Create PartData")]
    public class PartData : ScriptableObject, IEquatable<PartData>
    {
        [SerializeField]
        private string m_name;
        [SerializeField]
        private Sprite m_sprite;
        [SerializeField]
        private Sprite m_icon;

        /// <summary>
        /// 部品の名称
        /// </summary>
        public string Name => m_name;
        /// <summary>
        /// 部品の画像
        /// </summary>
        public Sprite Sprite => m_sprite;
        /// <summary>
        /// 部品アイコン
        /// </summary>
        public Sprite Icon => m_icon;

        public bool Equals(PartData other)
        {
            if (other is null) return false;
            else return m_name.Equals(other.m_name);
        }

        public override bool Equals(object other) =>
            other is PartData otherPart ? Equals(otherPart) : base.Equals(other);

        public override int GetHashCode()
        {
            if (m_name is null) return base.GetHashCode();
            else return m_name.GetHashCode();
        }
    }
}