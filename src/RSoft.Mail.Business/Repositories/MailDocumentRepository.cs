﻿using MongoDB.Driver;
using RSoft.Framework.Infra.Data.MongoDb.Repositories;
using RSoft.Mail.Business.Documents;

namespace RSoft.Mail.Business.Repositories
{
    public class MailDocumentRepository : DocumentRepositoryBase<MailDocument>, IMailDocumentRepository
    {

        ///<inheritdoc/>
        protected override UpdateDefinition<MailDocument> MapToUpdate(MailDocument document)
        {

            UpdateDefinition<MailDocument> update = Builders<MailDocument>.Update
                .Set(x => x.CreatedAtUtc, document.CreatedAtUtc)
                .Set(x => x.From, document.From)
                .Set(x => x.ReplyTo, document.ReplyTo)
                .Set(x => x.To, document.To)
                .Set(x => x.Cc, document.Cc)
                .Set(x => x.Bcc, document.Bcc)
                .Set(x => x.Subject, document.Subject)
                .Set(x => x.Content, document.Content)
                .Set(x => x.Files, document.Files)
                .Set(x => x.EnableHtml, document.EnableHtml)
            ;
            return update;

        }
    }
}
