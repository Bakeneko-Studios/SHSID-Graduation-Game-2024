using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwaySurferGameManager : MonoBehaviour
{
    public float[] LanePosition;
    public List<GameObject> Pieces = new List<GameObject>();
    private float laneDistance = 3;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPieces();
    }

    public void SpawnPieces()
    {
        for(int a=0;a <= (120/laneDistance);a++) {
            for (int i=0; i < LanePosition.Length;i++) {
                int rand = Random.Range(0,10);
                if (rand < Pieces.Count) {
                    Instantiate(Pieces[rand], new Vector3(LanePosition[i],0f,a*2),Quaternion.identity);
                }
            }
        }
    }
}
