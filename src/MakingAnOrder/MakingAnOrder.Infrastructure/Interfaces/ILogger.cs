using System;
using MakingAnOrder.Infrastructure.Enum;

namespace MakingAnOrder.Infrastructure.Interfaces
{
    public interface ILogger
    {
        void WriteMessage(string message, MessageLevel msgLevel, Exception exception = null);

        void WriteMessageByTemplate(MessageLevel msgLevel, string msgTemplateId, Exception exception, params object[] values);

        void WriteMessageByTemplate(MessageLevel msgLevel, string msgTemplateId, params object[] values);
    }
}
