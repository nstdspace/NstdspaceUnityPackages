using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Nstdspace.Commons
{
    public static class GameObjectUtils
    {
        public static void SortSiblings<T>(List<T> siblings, Comparison<T> comparator) where T : MonoBehaviour
        {
            Dictionary<int, T> indicesToSiblings =
                siblings.ToDictionary(sibling => sibling.transform.GetSiblingIndex());
            List<int> indices = indicesToSiblings.Keys.ToList();
            indices.Sort((index1, index2) =>
                comparator(indicesToSiblings[index1], indicesToSiblings[index2])
            );
            for (int i = 0; i < indices.Count; i++)
            {
                int siblingIndex = indices[i];
                indicesToSiblings[siblingIndex].transform.SetSiblingIndex(i);
            }
        }
    }
}