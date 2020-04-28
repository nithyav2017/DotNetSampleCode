using DataLayer.Repository;
using MessageRelay.DataAccess;
using MessageRelay.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public interface IUnitOfWork
    {

        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IRepoMessageQueue MessageQueuesRepository { get; }
        IRepository<Template> Templates { get; }
        IRepository<MessageType> MessageType { get; }
        IRepository<MessageQueue> MessageQueue { get; }
    }
}
