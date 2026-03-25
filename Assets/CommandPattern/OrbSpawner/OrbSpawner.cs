using System.Collections.Generic;
using UnityEngine;

public static class OrbSpawner
{
    static List<GameObject> Orbs; // List for created orbs

    public static void AddOrb(GameObject prefab, Vector2 position, Color color)
    {
        // NOTE: Lazy initialization of orb pool list
        if (Orbs == null) Orbs = new List<GameObject>();

        GameObject orb = GameObject.Instantiate(prefab, position, Quaternion.identity);
        orb.GetComponent<SpriteRenderer>().color = color;

        Orbs.Add(orb);
    }

    public static void RemoveOrb(GameObject prefab, Vector2 position, Color color)
    {
        for (int i = 0; i < Orbs.Count; i++)
        {
            if (AreEqual(Orbs[i], position, color))
            {
                GameObject.Destroy(Orbs[i]);
                Orbs.RemoveAt(i);
                return;
            }  
        }
    }

    private static bool AreEqual(GameObject gameObject, Vector2 position, Color color)
    {
        return (((Vector2)gameObject.transform.position == position) &&
            (gameObject.GetComponent<SpriteRenderer>().color == color));
    }
}
