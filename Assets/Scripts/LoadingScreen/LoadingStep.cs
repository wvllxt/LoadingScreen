using System;
using System.Threading.Tasks;

namespace LoadingScreen
{
    public class LoadingStep
    {
        public string Description { get; }
        public Func<Task> ActionAsync { get; }
        
        public LoadingStep(string description, Func<Task> actionAsync)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ActionAsync = actionAsync ?? throw new ArgumentNullException(nameof(actionAsync));
        }
    }
}