using UnityEngine;

public class PoolSpawner : MonoBehaviour
{
    public Gradient ColorGradient;

    public bool Spawn;
    public float SpawnTime = 1.0f;
    public float RotationSpeed = 5.0f;

    private float timer = 0.0f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, RotationSpeed * Time.deltaTime));

        if (Spawn)
        {
            timer += Time.deltaTime;

            if (timer > SpawnTime)
            {
                ActivateOneBullet();
                timer = 0.0f;
            }
        }
    }

    private void ActivateOneBullet()
    {
        GameObject bullet = PoolManager.GetObject();

        if (bullet != null )
        {
            bullet.transform.position = transform.position;
            bullet.SetActive(true);

            Color color = ColorGradient.Evaluate(transform.eulerAngles.z / 360.0f);

            bullet.GetComponent<Bullet>().Init(transform.right * 2, color);
        }
    }
}
