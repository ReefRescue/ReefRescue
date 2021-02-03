using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class CoralPlacer : MonoBehaviour
{
    [SerializeField]
    private GridTweaked grid;
    private PauseMenuScript p;

    [SerializeField]
    private Sprite[] sprites;

    private readonly List<Vector3> gridObjs = new List<Vector3>();

    private int draggingIndex = -1;
    public static bool dragging = false;
    public static GameObject hologram;
    private Vector3 previousHologramPosition;

    private void Awake()
    {
        //grid = FindObjectOfType<GridTweaked>();
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
            if (Input.GetMouseButtonDown(0) && !dragging)
            {
                Debug.Log("Mouse button down");

                PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, results);

                results.ForEach((result) =>
                {
                    Debug.Log(result);
                    if (result.gameObject != null && result.gameObject.name.Contains("Coral Panel"))
                    {
                        switch (result.gameObject.name)
                        {
                            case "Coral Panel 1":
                                if (!CurrencySystem.HasSufficientFunds(0)) break;
                                draggingIndex = 0;
                                dragging = true;
                                break;
                            case "Coral Panel 2":
                                if (!CurrencySystem.HasSufficientFunds(1)) break;
                                draggingIndex = 1;
                                dragging = true;
                                break;
                            case "Coral Panel 3":
                                if (!CurrencySystem.HasSufficientFunds(2)) break;
                                draggingIndex = 2;
                                dragging = true;
                                break;
                            case "Coral Panel 4":
                                if (!CurrencySystem.HasSufficientFunds(3)) break;
                                draggingIndex = 3;
                                dragging = true;
                                break;
                            default:
                                break;
                        }
                    }
                });
            }
            else if (Input.GetMouseButton(0) && dragging)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    Debug.Log("Placing hologram");
                    PlaceCoralNear(draggingIndex, hitInfo.point, true);
                }
                else
                {
                    Destroy(hologram);
                }
            }
            else if (Input.GetMouseButtonUp(0) && dragging)
            {
                dragging = false;
                Destroy(hologram);
                Debug.Log("End dragging");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    PlaceCoralNear(draggingIndex, hitInfo.point);
                }
            }

            //else if (Input.GetKeyDown(KeyCode.Alpha1)) testingIndex = 0;
            //else if (Input.GetKeyDown(KeyCode.Alpha2)) testingIndex = 1;
            //else if (Input.GetKeyDown(KeyCode.Alpha3)) testingIndex = 2;
            //else if (Input.GetKeyDown(KeyCode.Alpha4)) testingIndex = 3;
        }
    }

    private bool PlaceCoralNear(int spriteNum, Vector3 clickPoint, bool isHologram = false)
    {
        if (spriteNum < 0 || spriteNum >= sprites.Length) return false;

        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);

        if (gridObjs.Contains(finalPosition)) return false;

        if (!isHologram)
        {
            gridObjs.Add(finalPosition);

            GameObject coral = new GameObject("GenCoral", typeof(SpriteRenderer));
            coral.transform.position = finalPosition;
            coral.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);

            SpriteRenderer renderer = coral.GetComponent<SpriteRenderer>();
            renderer.sortingOrder = 1;
            renderer.sprite = sprites[spriteNum];

            CurrencySystem.ChangeBalance(-CurrencySystem.coralCosts[spriteNum]);

            Debug.Log(DayNightCycle.deltaCurrency);
            Debug.Log(CurrencySystem.coralIncome[spriteNum]);
            DayNightCycle.deltaCurrency += CurrencySystem.coralIncome[spriteNum];
        }
        else
        {
            if (previousHologramPosition == finalPosition) return false;

            Destroy(hologram); // Remove old hologram
            hologram = new GameObject("GenHologram", typeof(SpriteRenderer));
            hologram.transform.position = finalPosition;
            hologram.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);

            SpriteRenderer renderer = hologram.GetComponent<SpriteRenderer>();
            renderer.sortingOrder = 1;
            renderer.sprite = sprites[spriteNum];
            renderer.color = new Color(1, 1, 0);
        }

        return true;
    }
}