using UnityEngine;

public class Wall : MonoBehaviour, ICanbeSelected
{
    public float Height { get; set; }
    public float Width { get; set; }
    public string Name { get; set; }

    Material originalMaterial;
    Material selectedMaterial;


    private MeshRenderer meRenderer;

    private void Start()
    {
        Height = this.gameObject.transform.localScale.y;
        Width = this.gameObject.transform.localScale.x;
        Name = this.gameObject.name;

        originalMaterial = MaterialLib.Instance.Grey;
        selectedMaterial = MaterialLib.Instance.Blue;

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
}
