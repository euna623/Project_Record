using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelection : MonoBehaviour
{
    [SerializeField]
    private string[] stageButtonNames; // 인스펙터 창에서 지정할 스테이지 버튼 텍스트 배열

    public Button stageButtonPrefab; // 스테이지 버튼 프리팹
    public Transform buttonContainer; // 버튼들을 담을 컨테이너
    public float scrollSpeed = 200f; // 스크롤 속도
    public float selectedScaleMultiplier = 1.2f; // 선택된 스테이지의 크기 배율
    public AudioSource musicSource; // 배경 음악 재생용 AudioSource

    private List<Button> stageButtons; // 생성된 스테이지 버튼들
    private int currentStageIndex = -1; // 현재 선택된 스테이지 인덱스 (-1로 초기화)
    private Vector2 buttonSize; // 스테이지 버튼의 기본 크기
    private bool isScrolling; // 스크롤 동작 여부

    private void Start()
    {
        stageButtons = new List<Button>();

        // 스테이지 버튼 생성
        for (int i = 0; i < StageManager.Instance.StageCount; i++)
        {
            int index = i; // 새로운 변수에 인덱스 값을 할당

            Button button = Instantiate(stageButtonPrefab, buttonContainer);
            button.GetComponentInChildren<Text>().text = (i < stageButtonNames.Length) ? stageButtonNames[i] : "Stage " + (i + 1);
            button.onClick.AddListener(() => SelectStage(index)); // 새로운 변수를 전달
            stageButtons.Add(button);

            // 버튼 위치 설정
            button.GetComponent<RectTransform>().anchoredPosition = new Vector2(-20, -130 * i);
        }

        // 초기 스테이지 버튼 크기 저장
        buttonSize = stageButtons[0].transform.localScale;
    }

    private void Update()
    {
        // 스크롤 동작 감지
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
        // 이전 선택된 스테이지 버튼 크기 초기화
        if (currentStageIndex != -1)
        {
            stageButtons[currentStageIndex].transform.localScale = buttonSize;
        }

        // 선택된 스테이지 버튼 크기 조정
        Button selectedButton = stageButtons[index];
        selectedButton.transform.localScale = buttonSize * selectedScaleMultiplier;

        // 선택된 스테이지 배경음악 재생
        musicSource.clip = StageManager.Instance.GetStageBackgroundMusic(index);
        musicSource.Play();

        // 현재 스테이지와 선택한 스테이지 인덱스 비교
        if (currentStageIndex != index)
        {
            // 버튼을 클릭하여 다른 스테이지를 선택한 경우
            currentStageIndex = index;
        }
        else
        {
            // 버튼이 이미 선택된 상태에서 클릭한 경우 해당 스테이지로 이동
            switch (index)
            {
                case 0:
                    // Stage1 씬으로 이동
                    SceneManager.LoadScene("Stage1");
                    break;
                case 1:
                    // Stage2 씬으로 이동
                    SceneManager.LoadScene("Stage2");
                    break;
                case 2:
                    // Stage3 씬으로 이동
                    SceneManager.LoadScene("Stage3");
                    break;
                    // 필요한 다른 스테이지 씬으로의 이동 추가
            }
        }
    }
}
