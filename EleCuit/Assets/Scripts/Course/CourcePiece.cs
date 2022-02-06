using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using EleCuit.Parts;

namespace EleCuit.Course
{
    public record CourcePiece(PieceType PieceType, PartType PartType)
    {

    }

    public enum PieceType
    {
        None,
        Part,
        Circuit,
    }
}