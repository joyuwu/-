using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class doorControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] x = GameObject.FindGameObjectsWithTag("Enemy");
        // 如果陣列長度為0 （陣列內沒東西）
        if (x.Length == 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);



        }

    }
}
