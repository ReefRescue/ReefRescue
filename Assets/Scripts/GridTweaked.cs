using UnityEngine;

public class GridTweaked : MonoBehaviour
{
    [SerializeField]
    private Texture tex;

    [SerializeField]
    public Vector2 size = new Vector2(0.7f, 1.3f);

    [SerializeField]
    private Vector2Int render = new Vector2Int(5, 6);

    [SerializeField]
    private Vector2 offset = new Vector2(0, 0);

    [SerializeField]
    private Vector2 texScale = new Vector2(4.4f, 6.54f);

    [SerializeField]
    private Vector2 texOffset = new Vector2(0.8f, 0.75f);

    private void Awake()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material.mainTexture = tex;
        renderer.material.mainTextureScale = texScale;
        renderer.material.mainTextureOffset = texOffset;
        //renderer.material.SetFloat("RepeatX", transform.localScale.x / tempScale.x);
        //renderer.material.SetFloat("RepeatY", transform.localScale.y / tempScale.y);
    }

    private void Update()
    {
        //MeshRenderer renderer = GetComponent<MeshRenderer>();
        //renderer.material.mainTexture = tex;
        //renderer.material.mainTextureScale = texScale;
        //renderer.material.mainTextureOffset = texOffset;
    }

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size.x);
        int zCount = Mathf.RoundToInt(position.z / size.y);

        Vector3 result = new Vector3(
            (float)xCount * size.x + offset.x,
            0,
            (float)zCount * size.y + offset.y);

        result = transform.rotation * result;
        result += transform.position;

        return result;
    }

    public Vector3 GetNearestPointOnGridRelative(Vector3 position)
    {
        return GetNearestPointOnGrid(position + transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (size.x <= 0 || size.y <= 0 || render.x < 0 || render.y < 0) return;

        for (int x = -render.x; x <= render.x; x += 1)
        {
            for (int z = -render.y; z <= render.y; z += 1)
            {
                var point = GetNearestPointOnGridRelative(new Vector3(x * size.x, 0, z * size.y));
                if (x == 0 && z == 0)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawSphere(point, 0.125f);
                    Gizmos.color = Color.yellow;
                } else Gizmos.DrawSphere(point, 0.1f);
            }
                
        }
    }
}