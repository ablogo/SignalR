using SignalR.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Infrastructure.Services
{
    public class SqlServerService<T> : ISqlServer<T>
    {
        public Task<T> GetClient()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetQueueUrl(string QueueName, string QueueOwnerAWSAccountId)
        {
            throw new NotImplementedException();
        }
    }
}
