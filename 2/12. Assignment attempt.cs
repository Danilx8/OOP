namespace OOP
{
    public partial class General
    {
        public General AssignmentAttempt(General target, General source)
        {
            if (target.GetType().IsInstanceOfType(source))
            {
                target = source;
                return target;
            }

            // Переменную Void реализовать не получилось в прошлом задании
            target = default;
            return default;
        }
    }
}