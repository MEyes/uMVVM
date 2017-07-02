namespace Assets.Sources.Core.Log
{
    public class DatabaseLogStrategy : LogStrategy
    {
        protected override void SetContentWriter()
        {
            Writer = new DatabaseContentWriter();
        }

        protected override void RecordMessage(string message)
        {
            Writer.Write(message);
        }
    }
}
