using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOrchestratorData : MonoBehaviour {

    public int side;
    public float padding;
    //public int[][] grid;

    public GameObject baseTile;
    public List<GameObject> tiles;

    // Start is called before the first frame update
    void Start () {
        tiles = new List<GameObject> ();
        for (int y = 0; y < side; y++) {
            for (int x = 0; x < side; x++) {
                GameObject tile = Instantiate (baseTile, new Vector3 (0, 0, 0), Quaternion.identity);
                TileData props = tile.GetComponent<TileData> ();
                props.data = this;
                props.x = x;
                props.y = y;
                props.yF = 3;
                tiles.Add (tile);
            }
        }
    }

    // Update is called once per frame
    void Update () {

    }

    public float EOB (float x) {
        float n1 = 7.5625f;
        float d1 = 2.75f;

        if (x < 1.0f / d1) {
            return n1 * x * x;
        } else if (x < 2.0f / d1) {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        } else if (x < 2.5f / d1) {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        } else {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }

    public float EP (float x, float p) {
        return Mathf.Pow (x, p);
    }

}