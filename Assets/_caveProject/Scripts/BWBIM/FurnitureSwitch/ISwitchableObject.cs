using UnityEngine;
using UnityEngine.Events;

namespace Buildwise.BIM
{
    internal interface ISwitchableObject
    {
        GameObject Parent { get; set; }
    }
}