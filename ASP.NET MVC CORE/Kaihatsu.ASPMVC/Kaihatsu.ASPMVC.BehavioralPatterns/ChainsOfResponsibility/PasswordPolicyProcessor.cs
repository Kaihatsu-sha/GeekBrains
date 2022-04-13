using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.BehavioralPatterns.ChainsOfResponsibility;

internal class PasswordPolicyProcessor : IProcessorBlock
{
    public bool Process(string context)
    {
        return context.Contains("пароль");
    }
}
