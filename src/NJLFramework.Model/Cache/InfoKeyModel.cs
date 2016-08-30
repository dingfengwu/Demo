using NJLFramework.Base;

namespace NJLFramework.Model
{
    public class InfoKeyModel: IEntity<InfoKeyModel>
    {
        public IdType type;
        public string id;

        public override string ToString() => $"{type}-{id}.";
    }

    public enum IdType
    {
        /// <summary>
        /// user
        /// </summary>
        U,
        /// <summary>
        /// App
        /// </summary>
        A,
        /// <summary>
        /// Module
        /// </summary>
        M,
        /// <summary>
        /// other
        /// </summary>
        O
    }
}
