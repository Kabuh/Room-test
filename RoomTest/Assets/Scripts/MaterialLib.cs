using UnityEngine;

public class MaterialLib : MonoBehaviour
{
    public static MaterialLib Instance;

    public Material Grey;
    public Material PinkBrown;
    public Material Blue;
    public Material Purple;

    private void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(this);
        }
        #endregion
    }


}
