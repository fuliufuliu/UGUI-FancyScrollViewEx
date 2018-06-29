using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace FancyScrollViewEx
{
    /// <summary>
    /// 管理ScrollView的界面类,业务层
    /// </summary>
    public class TestFancyLoopView : MonoBehaviour
    {
        [SerializeField]
        CommonFancyScrollView scrollView;
        [SerializeField]
        Button prevCellButton;
        [SerializeField]
        Button nextCellButton;
        [SerializeField]
        Text selectedItemInfo;
        
        [SerializeField]
        Button AButton;
        [SerializeField]
        Button BButton;

        public int selectedIndex = 0;

        List<CommonCellData> cellData;
        CommonScrollViewContext context;

        void Awake()
        {
            prevCellButton.onClick.AddListener(HandlePrevButton);
            nextCellButton.onClick.AddListener(HandleNextButton);
            AButton.onClick.AddListener(HandleAButton);
            BButton.onClick.AddListener(HandleBButton);
        }

        private void HandleAButton()
        {
            SelectCell(5);
        }
        
        private void HandleBButton()
        {
            SelectCell(12);
        }

        void Start()
        {
            // 填入数据
            cellData = Enumerable.Range(0, 20)
                .Select(i => (CommonCellData) new TestCellData() { Message = "Cell " + i , index = i})
                .ToList();


            context = scrollView.UpdateData(cellData, selectedIndex, HandleSelectedIndexChanged);
        }
        
        void HandlePrevButton()
        {
            SelectCell(context.SelectedIndex - 1);
        }

        void HandleNextButton()
        {
            SelectCell(context.SelectedIndex + 1);
        }

        void SelectCell(int index)
        {
            if (index >= 0 && index < cellData.Count)
            {
                scrollView.UpdateSelection(index);
            }
        }

        void HandleSelectedIndexChanged(int index)
        {
            selectedItemInfo.text = String.Format("Selected item info: index {0}", index);
        }

    }
}