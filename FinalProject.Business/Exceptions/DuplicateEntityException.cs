﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Exceptions;

public class DuplicateEntityException : Exception
{
    public DuplicateEntityException(string? message) : base(message)
    {
    }
}