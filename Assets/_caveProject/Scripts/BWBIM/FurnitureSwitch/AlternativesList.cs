using System;
using UnityEngine;

namespace Buildwise.BIM
{
    [Serializable]
    public class AlternativesList
    {
        public GameObject[] RootGameObjects;
        public Vector3[] Coordinates;
        public Vector3[] Orientation;
        public string[] RootUniqueIDs;
    }
}