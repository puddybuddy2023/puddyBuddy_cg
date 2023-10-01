using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // 회전 속도 (초당 30도로 설정)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // y축을 기준으로 회전
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

