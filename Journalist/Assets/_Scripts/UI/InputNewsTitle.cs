using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;


public class InputNewsTitle : MonoBehaviour
{

    public TextMesh NewsTitle;

    private void Awake()
    {
        GetList();
    }
    public void GetList()
    {
        List<string> list = new List<string>();

        list.Add("제스자유단이 유튜브 1위를 1달동안 유지하고 있음.");
        list.Add("신나리셔스의 유튜브 행보가 조작으로 밝혀짐.");
        list.Add("새우연합국의 새우 구출 작전 실패. 옆나라 꽃게국은 전원 생환 성공.");
        list.Add("꽃게연합정부가 언론에 꽃게구출작전을 공개하지 않음.");
        list.Add("층간 소음 측정 시 실제로 들리는 소음과 기계가 측정하는 소음의 크기가 다르다고 밝혀짐.");
        list.Add("층간 소음 문제로 윗집 이웃을 칼로 찔러 죽인 사건이 발생.");
        list.Add("학생 1명에게 들어가는 사교육비가 연 평균 5000만원으로 집계.");
        list.Add("가자미 심판의 넙치 편파판정이 또 다시 거론. 몸에 맞은 공이었지만 스트라이크 처리.");
        list.Add("아프리카 초원 한 쪽에서 동물들이 집단 만취 상태로 발견되었음.");
        list.Add("의회 소속 \"말\"의원이 사슴뿔을 달고 동네에서 난동을 부려 경찰에 연행. 노루야캐요를 계속 외쳤다고 함.");
        list.Add("식물 \"모\"를 재배하는 농장주 K씨가 경찰에 긴급 체포됨. 씨앗에서 마약성 물질이 발견되었다고 함.");
        list.Add("\"김\"의원이 대형 마트 주 2일 영업 금지 법안을 발의함. 지역시장 활성화를 위해 대형마트가 파이를 나눠야한다고 주장함.");
        list.Add("\"감\" 비서실장이 사원을 사무실로 불러 야근을 제안한 것으로 밝혀짐. 사원은 단 둘이 있었기에 거부할 수 없었다고 함.");
        list.Add("미국에서 \"톰\"씨가 기르던 개가 사람에게 총을 쏨.");

        StringBuilder stringBuilder = new StringBuilder();
        foreach (var str in list)
        {
            stringBuilder.Append(str).Append("\n");
        }

        NewsTitle.text = stringBuilder.ToString();
    }
    
    private void Update()
    {
    }
}
