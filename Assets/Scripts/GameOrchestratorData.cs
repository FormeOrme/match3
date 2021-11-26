using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOrchestratorData : MonoBehaviour {

    public int side;
    public int L;
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
                props.yF = 10;
                tiles.Add (tile);
            }
        }
    }

    // Update is called once per frame
    void Update () {

    }

}