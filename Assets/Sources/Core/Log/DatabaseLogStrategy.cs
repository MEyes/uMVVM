namespace Assets.Sources.Core.Log
{
    public class DatabaseLogStrategy : LogStrategy
    {
        public DatabaseLogStrategy()
        {
            SetContentWriter();
        }
        protected sealed override void SetContentWriter()
        {
            Writer = new DatabaseContentWriter();
        }

        protected override void RecordMessage(string message)
        {
            Writer.Write(message);
        }
    }
}
