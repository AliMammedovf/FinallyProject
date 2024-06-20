using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Exceptions;

public class FlavourNotFoundException : Exception
{
	public FlavourNotFoundException(string? message) : base(message)
	{
	}
}
