﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdClient.Communication.Responses
{
    public class ResponseClientJson
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<ResponseShortProductJson> Products { get; set; } = [];
            
    }
}
