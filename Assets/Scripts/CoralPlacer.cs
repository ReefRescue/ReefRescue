using UnityEngine;

public class CoralPlacer : MonoBehaviour
{
    private GridTweaked grid;
    private PauseMenuScript p;

    [SerializeField]
    private Sprite[] sprites;

    private void Awake()
    {
        grid = FindObjectOfType<GridTweaked>();
        p = FindObjectOfType<PauseMenuScript>();
    }

    private void Start()
    {
        //sprites
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !p.GameIsPaused)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                PlaceCoralNear(hitInfo.point);
            }
        }
    }

    private void PlaceCoralNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        GameObject coral = new GameObject("GenCoral", typeof(SpriteRenderer));
        coral.transform.position = finalPosition;
        coral.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);

        SpriteRenderer sprite = coral.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 1;
        sprite.sprite = sprites[Random.Range(0, 4)];
    }
}