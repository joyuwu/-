using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject focusPlayer;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = player.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 0.1f, 0);
        transform.rotation = Quaternion.LookRotation(newDir);

        // 找到最近的一個目標 Enemy 的物件
        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        //float miniDist = 9999;

        //foreach (GameObject player in players)
        {
            // 計算距離
            //float d = Vector3.Distance(transform.position, player.transform.position);

            // 跟上一個最近的比較，有比較小就記錄下來
            //if (d < miniDist)
            {
                //miniDist = d;
                //focusPlayer = player;
            }
        }


        //Vector3 dir = new Vector3(0, 0, 0);

        //if (dir.magnitude > 0.1f)
        {
            // 將方向向量轉為角度
            // float faceAngle = Mathf.Atan2(0, 0) * Mathf.Rad2Deg;

            // 使用 Lerp 漸漸轉向
            //Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
        //else
        {
            // 沒有移動輸入，並且有鎖定的敵人，漸漸面向敵人
            //if (focusPlayer)
            {
                //var targetRotation = Quaternion.LookRotation(focusPlayer.transform.position - transform.position);
                //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
            }
        }


    }
}
