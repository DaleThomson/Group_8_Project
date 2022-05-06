using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] string grabbableTag = "Grabbable";
    [SerializeField] string workerTag = "Worker";
    [SerializeField] Material highLightMaterial;
    [SerializeField] Material defaultMaterial;

    public float pickUpRange = 5;
    public float moveForce = 250;
    public Transform holdParent;
    public GameObject UIText;
    public Text workerText;
    public GameObject worker;
    private GameObject heldObj;
    private Transform _selection;
    public TextMesh Pos1;
    public TextMesh Pos2;
    public TextMesh Pos3;
    public TextMesh Pos4;
    public TextMesh Pos5;
    public TextMesh Pos6;
    public TextMesh Pos7;
    public TextMesh Pos8;
    public TextMesh Pos9;
    public TextMesh Pos10;
    private TextMesh[] names = new TextMesh[11];
    int stringCount = 1;

    void Start()
    {
        names[1] = Pos1;
        names[2] = Pos2;
        names[3] = Pos3;
        names[4] = Pos4;
        names[5] = Pos5;
        names[6] = Pos6;
        names[7] = Pos7;
        names[8] = Pos8;
        names[9] = Pos9;
        names[10] = Pos10;
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
            if (selection.CompareTag(workerTag))
            {
                workerText.gameObject.SetActive(true);
                worker = hit.collider.gameObject;
                workerText.text = "Name: " + worker.GetComponent<Worker>().returnName() + "\nMorale: " + worker.GetComponent<Worker>().returnMorale().ToString() + "\nProductivity: " + worker.GetComponent<Worker>().returnProductivity().ToString() + "\n1. Bully\n2. Encourage\n3. Fire\n4. Upgrade";
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    defaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = highLightMaterial;
                }
                _selection = selection;
            }
            else
            {
                worker = null;
                workerText.gameObject.SetActive(false);
                UIText.SetActive(false);
            }
        }
        else
        {
            worker = null;
            workerText.gameObject.SetActive(false);
            UIText.SetActive(false);
        }


        if (heldObj != null)
        {
            UIText.SetActive(false);
            MoveObject();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                var selection = hit.transform;
                var worker = selection.gameObject;
                if (selection.CompareTag("Worker"))
                {
                    worker.GetComponent<Worker>().bully();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                var selection = hit.transform;
                var worker = selection.gameObject;
                if (selection.CompareTag("Worker"))
                {
                    worker.GetComponent<Worker>().encourage();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                var selection = hit.transform;
                var worker = selection.gameObject;
                if (selection.CompareTag("Worker"))
                {
                    names[stringCount].text = stringCount + ". " + worker.GetComponent<Worker>().returnName();
                    stringCount++;
                    worker.GetComponent<Worker>().fire();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
            {
                var selection = hit.transform;
                var worker = selection.gameObject;
                if (selection.CompareTag("Worker"))
                {
                    worker.GetComponent<Worker>().upgrade();
                }
            }
        }

        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        //    {
        //        Debug.Log("Praise");
        //    }
        //}

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
