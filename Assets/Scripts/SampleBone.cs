using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SampleBone : MonoBehaviour
{
    public string sceneToLoad; // 이동할 씬의 이름

    void OnMouseDown()
    {
        // 오브젝트를 클릭하면 씬을 전환합니다.
        SceneManager.LoadScene(sceneToLoad);
    }
}
