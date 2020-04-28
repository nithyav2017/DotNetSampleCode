using System;
using DataLayer.Repository;
using MessageRelay.DataAccess;
using MessageRelay.DataAccess.Repository;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private MessagingEntities DbContext { get; set; }


        public UnitOfWork()
        {
            CreateDbContext();
          
        }
        private IRepoMessageQueue _messagequeue;

        private IRepository<Template> _Templates;
        private IRepository<MessageQueue> _MessageQueue;
        private IRepository<MessageType> _MessageType;

        public IRepoMessageQueue MessageQueuesRepository
        {
            get
            {
                if (_messagequeue == null)
                {
                    _messagequeue = new RepoMessageQueue (DbContext);
                }
                return _messagequeue;
            }

        }

        public IRepository<Template> Templates
        {
            get
            {
                if (_Templates == null)
                {
                    _Templates = new Repository<Template>(DbContext);
                }
                return _Templates;
            }

        }

        public IRepository<MessageQueue> MessageQueue
        {
            get
            {
                if (_MessageQueue == null)
                {
                    _MessageQueue = new Repository<MessageQueue>(DbContext);
                }
                return _MessageQueue;
            }

        }

        public IRepository<MessageType> MessageType
        {
            get
            {
                if (_MessageType == null)
                {
                    _MessageType = new Repository<MessageType>(DbContext);
                }
                return _MessageType;
            }

        }



        public void Commit()
        {
            DbContext.SaveChanges();
        }
        protected void CreateDbContext()
        {
            DbContext = new MessagingEntities();
                         
            DbContext.Configuration.ProxyCreationEnabled = false;

            DbContext.Configuration.LazyLoadingEnabled = false;
            
            DbContext.Configuration.ValidateOnSaveEnabled = false;
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

    }
}
