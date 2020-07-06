using UnityEngine;

public class Item : MonoBehaviour, ICanbeSelected
{
    private MeshRenderer meRenderer;

    public float Height { get; set; }
    public float Width { get; set; }
    public float Offset { get; set; }

    private Vector3 horizontalOffset { get {
            return new Vector3(Width / 2 - 1, 0, 0);
        } }

    public Vector3 topEdge { get {
            return this.transform.position + new Vector3(0, Height / 2, 0);
        } }
    public Vector3 rightEdge { get {
            return transform.position + (this.transform.TransformDirection(Vector3.right + horizontalOffset));
        } }

    Material originalMaterial;
    Material selectedMaterial;

    private void Start()
    {
        

        Height = this.gameObject.transform.lossyScale.y;
        Width = this.gameObject.transform.lossyScale.x;
        Offset = this.gameObject.transform.lossyScale.z / 2;

        originalMaterial = MaterialLib.Instance.PinkBrown;
        selectedMaterial = MaterialLib.Instance.Purple;

        meRenderer = this.gameObject.GetComponent<MeshRenderer>();
    }

    public void Selected()
    {
        meRenderer.material = selectedMaterial;
    }

    public void Deselected()
    {
        meRenderer.material = originalMaterial; 
    }

    public void UpdatePosition(float horizontalDelta, float verticalDelta) {
        transform.Translate(Vector3.up * -verticalDelta, Space.Self);
        transform.Translate(Vector3.right * -horizontalDelta, Space.Self);
    }
    
}
