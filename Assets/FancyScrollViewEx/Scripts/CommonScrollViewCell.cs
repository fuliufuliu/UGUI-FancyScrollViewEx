using FancyScrollView;
using UnityEngine;
using UnityEngine.UI;

namespace FancyScrollViewEx
{
    public class CommonScrollViewCell : FancyScrollViewCell<CommonCellData, CommonScrollViewContext>
    {
        [SerializeField]
        public Animator animator;


        static readonly int scrollTriggerHash = Animator.StringToHash("scroll");
        protected CommonScrollViewContext context;

        protected virtual void Start()
        {
            var rectTransform = transform as RectTransform;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchoredPosition3D = Vector3.zero;
            UpdatePosition(0);
        }

        /// <summary>
        /// 设定上下文。
        /// </summary>
        /// <param name="context"></param>
        public override void SetContext(CommonScrollViewContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 来更新这个小区的内容。
        /// </summary>
        /// <param name="itemData"></param>
        public override void UpdateContent(CommonCellData itemData)
        {
            if (context != null)
            {
                var isSelected = context.SelectedIndex == DataIndex;
            }
        }

        /// <summary>
        /// 来更新小区的位置。
        /// </summary>
        /// <param name="position"></param>
        public override void UpdatePosition(float position)
        {
            currentPosition = position;
            animator.Play(scrollTriggerHash, -1, position);
            animator.speed = 0;
        }

        // 如果gameobject不活跃，animator会被重置，所以保持当前位置，在onenable的时刻重新设置当前位置。
        float currentPosition = 0;
        void OnEnable()
        {
            UpdatePosition(currentPosition);
        }

        protected void OnPressedCell()
        {
            if (context != null)
            {
                context.OnPressedCell(this);
            }
        }
    }
}