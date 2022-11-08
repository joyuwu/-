using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10;
    public Joystick joystick;
    public Transform firepoint;
    public GameObject bulletPrefab;

    private CharacterController controller;
    private GameObject focusEnemy;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        StartCoroutine(KeepShooting());
    }

    // Update is called once per frame
    void Update()
    {





        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        float miniDist = 9999;
        foreach (GameObject enemy in enemys)
        {
            // 計算距離
            float d = Vector3.Distance(transform.position, enemy.transform.position);

            // 跟上一個最近的比較，有比較小就記錄下來
            if (d < miniDist)
            {
                miniDist = d;
                focusEnemy = enemy;
            }
        }


        float h = joystick.Horizontal;
        float v = joystick.Vertical;
        Vector3 dir = new Vector3(h, 0, v);


        if (dir.magnitude > 0.1f)
        {

            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
        else
        {
            if (focusEnemy)
            {
                Quaternion targetRotation = Quaternion.LookRotation(focusEnemy.transform.position - transform.position);
                targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
            }
        }

        if (!controller.isGrounded)
        {
            dir.y = -9.8f * 30 * Time.deltaTime;
        }

        controller.Move(dir * speed * Time.deltaTime);
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firepoint.transform.position, transform.rotation);
    }

    IEnumerator KeepShooting()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(0.5f);
        }
    }

}
