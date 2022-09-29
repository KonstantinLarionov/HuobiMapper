﻿using System.Collections.Generic;
using System.ComponentModel;
using HuobiMapper.Requests.Output;
using JetBrains.Annotations;


namespace HuobiMapper.Requests.Payload
{
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]   
    public abstract class RequestPayload
    {   [NotNull]
        internal abstract string EndPoint { get; }
        internal abstract RequestMethod Method { get; }
        internal int? RecvWindow { get; set; }
        [CanBeNull]
        internal virtual IDictionary<string, string> Properties => null;
        [CanBeNull]
        public virtual IDictionary<string, string> Headers { get; set; }
        [CanBeNull]
        internal virtual object Body { get; }
    }
}