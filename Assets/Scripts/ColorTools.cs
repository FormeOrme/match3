using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorTools {

    private static float distance (Color v1, Color v2) {
        return Mathf.Sqrt (Mathf.Pow (v1.r - v2.r, 2.0f) + Mathf.Pow (v1.g - v2.g, 2.0f) + Mathf.Pow (v1.b - v2.b, 2.0f));
    }

    public static List<Color> colors (int n) {
        List<Color> colors = new List<Color> ();
        int iter = 0;
        float dist = Mathf.InverseLerp (0, 255, 90);

        do {
            bool valid = true;
            Color tmp = new Color (
                Mathf.InverseLerp (0, 255, Random.Range (100, 200)),
                Mathf.InverseLerp (0, 255, Random.Range (10, 150)),
                Mathf.InverseLerp (0, 255, Random.Range (10, 150)),
                1
            );
            foreach (Color c in colors) {
                if (distance (tmp, c) < dist) {
                    valid = false;
                }
            }
            if (valid || iter > 1000) {
                colors.Add (tmp);
            }
            iter++;

        } while (colors.Count < n);

        // Debug.Log( "Iter count: " + iter );

        return colors;
    }

}