using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOrchestratorData : MonoBehaviour {

    public int side;
    public int L;
    public int startingY;
    public float padding;
    public int[, ] grid;
    public List<Color> colors;

    public GameObject baseTile;
    public List<GameObject> tiles;

    // Start is called before the first frame update
    void Start () {
        colors = ColorTools.colors (4);

        grid = new int[side, side];

        tiles = new List<GameObject> ();
        for (int y = 0; y < side; y++) {
            for (int x = 0; x < side; x++) {
                grid[x, y] = (int) Random.Range (0, 4);
                GameObject tile = Instantiate (baseTile, new Vector3 (0, 0, 0), Quaternion.identity);
                TileData props = tile.GetComponent<TileData> ();
                props.data = this;
                props.x = x;
                props.y = y;
                props.yF = startingY;
                tiles.Add (tile);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        Camera.main.transform.position = new Vector3 (3.0f, 3.0f, -10.0f);
        if (Input.GetMouseButtonDown (0)){
            colors = ColorTools.colors (4);
        }
    }

}