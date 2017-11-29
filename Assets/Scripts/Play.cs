using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 플레이 관리
public class Play : MonoBehaviour {

    public int grid_size_x = 11;
    public int grid_size_y = 11;
    public float padding_x = 0.2f;
    public float padding_y = 0.2f;

    public Vector2 init_circle_pos = new Vector2(-2, -2);
    public List<GameObject> circle_prefab_list;

    // 모든 원들을 관리하는 게임오브젝트 배열
    GameObject[,] circles = new GameObject[11, 11];

    // Use this for initialization
    void Start () {
        StartCoroutine(CreateDots());
	}

    IEnumerator CreateDots(){
        Vector2 curr_pos = init_circle_pos;
        for(int y = 0; y < grid_size_y; ++y){
            for(int x = 0; x < grid_size_x; ++x){
                circles[y, x] = Instantiate(circle_prefab_list[UnityEngine.Random.Range(0, circle_prefab_list.Count)], curr_pos, Quaternion.identity);
                StartCoroutine(Bounce(circles[y, x].transform));
                yield return new WaitForSeconds(0.02f);
                curr_pos += new Vector2(padding_x, 0);
            }
            curr_pos = new Vector2(init_circle_pos.x, curr_pos.y + padding_y);
        }
    }
    
    IEnumerator Bounce(Transform tr){
        Vector2 origin_pos = tr.position;
        for(float t = 0.0f; t < 0.2f; t += 0.01f){
            tr.position = new Vector2(origin_pos.x, origin_pos.y - 20f * t * (t - 0.2f));
            yield return new WaitForSeconds(0.01f);
        }
        for(float t = 0.0f; t < 0.2f; t += 0.01f){
            tr.position = new Vector2(origin_pos.x, origin_pos.y - 10.0f * t * (t - 0.2f));
            yield return new WaitForSeconds(0.01f);
        }
        tr.position = origin_pos;
        yield return null;
        
    }
}
