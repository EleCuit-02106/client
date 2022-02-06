using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityUtility.Collections;

namespace EleCuit.Course
{
    public interface IReadOnlyCourse
    {
        IReadOnlyReactiveMap<CourcePiece> Cource { get; }
    }
    /// <summary>
    /// コースそのもの
    /// </summary>
    public class Course : MonoBehaviour, IReadOnlyCourse
    {
        private CourcePiece[,] _dummyCource = new CourcePiece[4,8];
        private Map<CourcePiece> m_course;

        public IReadOnlyReactiveMap<CourcePiece> Cource => m_course;

        // Start is called before the first frame update
        void Start()
        {
            m_course = new Map<CourcePiece>(_dummyCource);
        }
    }
}