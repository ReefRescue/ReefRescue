using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRocks : MonoBehaviour
{
    [SerializeField]
    private GridTweaked rockGrid;

    [SerializeField]
    private Sprite[] rocks;

    [SerializeField]
    private float emptySpaceChance = 0.5f;

    [SerializeField]
    private Vector2Int gridCorner1 = new Vector2Int(-3, -3);

    [SerializeField]
    private Vector2Int gridCorner2 = new Vector2Int(3, 3);

    // Defaults to a 7x7 square centered

    void Start()
    {
        for (int i = Mathf.Min(gridCorner1.x, gridCorner2.x); i <= Mathf.Max(gridCorner1.x, gridCorner2.x); i++)
        {
            for (int j = Mathf.Min(gridCorner1.y, gridCorner2.y); j <= Mathf.Max(gridCorner1.y, gridCorner2.y); j++)
            {
                if (Random.Range(0f, 1f) >= emptySpaceChance) // Place rock here if not empty space
                {
                    GameObject rock = new GameObject("GenRock", typeof(SpriteRenderer));
                    rock.transform.position = rockGrid.GetNearestPointOnGridRelative(new Vector3(i * rockGrid.size.x, 0, j * rockGrid.size.y));
                    rock.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);

                    SpriteRenderer renderer = rock.GetComponent<SpriteRenderer>();
                    //renderer.sortingOrder = 1;
                    renderer.sprite = rocks[Random.Range(0, rocks.Length)];

                    Debug.Log("placing rock");
                }
            }
        }
    }
}
