using UnityEngine;

public class GridTweaked : MonoBehaviour
{
    [SerializeField]
    private float xSize = 1f;

    [SerializeField]
    private float zSize = 1f;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / xSize);
        int zCount = Mathf.RoundToInt(position.z / zSize);

        Vector3 result = new Vector3(
            (float)xCount * xSize,
            0,
            (float)zCount * zSize);

        result += transform.position;
        result = transform.rotation * result;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = -20; x < 20; x += xSize)
        {
            for (float z = -20; z < 20; z += zSize)
            {
                var point = GetNearestPointOnGrid(new Vector3(x + transform.position.x, transform.position.y, z + transform.position.z));
                if (x == 0 && z == 0)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawSphere(point, 0.1f);
                    Gizmos.color = Color.yellow;
                } else Gizmos.DrawSphere(point, 0.1f);
            }
                
        }
    }
}