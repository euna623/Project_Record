using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
	public Material collidedMaterial; // �浹 �� ������ ���׸���
	public Transform mainCameraTransform; // ���� ���� ī�޶� ������
	public float cameraMoveDuration = 1.5f; // ī�޶� �̵� �ð�
	public float targetCameraY = 7.53f; // ��ǥ ī�޶� Y ��ġ

	private bool startCollided = false;
	private bool exitCollided = false;
	private Material originalMaterial; // ������ ���׸���

	private Coroutine cameraMoveCoroutine; // ī�޶� �̵� �ڷ�ƾ

	public AudioSource sf;

	private int score = 0;

	private void Start()
	{
		// ������Ʈ�� ���� ���׸��� ����
		originalMaterial = GetComponent<Renderer>().material;

		// ���� ���� ī�޶� ã��
		GameObject mainCamera = GameObject.Find("MainCamera");
		if (mainCamera != null)
			mainCameraTransform = mainCamera.transform;
	}

	private void Update()
	{
		// Space Ű�� ������ �� �� ��ȯ
		if (startCollided && Input.GetKeyDown(KeyCode.Space))
		{
			sf.Play();
			PlayerPrefs.SetInt("Score", score);
			score = 0;
			PlayerPrefs.Save();
			// ī�޶� �̵� �ڷ�ƾ ����
			//cameraMoveCoroutine = StartCoroutine(MoveCameraToTarget());
			SceneManager.LoadScene("Choice");
		}
		else if (exitCollided && Input.GetKeyDown(KeyCode.Space))
		{
			sf.Play();
			Debug.Log("������");
			Application.Quit();
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Start"))
		{
			Debug.Log("��ŸƮ �浹");
			startCollided = true;
			exitCollided = false;

			// �浹 �� ���׸��� ����
			GetComponent<Renderer>().material = collidedMaterial;
		}
		else if (collider.gameObject.CompareTag("Exit"))
		{
			Debug.Log("����Ʈ �浹");
			exitCollided = true;
			startCollided = false;

			// �浹 �� ���׸��� ����
			GetComponent<Renderer>().material = collidedMaterial;
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.CompareTag("Start") || collider.gameObject.CompareTag("Exit"))
		{
			// �浹 ���� �� ������ ���׸���� ����
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

		// ���� ��ġ ����
		mainCameraTransform.position = targetPosition;

		// ī�޶� �̵��� �Ϸ�Ǹ� ������ ��ȯ
		SceneManager.LoadScene("Choice");
	}
}