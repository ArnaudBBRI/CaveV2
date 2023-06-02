/*
using UnityEngine;
using System;
using Buildwise.Core;
using System.Collections.Generic;

namespace Buildwise.BIM
{
    public class FurnitureSwitcher : MonoBehaviour, IFurnitureSwitcher
    {
        [SerializeField] private FurnitureAlternatives _furnitureAlternatives;
        public IntReference HoveredSwitchableObjectInstanceID;

        public FurnitureAlternatives FurnitureAlternatives { get => _furnitureAlternatives; set => _furnitureAlternatives = value; }

        private List<GameObject> _inSceneFurnitureAlternatives;

        private void Start()
        {
            _inSceneFurnitureAlternatives = new List<GameObject>();
            foreach (var t in FindObjectsOfType<SwitchableParentObject>(true))
            {
                foreach (var alt in FurnitureAlternatives.Alternatives)
                {
                    foreach (var rootID in alt.RootUniqueIDs)
                    {
                        if (t.GetComponent<SwitchableParentObject>().UniqueFurnitureParentID == rootID)
                        {
                            _inSceneFurnitureAlternatives.Add(t.gameObject);
                            break;
                        }
                    }
                }
            }
        }

        public void SwitchFurniture()
        {
            Debug.Log("Switching furniture");
            GameObject oldParent = null;
            foreach (var t in FindObjectsOfType<SwitchableObject>())
            {
                if (t.gameObject.GetInstanceID() == HoveredSwitchableObjectInstanceID.Value)
                {
                    oldParent = t.gameObject.GetComponentInParent<SwitchableParentObject>().gameObject;
                    break;
                }
            }
            GameObject newParent = GetNextAlternativePrefab(oldParent);
            Vector3 newPosition = GetNextAlternativePosition(oldParent);
            Vector3 newOrientation = GetNextAlternativeOrientation(oldParent);
            string newUniqueID = GetUniqueRootID(oldParent);

            bool foundInScene = false;
            foreach (var alt in _inSceneFurnitureAlternatives)
            {
                if (alt.GetComponent<SwitchableParentObject>().UniqueFurnitureParentID == newUniqueID)
                {
                    alt.SetActive(true);
                    foundInScene = true;
                    break;
                }
            }
            oldParent.SetActive(false);

            if (!foundInScene)
            {
                var newFurniture = Instantiate(newParent, newPosition, Quaternion.Euler(newOrientation));
                if (newFurniture.TryGetComponent(out SwitchableParentObject spo) == false)
                {
                    SwitchableParentObject s = newFurniture.AddComponent<SwitchableParentObject>();
                    s.UniqueFurnitureParentID = newUniqueID;
                    HelperFunctions.AddComponentToAllChildren<SwitchableObject>(newFurniture.transform, false);
                }
            }
        }

        // TODO: move these functions into FurnitureAlternatives, as they are really related to that.

        private Vector3 GetNextAlternativeOrientation(GameObject selected)
        {
            string oldGuid = selected.GetComponent<SwitchableParentObject>().UniqueFurnitureParentID;
            foreach (var alternative in _furnitureAlternatives.Alternatives)
            {
                int index = Array.IndexOf(alternative.RootUniqueIDs, oldGuid);
                if (index == alternative.RootGameObjects.Length - 1)
                {
                    return alternative.Orientation[0];
                }
                else if (index == -1)
                {
                    continue;
                }
                else
                {
                    return alternative.Orientation[index + 1];
                }
            }
            Debug.LogError("Couldn't find orientation for next alternative furniture. Returning (0,0,0)");
            return new Vector3(0, 0, 0);
        }


        private Vector3 GetNextAlternativePosition(GameObject selected)
        {
            string oldGuid = selected.GetComponent<SwitchableParentObject>().UniqueFurnitureParentID;
            foreach (var alternative in _furnitureAlternatives.Alternatives)
            {
                int index = Array.IndexOf(alternative.RootUniqueIDs, oldGuid);
                if (index == alternative.RootGameObjects.Length - 1)
                {
                    return alternative.Coordinates[0];
                }
                else if (index == -1)
                {
                    continue;
                }
                else
                {
                    return alternative.Coordinates[index + 1];
                }
            }
            Debug.LogError("Couldn't find coordinates for next alternative furniture. Returning (0,0,0)");
            return new Vector3(0,0,0);
        }
        
        private GameObject GetNextAlternativePrefab(GameObject selected)
        {
            string oldGuid = selected.GetComponent<SwitchableParentObject>().UniqueFurnitureParentID;
            foreach (var alternative in _furnitureAlternatives.Alternatives)
            {
                int index = Array.IndexOf(alternative.RootUniqueIDs, oldGuid);
                if (index == alternative.RootGameObjects.Length - 1)
                {
                    return alternative.RootGameObjects[0];
                }
                else if (index == -1)
                {
                    continue;
                }
                else
                {
                    return alternative.RootGameObjects[index + 1];
                }
            }
            return null;
        }

        private string GetUniqueRootID(GameObject selected)
        {
            string oldGuid = selected.GetComponent<SwitchableParentObject>().UniqueFurnitureParentID;
            foreach (var alternative in _furnitureAlternatives.Alternatives)
            {
                int index = Array.IndexOf(alternative.RootUniqueIDs, oldGuid);
                if (index == alternative.RootGameObjects.Length - 1)
                {
                    return alternative.RootUniqueIDs[0];
                }
                else if (index == -1)
                {
                    continue;
                }
                else
                {
                    return alternative.RootUniqueIDs[index + 1];
                }
            }
            return null;
        }
    }
}
*/