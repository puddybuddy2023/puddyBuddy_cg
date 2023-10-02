using UnityEngine;

public class MapCameraController : MonoBehaviour
{
    private Vector3 dragOrigin;
    private float panSpeed = 1.0f;
    private float zoomSpeed = 5.0f;
    private float minZoom = 30.0f; // 최소 줌 레벨
    private float maxZoom = 60.0f; // 최대 줌 레벨

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // 마우스 입력 처리 (에디터 및 스탠드얼론 플랫폼에서)
        HandleMouseInput();
#else
        // 모바일 터치 입력 처리 (모바일 플랫폼에서)
        HandleTouchInput();
#endif
    }

    // 마우스 입력 처리
    private void HandleMouseInput()
    {
        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
        }

        // 드래그 감지
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - dragOrigin;

            // 화면 이동
            Vector3 newPos = transform.position - new Vector3(delta.x * panSpeed, 0, delta.y * panSpeed);
            transform.position = newPos;

            // 드래그 시작 지점 업데이트
            dragOrigin = Input.mousePosition;
        }

        // 마우스 스크롤로 줌 인/아웃
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView += scroll * zoomSpeed;

        // 줌 값 제한
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minZoom, maxZoom);
    }

    // 모바일 터치 입력 처리
    private void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    dragOrigin = new Vector3(touch.position.x, 0, touch.position.y); // Vector2를 Vector3로 변환
                    break;

                case TouchPhase.Moved:
                    Vector3 delta = new Vector3(touch.position.x, 0, touch.position.y) - dragOrigin;

                    // 화면 이동
                    Vector3 newPos = transform.position - new Vector3(delta.x * panSpeed, 0, delta.y * panSpeed);
                    transform.position = newPos;

                    // 드래그 시작 지점 업데이트
                    dragOrigin = new Vector3(touch.position.x, 0, touch.position.y);
                    break;
            }
        }
    }

}
