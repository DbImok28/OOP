﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models.lab10
{
    public partial class ChatMessage
    {
        public int ChatMessagesId { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public string MessageText { get; set; }
        public DateTime SendDate { get; set; }
    }
}
