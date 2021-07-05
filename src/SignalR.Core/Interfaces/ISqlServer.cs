using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Core.Interfaces
{
    public interface ISqlServer<T>
    {
        Task<T> GetClient();

        Task<string> GetQueueUrl(string QueueName, string QueueOwnerAWSAccountId);
    }
}
