using UnityEngine;

namespace FancyScrollView
{
    public class FancyScrollViewCell<TData, TContext> : MonoBehaviour where TContext : class
    {
        /// <summary>
        /// 设定上下文。
        /// </summary>
        /// <param name="context"></param>
        public virtual void SetContext(TContext context)
        {
        }

        /// <summary>
        /// 来更新这个小区的内容。
        /// </summary>
        /// <param name="itemData"></param>
        public virtual void UpdateContent(TData itemData)
        {
        }

        /// <summary>
        /// 来更新小区的位置。
        /// </summary>
        /// <param name="position"></param>
        public virtual void UpdatePosition(float position)
        {
        }

        /// <summary>
        /// 显示单元的显示/非显示。
        /// </summary>
        /// <param name="visible"></param>
        public virtual void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }

        /// <summary>
        /// 在这个单元上显示的数据的索引
        /// </summary>
        public int DataIndex { get; set; }
    }

    public class FancyScrollViewCell<TData> : FancyScrollViewCell<TData, FancyScrollViewNullContext>
    {

    }
}
