using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    [SerializeField] private GameObject targetsPile;
    [SerializeField] private float minX, maxX;
    [SerializeField] private float minY, maxY;

    public void Spawn()
    {
        for(int i = 0; i < targetsPile.transform.childCount; i++)
        {
            if(!targetsPile.transform.GetChild(i).gameObject.activeSelf)
            {
                targetsPile.transform.GetChild(i).transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                targetsPile.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
    }
}
