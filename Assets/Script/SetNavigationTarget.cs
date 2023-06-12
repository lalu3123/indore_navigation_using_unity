using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropdown;

    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();

    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 TargetPosition = Vector3.zero;
    private bool LineToggle=false;

    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = LineToggle;
    }

    private void Update()
    {
        if (LineToggle && TargetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, TargetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
        }
        // if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        // {
        //     LineToggle = !LineToggle;
        //     line.enabled = LineToggle;
        // }
    }

    public void SetCurrentNavigationTarget(int selectedValue)
    {
        TargetPosition = Vector3.zero;
        string selectedText = navigationTargetDropdown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.Equals(selectedText));
        if (currentTarget != null)
        {
            TargetPosition = currentTarget.PositionObject.transform.position;
            line.enabled = LineToggle;
        }
    }
    public void Togle_visiblity () {
        LineToggle = !LineToggle;
        line.enabled = LineToggle;
    }
}

