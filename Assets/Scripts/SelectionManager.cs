//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SelectionManager : MonoBehaviour
//{
//    //var selection;
//    //var selectionRenderer;

//    [SerializeField] Material highLightMaterial;
//    // Start is called before the first frame update

//    // Update is called once per frame
//    void Update()
//    {
//        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hit;
//        if (Physics.Raycast(ray, out hit))
//        {
//            selection = hit.transform;
//            selectionRenderer = selection.GetComponent<Renderer>();
//            if (selectionRenderer != null)
//            {
//                selectionRenderer.material = highLightMaterial;
//            }
//        }    
//    }
//}
