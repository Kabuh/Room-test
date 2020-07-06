using UnityEngine;

public class PlaceToWallCenterTool : Tool
{
    [SerializeField] private PlacerWindowStructure ToolWindow;
    [SerializeField] private GameObject RoomCenter;

    public bool ToolEnabled;

    public delegate void ToolSender(Tool tool);
    public static event ToolSender EnabledMessage;

    public delegate void ToolAction(Item item, Wall wall);
    public static event ToolAction PlacementComplete;

    private Wall currentWall;
    private Item currentItem;

    public Wall CurrentWall
    {
        get
        {
            return currentWall;
        }
        set
        {
            currentWall = value;
            ToolWindow.WallText.text = currentWall.gameObject.name;
        }
    }
    public Item CurrentItem
    {
        get {
            return currentItem;
        } set
        {
            currentItem = value;
            ToolWindow.ItemText.text = currentItem.gameObject.name;
        }
    }


    private void Awake()
    {
        myToolType = ToolType.PlaceToWallCenterTool;
    }


    public void EnableWindow()
    {
        ToolWindow.gameObject.SetActive(true);
        ToolEnabled = true;
        EnabledMessage(this);
    }

    public void DisableWindow()
    {
        ToolWindow.gameObject.SetActive(false);
        ToolEnabled = false;
    }

    public void SwitchWindowState()
    {
        if (ToolWindow.gameObject.activeSelf) {
            DisableWindow();
            return;
        }
        EnableWindow();
    }

    //main function, can be a part of interface in larger project
    public void ActivateTool() {
        if (currentWall != null && currentItem != null) {
            Transform WallTransform = currentWall.transform; 
            Transform ItemTransform = currentItem.transform;

            ItemTransform.position = WallTransform.position;

            ItemTransform.position = Vector3.MoveTowards(ItemTransform.position, RoomCenter.transform.position, (currentItem.Offset + WallTransform.localScale.z / 2));


            ItemTransform.rotation = WallTransform.rotation;
            
        }
        DisableWindow();
        PlacementComplete(currentItem, CurrentWall);
    }


}
