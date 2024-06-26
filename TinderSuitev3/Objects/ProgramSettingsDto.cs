﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderSuitev3.Objects
{
    public class ProgramSettingsDto
    {
        public string? OpenAiKey { get; set; }
        public int WeightThreshold { get; set; }
        public int MaxTokens { get; set; }
        public string? AiMessageContext { get; set; }
        public string? AiPickupLineContext { get; set; }
    }
}
