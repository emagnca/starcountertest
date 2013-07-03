// This is a system generated file. It reflects the Starcounter App Template defined in the file "unknown"
// DO NOT MODIFY DIRECTLY - CHANGES WILL BE OVERWRITTEN

using System;
using System.Collections;
using System.Collections.Generic;
using Starcounter.Advanced;
using Starcounter;
using Starcounter.Internal;
using Starcounter.Templates;

public class Message1 : Json {
    public static TMessage1 DefaultTemplate = new TMessage1();
    public Message1() { Template = DefaultTemplate; }
    public Message1(TMessage1 template) { Template = template; }
    public new TMessage1 Template { get { return (TMessage1)base.Template; } set { base.Template = value; } }
    public new Message1Metadata Metadata { get { return (Message1Metadata)base.Metadata; } }
    public class TMessage1 : TJson {
        public TMessage1()
            : base() {
            InstanceType = typeof(Message1);
            ClassName = "Message1";
        }
        public override object CreateInstance(Container parent) { return new Message1(this) { Parent = parent }; }
    }
    public class Message1Metadata : ObjMetadata {
        public Message1Metadata(Json obj, TJson template) : base(obj, template) { }
        public new Message1 App { get { return (Message1)base.App; } }
        public new Message1.TMessage1 Template { get { return (Message1.TMessage1)base.Template; } }
    }
}
