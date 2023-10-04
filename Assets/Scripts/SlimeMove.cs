using UnityEngine;
using UnityEngine.UI;


public class SlimeMove : MonoBehaviour
{
    public Transform cameraTransform; // 카메라 트랜스폼
    public float rotationSpeed = 30f; // 회전 속도
    public int maxHealth = 100; // 최대 체력
    public int currentHealth = 100; // 현재 체력

    private Vector3 initialPosition; // 슬라임 초기 위치
    private Text healthText; // 체력을 표시할 UI Text

    public GameObject complete;
    private void Start()
    {
        initialPosition = transform.position;
        healthText = GameObject.Find("HealthText").GetComponent<Text>(); // 캔버스에 있는 Text 오브젝트를 찾아 연결
        UpdateHealthText();
    }
    private void Update()
    {
        // 카메라를 항상 바라보도록 회전 설정
        Vector3 lookAtPosition = new Vector3(cameraTransform.position.x, transform.position.y, cameraTransform.position.z);
        transform.LookAt(lookAtPosition);

        // 슬라임의 원운동을 구현
        float time = Time.time;
        float angle = time * rotationSpeed;
        float radius = 9f;
        float x = cameraTransform.position.x + Mathf.Sin(angle) * radius;
        float z = cameraTransform.position.z + Mathf.Cos(angle) * radius;

        transform.position = new Vector3(x, transform.position.y, z);
    }
    private void OnMouseDown()
    {
        // 슬라임 클릭 시 체력 감소
        TakeDamage(10); // 10의 데미지를 입힘 (원하는 값으로 수정 가능)
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0; // 체력이 음수가 되지 않도록 보정

        UpdateHealthText();

        // 체력이 0 이하로 떨어졌을 때 슬라임을 제거하거나 다른 처리를 할 수 있음
        if (currentHealth <= 0)
        {
            // 슬라임을 제거하거나 비활성화
            gameObject.SetActive(false);
            complete.SetActive(true);
        }
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString(); // UI Text 업데이트
        }
    }
}
