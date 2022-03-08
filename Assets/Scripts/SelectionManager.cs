using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] string grabbableTag = "Grabbable";
    [SerializeField] string UITag = "Itext";
    [SerializeField] Material highLightMaterial;
    [SerializeField] Material defaultMaterial;

    public float pickUpRange = 5;
    public float moveForce = 250;
    public Transform holdParent;
    public GameObject UIText;
    private GameObject heldObj;
    private Transform _selection;

    void Start()
    {

    }

    void Update()
    {

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            var selection = hit.transform;

            if (selection.CompareTag(grabbableTag))
            {
                UIText.SetActive(true);
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    defaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = highLightMaterial;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (heldObj == null)
                    {
                        UIText.SetActive(false);
                        PickupObject(hit.transform.gameObject);
                    }
                    else
                    {
                        DropObject();
                    }
                }
                _selection = selection;
            }
            else
            {
                UIText.SetActive(false);
            }
        }
        else
        {
            UIText.SetActive(false);
        }


        if (heldObj != null)
        {
            UIText.SetActive(false);
            MoveObject();
        }

        //    if (Input.GetKeyDown(KeyCode.Alpha1))
        //    {
        //        RaycastHit hit;

        //        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        //        {
        //            var selection = hit.transform;
        //            var worker = selection.gameObject;
        //            if (selection.CompareTag("Worker"))
        //            {
        //                Debug.Log("Insult");
        //            }
        //        }
        //    }

        //    if (Input.GetKeyDown(KeyCode.Alpha2))
        //    {
        //        RaycastHit hit;
        //        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        //        {
        //            Debug.Log("Berate");
        //        }
        //    }

        //    if (Input.GetKeyDown(KeyCode.Alpha3))
        //    {
        //        RaycastHit hit;
        //        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        //        {
        //            Debug.Log("Praise");
        //        }
        //    }

        //    if (Input.GetKeyDown(KeyCode.Alpha4))
        //    {
        //        RaycastHit hit;
        //        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        //        {
        //            Debug.Log("Congratulate");
        //        }
        //    }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.freezeRotation = true;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.freezeRotation = false;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
