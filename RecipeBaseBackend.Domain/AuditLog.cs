﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Domain
{
    public class AuditLog : Entity
    {
        public string UseCaseName { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTime ExecutedAt { get; set; }
        public string Data { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
