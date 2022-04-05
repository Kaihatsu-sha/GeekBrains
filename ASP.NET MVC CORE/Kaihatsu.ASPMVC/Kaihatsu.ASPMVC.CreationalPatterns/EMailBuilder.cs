using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.CreationalPatterns;

// Строитель.
// Может использоватся вместе с распорядителем Director
internal class EMailBuilder
{
    public string Recipient { get; set; }
    public string Subject { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Signature { get; set; }

    public EMail Build()
    {
        return new EMail(Recipient, Subject, Title, Body, Signature);
    }
}

// Строител на fluetn интерфейсе
internal class EMailBuilderFluent
{
    public string Recipient { get; set; } = "test@mail.com";
    public string Subject { get; set; } = "test message";
    public string Title { get; set; } = "This is test message";
    public string Body { get; set; } = "Body defaul value";
    public string Signature { get; set; } = "EMailBuilder";

    public EMailBuilderFluent SetRecipient(string recipient)
    {
        Recipient = recipient;
        return this;
    }

    public EMailBuilderFluent SetSubject(string subject)
    {
        Subject = subject;
        return this;
    }

    public EMailBuilderFluent SetTitle(string title)
    {
        Title = title;
        return this;
    }

    public EMailBuilderFluent SetBody(string body)
    {
        Body = body;
        return this;
    }

    public EMailBuilderFluent SetSignature(string signature)
    {
        Signature = signature;
        return this;
    }

    public EMail Build()
    {
        return new EMail(Recipient, Subject, Title, Body, Signature);
    }
}
