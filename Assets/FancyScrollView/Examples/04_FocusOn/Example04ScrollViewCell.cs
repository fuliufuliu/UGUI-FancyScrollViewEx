﻿using UnityEngine;
using UnityEngine.UI;

namespace FancyScrollView
{
    public class Example04ScrollViewCell
        : FancyScrollViewCell<Example04CellDto, Example04ScrollViewContext>
    {
        [SerializeField]
        Animator animator;
        [SerializeField]
        Text message;
        [SerializeField]
        Image image;
        [SerializeField]
        Button button;

        static readonly int scrollTriggerHash = Animator.StringToHash("scroll");
        Example04ScrollViewContext context;

        void Start()
        {
            var rectTransform = transform as RectTransform;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchoredPosition3D = Vector3.zero;
            UpdatePosition(0);

            button.onClick.AddListener(OnPressedCell);
        }

        /// <summary>
        /// コンテキストを設定します
        /// 设定上下文。
        /// </summary>
        /// <param name="context"></param>
        public override void SetContext(Example04ScrollViewContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// セルの内容を更新します
        /// 来更新这个小区的内容。
        /// </summary>
        /// <param name="itemData"></param>
        public override void UpdateContent(Example04CellDto itemData)
        {
            message.text = itemData.Message;

            if (context != null)
            {
                var isSelected = context.SelectedIndex == DataIndex;
                image.color = isSelected
                    ? new Color32(0, 255, 255, 100)
                    : new Color32(255, 255, 255, 77);
            }
        }

        /// <summary>
        /// セルの位置を更新します
        /// 来更新小区的位置。
        /// </summary>
        /// <param name="position"></param>
        public override void UpdatePosition(float position)
        {
            currentPosition = position;
            animator.Play(scrollTriggerHash, -1, position);
            animator.speed = 0;
        }

        // GameObject が非アクティブになると Animator がリセットされてしまうため
        // 現在位置を保持しておいて OnEnable のタイミングで現在位置を再設定します
        // 如果gameobject不活跃，animator会被重置，所以保持当前位置，在onenable的时刻重新设置当前位置。
        float currentPosition = 0;
        void OnEnable()
        {
            UpdatePosition(currentPosition);
        }

        void OnPressedCell()
        {
            if (context != null)
            {
                context.OnPressedCell(this);
            }
        }
    }
}
