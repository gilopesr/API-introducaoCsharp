﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProdClient.Exceptions.ExceptionBase
{
    public class NotFoundException : ProdClientException
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {
        }

        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
