using UnityEngine;

public class UserController : MonoBehaviour
{
    ICanbeSelected currentRemeberedObject;
    ICanbeSelected lastRemeberedObject;

    Tool currentTool;

    private void Start()
    {
        PlaceToWallCenterTool.EnabledMessage += WriteCurrentTool;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            if (currentTool?.myToolType == ToolType.PlaceToWallCenterTool)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    try
                    {
                        currentRemeberedObject = hit.transform.gameObject.GetComponent<ICanbeSelected>();
                    }
                    finally
                    {
                        
                        currentRemeberedObject?.Selected();
                        if (currentRemeberedObject?.GetType().Name == nameof(Wall)) {
                            lastRemeberedObject?.Deselected();
                            ((PlaceToWallCenterTool)currentTool).CurrentWall = (Wall)currentRemeberedObject;
                            lastRemeberedObject = currentRemeberedObject;
                        } else if (currentRemeberedObject?.GetType().Name == nameof(Item))
                            {
                                ((PlaceToWallCenterTool)currentTool).CurrentItem = (Item)currentRemeberedObject;
                        }

                    }
                }
            }
            
        }
        
    }

    void WriteCurrentTool(Tool tool) {
        currentTool = tool;
    }
}
