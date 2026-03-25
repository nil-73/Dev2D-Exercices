using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    private GameObject[] pool;

    public GameObject Prefab;
    public int Capacity = 20;

    private int counter = 0; // Objects currently active

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pool = new GameObject[Capacity];

        for (int i = 0; i < Capacity; i++)
        {
            AddNewObjectToPool();
            counter++;
        }
    }

    private void AddNewObjectToPool()
    {
        GameObject obj = Instantiate(Prefab);
        obj.name = "Bullet [" + counter.ToString("000") + "]";
        obj.SetActive(false);

        pool[counter] = obj;
    }

    public static GameObject GetObject()
    {
        GameObject ret = null;

        for (int i = 0; i < Instance.Capacity; i++)
        {
            if (Instance.pool[i].activeInHierarchy == false)
            {
                Instance.pool[i].SetActive(true);
                ret = Instance.pool[i];
                break;
            }
        }

        return ret;
    }

    public static void BackToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
