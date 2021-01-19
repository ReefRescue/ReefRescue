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
            position.y,
            (float)zCount * zSize);

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < 40; x += xSize)
        {
            for (float z = 0; z < 40; z += zSize)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }
                
        }
    }
}