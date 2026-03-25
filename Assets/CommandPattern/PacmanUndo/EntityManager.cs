using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] 
    private List<Entity> Entities;
    private int currentIndex;

    // Expression-bodied members, C# syntactic convenience
    public Entity ActiveEntity => Entities[currentIndex];

    public void SetNextEntity()
    {
        currentIndex++;
        //currentIndex = currentIndex % Entities.Count; // Only two entities in the example
        if (currentIndex >= Entities.Count) currentIndex = 0;
    }
}
