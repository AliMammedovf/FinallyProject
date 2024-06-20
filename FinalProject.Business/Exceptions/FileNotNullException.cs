using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Exceptions;

public class FileNotNullException : Exception
{
    public FileNotNullException(string? message) : base(message)
    {
    }
}
