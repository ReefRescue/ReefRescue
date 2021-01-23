using UnityEngine;

public class GridTweaked : MonoBehaviour
{
    [SerializeField]
    private float xSize = 1f;

    [SerializeField]
    private float zSize = 1f;

    [SerializeField]
    private int xRender = 20;

    [SerializeField]
    private int zRender = 20;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / xSize);
        int zCount = Mathf.RoundToInt(position.z / zSize);

        Vector3 result = new Vector3(
            (float)xCount * xSize,
            0,
            (float)zCount * zSize);
        
        result = transform.rotation * result;
        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (xSize <= 0 || zSize <= 0 || xRender < 0 || zRender < 0) return;

        for (int x = -xRender; x <= xRender; x += 1)
        {
            for (int z = -zRender; z <= zRender; z += 1)
            {
                var point = GetNearestPointOnGrid(new Vector3(x * xSize + transform.position.x, transform.position.y, z * zSize + transform.position.z));
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