using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelection : MonoBehaviour
{
    [SerializeField]
    private string[] stageButtonNames; // �ν����� â���� ������ �������� ��ư �ؽ�Ʈ �迭

    public Button stageButtonPrefab; // �������� ��ư ������
    public Transform buttonContainer; // ��ư���� ���� �����̳�
    public float scrollSpeed = 200f; // ��ũ�� �ӵ�
    public float selectedScaleMultiplier = 1.2f; // ���õ� ���������� ũ�� ����
    public AudioSource musicSource; // ��� ���� ����� AudioSource

    private List<Button> stageButtons; // ������ �������� ��ư��
    private int currentStageIndex = -1; // ���� ���õ� �������� �ε��� (-1�� �ʱ�ȭ)
    private Vector2 buttonSize; // �������� ��ư�� �⺻ ũ��
    private bool isScrolling; // ��ũ�� ���� ����

    private void Start()
    {
        stageButtons = new List<Button>();

        // �������� ��ư ����
        for (int i = 0; i < StageManager.Instance.StageCount; i++)
        {
            int index = i; // ���ο� ������ �ε��� ���� �Ҵ�

            Button button = Instantiate(stageButtonPrefab, buttonContainer);
            button.GetComponentInChildren<Text>().text = (i < stageButtonNames.Length) ? stageButtonNames[i] : "Stage " + (i + 1);
            button.onClick.AddListener(() => SelectStage(index)); // ���ο� ������ ����
            stageButtons.Add(button);

            // ��ư ��ġ ����
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(-20, -130 * i);
        }

        // �ʱ� �������� ��ư ũ�� ����
        buttonSize = stageButtons[0].transform.localScale;
    }

    private void Update()
    {
        // ��ũ�� ���� ����
        if (isScrolling)
        {
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
            buttonContainer.transform.Translate(Vector2.up * scrollDelta * scrollSpeed * Time.deltaTime);
        }
    }

    public void StartScrolling()
    {
        isScrolling = true;
    }

    public void StopScrolling()
    {
        isScrolling = false;
    }

    private void SelectStage(int index)
    {
        // ���� ���õ� �������� ��ư ũ�� �ʱ�ȭ
        if (currentStageIndex != -1)
        {
            stageButtons[currentStageIndex].transform.localScale = buttonSize;
        }

        // ���õ� �������� ��ư ũ�� ����
        Button selectedButton = stageButtons[index];
        selectedButton.transform.localScale = buttonSize * selectedScaleMultiplier;

        // ���õ� �������� ������� ���
        musicSource.clip = StageManager.Instance.GetStageBackgroundMusic(index);
        musicSource.Play();

        // ���� ���������� ������ �������� �ε��� ��
        if (currentStageIndex != index)
        {
            // ��ư�� Ŭ���Ͽ� �ٸ� ���������� ������ ���
            currentStageIndex = index;
        }
        else
        {
            // ��ư�� �̹� ���õ� ���¿��� Ŭ���� ��� �ش� ���������� �̵�
            switch (index)
            {
                case 0:
                    // Stage1 ������ �̵�
                    SceneManager.LoadScene("Stage1");
                    break;
                case 1:
                    // Stage2 ������ �̵�
                    SceneManager.LoadScene("Stage2");
                    break;
                case 2:
                    // Stage3 ������ �̵�
                    SceneManager.LoadScene("Stage3");
                    break;
                    // �ʿ��� �ٸ� �������� �������� �̵� �߰�
            }
        }
    }
}
