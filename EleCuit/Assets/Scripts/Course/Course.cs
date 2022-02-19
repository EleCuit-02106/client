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
        IReadOnlyReactiveMap<CoursePieceInfo> CourseBody { get; }
    }
    /// <summary>
    /// コースそのもの
    /// </summary>
    public class Course : MonoBehaviour, IReadOnlyCourse
    {
        private CoursePieceInfo[,] _dummyCource = new CoursePieceInfo[4, 8];
        private Map<CoursePieceInfo> m_course;

        public IReadOnlyReactiveMap<CoursePieceInfo> CourseBody => m_course;

        // Start is called before the first frame update
        void Start()
        {
            m_course = new Map<CoursePieceInfo>(_dummyCource);
            m_course.ReWriteAll(_ => CoursePieceInfo.Default());
        }
    }
}