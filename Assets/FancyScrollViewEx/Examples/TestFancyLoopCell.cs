using UnityEngine;
using UnityEngine.UI;

namespace FancyScrollViewEx
{
    public class TestFancyLoopCell : CommonScrollViewCell
    {
        [SerializeField]
        public Text message;
        [SerializeField]
        public Image image;
        [SerializeField]
        public Button button;

        protected override void Start()
        {
            base.Start();
            
            button.onClick.AddListener(OnPressedCell);
        }
        
        public override void UpdateContent(CommonCellData itemData)
        {
            var data = (TestCellData) itemData;
            message.text = data.Message + " Index : "+ data.index;

            if (context != null)
            {
                var isSelected = context.SelectedIndex == DataIndex;
                image.color = isSelected
                    ? new Color32(0, 255, 255, 100)
                    : new Color32(255, 255, 255, 77);
            }
        }
    }
}