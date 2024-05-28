using LogConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogConverter.Interfaces
{
    public interface ILogParser
    {
        IEnumerable<LogEntry> ParseLogs(string content);
    }
}
