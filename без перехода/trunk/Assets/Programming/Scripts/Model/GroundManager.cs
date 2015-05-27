using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour
{
    public Vector2 StartPoint;
    public string HorizontalTag;
    public string VercticalUpTag;
    public string VerticalDownTag;
    public GameObject[] GroundPrefabs;

 //   GameObject[] _groundParts;
    void Start()
    {
    }

    void Update()
    {
    }
    public void RecalculateGround()
    {
        var groundParts = new GameObject[GroundPrefabs.Length];
        var oldParts = gameObject.GetComponentsInChildren<BoxCollider2D>();
        foreach (var part in oldParts) DestroyImmediate(part.gameObject);

        var delta = Vector2.zero;

        for (var i = 0; i < GroundPrefabs.Length; i++)
        {

                groundParts[i] = (GameObject)Instantiate(GroundPrefabs[i]);

            groundParts[i].transform.SetParent(transform);
            groundParts[i].transform.localScale = Vector3.one;
            var ColliderSize = groundParts[i].GetComponent<BoxCollider2D>().size;
            
            if (groundParts[i].tag == HorizontalTag) 
            {
                groundParts[i].transform.localPosition = StartPoint + delta + new Vector2(ColliderSize.x / 2f, -ColliderSize.y / 2f);
                delta += new Vector2(ColliderSize.x, 0f);
            }
            else
            {
                if (groundParts[i].tag == VercticalUpTag)
                {
                    groundParts[i].transform.localPosition = StartPoint + delta + new Vector2(ColliderSize.x / 2f, ColliderSize.y / 2f);
                    delta += new Vector2(0f, ColliderSize.y);
                }
                else
                {
                    groundParts[i].transform.localPosition = StartPoint + delta + new Vector2(ColliderSize.x / 2f, -ColliderSize.y / 2f);
                    delta += new Vector2(0f, -ColliderSize.y);
                }
            }
        }
//        _groundParts = groundParts;
    }
}
