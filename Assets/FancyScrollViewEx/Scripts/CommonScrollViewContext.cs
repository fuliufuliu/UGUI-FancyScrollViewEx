using System;
using FancyScrollView;

namespace FancyScrollViewEx
{
    public class CommonScrollViewContext
    {
        int selectedIndex = -1;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                var prevSelectedIndex = selectedIndex;
                selectedIndex = value;
                if (prevSelectedIndex != selectedIndex)
                {
                    if (OnSelectedIndexChanged != null)
                    {
                        OnSelectedIndexChanged(selectedIndex);
                    }
                }
            }
        }

        public Action<CommonScrollViewCell> OnPressedCell;
        public Action<int> OnSelectedIndexChanged;
    }
}