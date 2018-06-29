using System;
using System.Collections.Generic;
using FancyScrollView;
using UnityEngine;

namespace FancyScrollViewEx
{
    [RequireComponent(typeof(ScrollPositionController))]
    public class CommonFancyScrollView: FancyScrollView<CommonCellData, CommonScrollViewContext>
    {
        ScrollPositionController scrollPositionController;
        [SerializeField]
        public float scrollToDuration = 0.4f;


        void Awake()
        {
            scrollPositionController = GetComponent<ScrollPositionController>();
            scrollPositionController.OnUpdatePosition(UpdatePosition);
            scrollPositionController.OnItemSelected(HandleItemSelected);
            if (!cellContainer)
            {
                cellContainer = transform;
            }
        }

        public CommonScrollViewContext UpdateData(List<CommonCellData> data, Action<int> HandleSelectedIndexChanged = null)
        {
            return UpdateData(data, 0, HandleSelectedIndexChanged);
        }
        
        public CommonScrollViewContext UpdateData(List<CommonCellData> data, int SelectedIndex = 0, Action<int> HandleSelectedIndexChanged = null)
        {
            context = new CommonScrollViewContext();
            context.OnSelectedIndexChanged = HandleSelectedIndexChanged;
            context.SelectedIndex = SelectedIndex;
            
            SetContext(context);
            context.OnPressedCell = OnPressedCell;

            cellData = data;
            scrollPositionController.SetDataCount(cellData.Count);
            UpdateContents();
            UpdateSelection(context.SelectedIndex);
            return context;
        }

        public void UpdateSelection(int selectedCellIndex)
        {
            scrollPositionController.ScrollTo(selectedCellIndex, scrollToDuration);
            context.SelectedIndex = selectedCellIndex;
            UpdateContents();
        }

        void HandleItemSelected(int selectedItemIndex)
        {
            context.SelectedIndex = selectedItemIndex;
            UpdateContents();
        }

        void OnPressedCell(CommonScrollViewCell cell)
        {
            UpdateSelection(cell.DataIndex);
        }
    }
}