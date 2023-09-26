using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 이동할 씬의 이름을 Inspector에서 설정할 수 있도록 public 변수를 사용합니다.
    public string sceneToLoad;

    // 버튼을 클릭했을 때 호출될 메서드를 정의합니다.
    public void LoadSceneOnClick()
    {
        Debug.Log("dddd");
        // sceneToLoad 변수에 설정된 씬으로 이동합니다.
        SceneManager.LoadScene(sceneToLoad);
        Debug.Log("ㅅㅣㄹ;");
    }
}
