using MessageRelay.DataAccess;
using MessageRelay.DataAccess.Repository;
using MessagingRelay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    class RepoMessageQueue : Repository<MessageQueue>, IRepoMessageQueue
    {
        MessagingEntities context = new MessagingEntities();
        public RepoMessageQueue(DbContext dbContext) : base(dbContext)
        {
           
        }

        public IQueryable<MessageQueue> GetEmailData()
        {
            throw new NotImplementedException();
        }

        public IQueryable<MessageQueueModel> GetMessasgeQueueByType(int frequencyType)
        {

            /*   return (from mc in context.MessageControls
                       join frq in context.FrequencyTypes on mc.FrequencyTypeID equals frq.FrequencyTypeID
                       join t in context.Templates on mc.TemplateID equals t.TemplateID
                       join mt in context.MessageTypes on mc.MessageTypeID equals mt.MessageTypeID
                       join mq in context.MessageQueues on mc.Message_ControlID equals mq.MessageControlID
                       join u in context.Users on mq.UserID equals u.UserID
                       where mc.FrequencyTypeID == frequencyType
                       select new MessageQueueModel()
                       {
                           UserID = u.UserID,
                           EmailAddress = u.Email,
                           UserFullName = u.UserName,
                           TemplateId = t.TemplateID,
                           MessageQueueID = mq.MessagequeueId
                       });*/

             var result = context.GetMailQueue().AsQueryable();
             return (from q in result
                        select new MessageQueueModel
                        {
                            EmailAddress = q.Email,
                            Message = q.Message,
                            Subject = q.Subject
                     //       MessageQueueID=q.
                        });       
        }
    }
}
