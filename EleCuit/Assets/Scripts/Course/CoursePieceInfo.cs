using System.Collections;
using System.Collections.Generic;
using EleCuit.Parts;
using UnityEngine;

namespace EleCuit.Course
{
    public record CoursePieceInfo
    (
        PieceType PieceType,
        WireType? WireType,
        PartType? PartType
    )
    {
        public static CoursePieceInfo Default() =>
            new CoursePieceInfo(PieceType.None, null, null);
    }

    public enum PieceType
    {
        None,
        Part,
        Circuit,
    }

    public enum WireType
    {
        LR,
        LU,
        LD,
        UR,
        DR
    }
}