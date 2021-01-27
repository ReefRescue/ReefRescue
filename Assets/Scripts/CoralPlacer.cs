using UnityEngine;
using System.Collections.Generic;

public class CoralPlacer : MonoBehaviour
{
    private GridTweaked grid;
    private PauseMenuScript p;

    [SerializeField]
    private Sprite[] sprites;

    public List<Vector3> gridObjs = new List<Vector3>();

    private int testingIndex = -1;

    private void Awake()
    {
        grid = FindObjectOfType<GridTweaked>();
        p = FindObjectOfType<PauseMenuScript>();
    }

    private void Start()
    {
        gridObjs.Clear();
    }

    private void Update()
    {
        if (!p.GameIsPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    PlaceCoralNear(testingIndex < 0 ? Random.Range(0, 4) : testingIndex, hitInfo.point);
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha1)) testingIndex = 0;
            else if (Input.GetKeyDown(KeyCode.Alpha2)) testingIndex = 1;
            else if (Input.GetKeyDown(KeyCode.Alpha3)) testingIndex = 2;
            else if (Input.GetKeyDown(KeyCode.Alpha4)) testingIndex = 3;
        }
    }

    private void PlaceCoralNear(int spriteNum, Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);

        if (gridObjs.Contains(finalPosition)) return;
        gridObjs.Add(finalPosition);

        GameObject coral = new GameObject("GenCoral", typeof(SpriteRenderer));
        coral.transform.position = finalPosition;
        coral.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);

        SpriteRenderer renderer = coral.GetComponent<SpriteRenderer>();
        renderer.sortingOrder = 1;
        renderer.sprite = sprites[spriteNum];

        CurrencySystem.balance -= 1;
    }
}