﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    internal class CodeGenerator
    {
        public String getCode() => Guid.NewGuid().ToString();
    }
}
