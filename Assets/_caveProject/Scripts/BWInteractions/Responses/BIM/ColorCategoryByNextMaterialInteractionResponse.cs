using Buildwise.BIM;
using Buildwise.Core;
using Buildwise.Hovering;
using UnityEngine;

namespace Buildwise.Interactions
{
    public class ColorCategoryByNextMaterialInteractionResponse : MonoBehaviour, IInteractionResponse
    {
        [SerializeField] private GameObject _bimMaterialsManagerObject;
        [SerializeField] private GameObject _hoveringManager;
        [SerializeField] private BIMColorStateVariable _bimColorState;

        private IBIMMaterialsManager _bimMaterialsManager;
        private IHoveringResponse[] _hoveringResponses;
        private HelperFunctions _helper;
        
        private void Start()
        {
            if (_bimMaterialsManagerObject == null)
            {
                Debug.LogError("Missing BIMMaterialsManager on ColorCategoryByNextMaterialInteractionResponse");
                return;
            }
            else
            {
                _bimMaterialsManager = _bimMaterialsManagerObject.GetComponent<IBIMMaterialsManager>();
                if (_bimMaterialsManager == null)
                {
                    Debug.LogError("Missing IBIMMaterialsManager Component on the BIMManager");
                    return;
                }
            }
            if (_hoveringManager == null)
            {
                Debug.LogError("Missing HoveringManager on ColorCategoryByNextMaterialInteractionResponse");
                return;
            }
            else
            {
                _hoveringResponses = _hoveringManager.GetComponents<IHoveringResponse>();
                if (_hoveringResponses == null)
                {
                    Debug.LogError("Missing IHoveringResponse Component on the HoveringManager");
                    return;
                }
            }
            
            _helper = new HelperFunctions();
        }
        
        public void OnAction(Transform selection, RaycastHit hit)
        {
            if (_bimMaterialsManager == null) return;
            if (_bimColorState.Value != BIMColorState.NoBIMColor) return;
            
            int index = _helper.GetMaterialIndex(selection, hit);
            if (selection.TryGetComponent(out BIMObjectMaterialHandler bo))
            {
                foreach (var hoveringResponse in _hoveringResponses)
                {
                    hoveringResponse.ClearResponse(selection);
                }
                Material mat = bo.GetNextMaterial(index);
                BIMCategory bimCategory = bo.GetComponent<IBIMObject>().Category;
                _bimMaterialsManager.ColorWholeCategoryByNextMaterial(bimCategory, mat);
            }
        }
    }
}