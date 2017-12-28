using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPrescriptionInterfaceProgramBate001.Models.CommonData
{
    public class TranslationClass
    {
        public Dictionary<string, string> ChineseToKoreanDic;
        //public Dictionary<string, string> KoreanToChineseDic;
        public TranslationClass()
        {
            ChineseToKoreanDic = new Dictionary<string,string>();
            ChineseToKoreanDic.Add("医生姓名","의사 이름");
            ChineseToKoreanDic.Add("所属部门","소속");
            ChineseToKoreanDic.Add("患者情报", "환자 정보");
            ChineseToKoreanDic.Add("患者姓名", "환자 이름");
            ChineseToKoreanDic.Add("患者 ID", "환자 ID");
            ChineseToKoreanDic.Add("性别", "성별");
            ChineseToKoreanDic.Add("年龄", "나이");
            ChineseToKoreanDic.Add("诊断结果", "진단 결과");
            ChineseToKoreanDic.Add("处方药信息", "약품");
            ChineseToKoreanDic.Add("处方药名称", "약품 명칭");
            ChineseToKoreanDic.Add("用法", "용법");
            ChineseToKoreanDic.Add("需服用天数", "총 투약일수");
            ChineseToKoreanDic.Add("一日服用次数", "1일 투약횟수");
            ChineseToKoreanDic.Add("早上", "아침");
            ChineseToKoreanDic.Add("中午", "점심");
            ChineseToKoreanDic.Add("晚上", "저녁");
            ChineseToKoreanDic.Add("一次服用剂量", "1회 투약 량");
            ChineseToKoreanDic.Add("使用说明及注意事项", "설명");
            ChineseToKoreanDic.Add("修改", "수정");
            ChineseToKoreanDic.Add("删除", "삭제");
            ChineseToKoreanDic.Add("一次服用剂量（数值）", "1회 투약 량(숫짜)");
            ChineseToKoreanDic.Add("一次服用剂量（单位）", "1회 투약 량(단위)");
            ChineseToKoreanDic.Add("增加", "증가");
            ChineseToKoreanDic.Add("下一位患者", "다음");
            ChineseToKoreanDic.Add("保存", "저장");
            ChineseToKoreanDic.Add("历史", "역사");
        }
    }
}
