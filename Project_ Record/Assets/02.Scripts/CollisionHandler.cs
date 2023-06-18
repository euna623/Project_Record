using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
	public Material collidedMaterial; // 충돌 시 적용할 메테리얼
	public Transform mainCameraTransform; // 메인 씬의 카메라 포지션
	public float cameraMoveDuration = 1.5f; // 카메라 이동 시간
	public float targetCameraY = 7.53f; // 목표 카메라 Y 위치

	private bool startCollided = false;
	private bool exitCollided = false;
	private Material originalMaterial; // 원래의 메테리얼

	private Coroutine cameraMoveCoroutine; // 카메라 이동 코루틴

	public AudioSource sf;

	private int score = 0;

	private void Start()
	{
		// 오브젝트의 원래 메테리얼 저장
		originalMaterial = GetComponent<Renderer>().material;

		// 메인 씬의 카메라 찾기
		GameObject mainCamera = GameObject.Find("MainCamera");
		if (mainCamera != null)
			mainCameraTransform = mainCamera.transform;
	}

	private void Update()
	{
		// Space 키를 눌렀을 때 씬 전환
		if (startCollided && Input.GetKeyDown(KeyCode.Space))
		{
			sf.Play();
			PlayerPrefs.SetInt("Score", score);
			score = 0;
			PlayerPrefs.Save();
			// 카메라 이동 코루틴 시작
			//cameraMoveCoroutine = StartCoroutine(MoveCameraToTarget());
			SceneManager.LoadScene("Choice");
		}
		else if (exitCollided && Input.GetKeyDown(KeyCode.Space))
		{
			sf.Play();
			Debug.Log("나가기");
			Application.Quit();
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Start"))
		{
			Debug.Log("스타트 충돌");
			startCollided = true;
			exitCollided = false;

			// 충돌 시 메테리얼 변경
			GetComponent<Renderer>().material = collidedMaterial;
		}
		else if (collider.gameObject.CompareTag("Exit"))
		{
			Debug.Log("엑시트 충돌");
			exitCollided = true;
			startCollided = false;

			// 충돌 시 메테리얼 변경
			GetComponent<Renderer>().material = collidedMaterial;
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.CompareTag("Start") || collider.gameObject.CompareTag("Exit"))
		{
			// 충돌 해제 시 원래의 메테리얼로 복구
			GetComponent<Renderer>().material = originalMaterial;
		}
	}

	private IEnumerator MoveCameraToTarget()
	{
		Vector3 startPosition = mainCameraTransform.position;
		Vector3 targetPosition = new Vector3(0, targetCameraY, startPosition.z);
		float elapsedTime = 0f;

		while (elapsedTime < cameraMoveDuration)
		{
			float t = elapsedTime / cameraMoveDuration;
			mainCameraTransform.position = Vector3.Lerp(startPosition, targetPosition, t);

			elapsedTime += Time.deltaTime;
			yield return null;
		}

		// 최종 위치 설정
		mainCameraTransform.position = targetPosition;

		// 카메라 이동이 완료되면 씬으로 전환
		SceneManager.LoadScene("Choice");
	}
}