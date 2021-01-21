using UnityEngine;

public class CoralPlacer : MonoBehaviour
{
    private GridTweaked grid;
    private PauseMenuScript p;

    private void Awake()
    {
        grid = FindObjectOfType<GridTweaked>();
        p = FindObjectOfType<PauseMenuScript>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !p.GameIsPaused)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
            }
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = finalPosition;
    }
}