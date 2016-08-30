using NJLFramework.Base;

namespace NJLFramework.Model
{
    public class TableKeyModel: IEntity<TableKeyModel>
    {
        public string table;
        public string id;

        public override string ToString() => $"t{table}-{id}.";
    }
}
