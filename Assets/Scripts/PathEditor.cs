using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEditor : MonoBehaviour
{
    public List<Transform> transforms = new List<Transform>();
    Transform[] transformsArray;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        transformsArray = GetComponentsInChildren<Transform>();
        transforms.Clear();

        foreach(Transform path in transformsArray)
        {
            if(path != this.transform)
            {
                transforms.Add(path);
            }
        }
        for (int i = 0; i < transforms.Count; i++)
        {
            Vector2 pos = transforms[i].position;
            if(i > 0)
            {
                Vector2 prev = transforms[i - 1].position;
                Gizmos.DrawLine(prev, pos);
                Gizmos.DrawWireSphere(pos, 0.25f);
            }
        }
    }
}
