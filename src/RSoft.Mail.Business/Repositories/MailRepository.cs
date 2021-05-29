using RSoft.Mail.Contract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RSoft.Mail.Business.Repositories
{

    /// <summary>
    /// Mail respository object
    /// </summary>
    public class MailRepository : IMailRepository
    {

        #region Public methods
        
        ///<inheritdoc/>
        public Task<Guid> SaveRequestAsync(IMessage message, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                //BACKLOG: NotImplementedException
                Console.WriteLine("NotImplementedException");
                return Guid.Empty;

            });

        }

        #endregion

    }
}
