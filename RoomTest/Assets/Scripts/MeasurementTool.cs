using UnityEngine;
using UnityEngine.UI;

public class MeasurementTool : MonoBehaviour
{
    [SerializeField] private Image ToolWindow;
    [SerializeField] private Text CeilingText;
    [SerializeField] private Text NeighbourWallText;
    [SerializeField] private InputField newCeilingData;
    [SerializeField] private InputField newNeighbourWallData;

    Item item;
    Wall wall;

    [SerializeField]
    float distanceToCeiling;
    [SerializeField]
    float distanceToRightWall;

    void Start()
    {
        PlaceToWallCenterTool.PlacementComplete += ToolActivate;
    }

    void ToolActivate(Item newItem, Wall newWall) {
        ToolWindow.gameObject.SetActive(true);
        this.item = newItem;
        this.wall = newWall;
        DoMeasurments();
    }

    void DoMeasurments() {
        RaycastHit hit;
        if (Physics.Raycast(item.topEdge, transform.TransformDirection(Vector3.up), out hit, 1000f)) {
            Vector3 rayVector = hit.point - item.topEdge;
            distanceToCeiling = rayVector.magnitude;
        }
        
        

        RaycastHit secondHit;
        if (Physics.Raycast(item.rightEdge, item.transform.TransformDirection(Vector3.right), out secondHit, 1000f))
        {
            Vector3 rayVector = secondHit.point - item.rightEdge;
            distanceToRightWall = rayVector.magnitude;
        }
        UpdateText();

    }


    public void DisableWindow()
    {
        ToolWindow.gameObject.SetActive(false);
    }

    public void UpdateLocation(){
        float newNeighbourWallDataFloat = 0.0f;
        float newCeilingDataFloat = 0.0f;
        float horizontalDelta;
        float verticalDelta;

        if (newCeilingData.text != "") {
            newCeilingDataFloat = float.Parse(newCeilingData.text);
            verticalDelta =  newCeilingDataFloat - distanceToCeiling;
        }
        else
        {
            verticalDelta = 0.0f;
        }

        if ( newNeighbourWallData.text != "") {
            newNeighbourWallDataFloat = float.Parse(newNeighbourWallData.text);
            horizontalDelta = newNeighbourWallDataFloat - distanceToRightWall;
        }
        else
        {
            horizontalDelta = 0.0f;
        }

        item.UpdatePosition(horizontalDelta, verticalDelta);

        DoMeasurments();
    }

    void UpdateText() {
        CeilingText.text = distanceToCeiling.ToString() + "m";
        NeighbourWallText.text = distanceToRightWall.ToString() + "m";
    }

}
