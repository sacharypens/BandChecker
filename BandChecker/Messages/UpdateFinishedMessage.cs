﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandChecker.Messages
{
    class UpdateFinishedMessage
    {
        public enum MessageType { Updated, Deleted, Inserted};
        public UpdateFinishedMessage(MessageType Actie) {
            Type = Actie;
        }

        public MessageType Type { set; get; }
    }
}
