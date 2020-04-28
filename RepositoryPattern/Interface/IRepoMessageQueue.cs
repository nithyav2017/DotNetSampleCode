using MessageRelay.DataAccess;
using MessageRelay.DataAccess.Repository;
using MessagingRelay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
 public   interface IRepoMessageQueue:IRepository<MessageQueue>
    {
        IQueryable<MessageQueueModel> GetMessasgeQueueByType(int frequencyType);
    }
}
