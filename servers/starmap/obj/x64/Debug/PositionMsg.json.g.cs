// This is a system generated file. It reflects the Starcounter App Template defined in the file "unknown"
// DO NOT MODIFY DIRECTLY - CHANGES WILL BE OVERWRITTEN

using System;
using System.Collections;
using System.Collections.Generic;
using Starcounter.Advanced;
using Starcounter;
using Starcounter.Internal;
using Starcounter.Templates;

public class PositionMsg : Json<starmap.Models.Position> {
    public static TPositionMsg DefaultTemplate = new TPositionMsg();
    public PositionMsg() { Template = DefaultTemplate; }
    public PositionMsg(TPositionMsg template) { Template = template; }
    public new TPositionMsg Template { get { return (TPositionMsg)base.Template; } set { base.Template = value; } }
    public new PositionMsgMetadata Metadata { get { return (PositionMsgMetadata)base.Metadata; } }
    public String Name { get { return Get(Template.Name); } set { Set(Template.Name, value); } }
    public long Latitude { get { return Get(Template.Latitude); } set { Set(Template.Latitude, value); } }
    public long Longitude { get { return Get(Template.Longitude); } set { Set(Template.Longitude, value); } }
    public class TPositionMsg : TJson {
        public TPositionMsg()
            : base() {
            BindChildren = true;
            InstanceType = typeof(PositionMsg);
            ClassName = "PositionMsg";
            Name = Add<TString>("Name");
            Latitude = Add<TLong>("Latitude");
            Longitude = Add<TLong>("Longitude");
        }
        public override object CreateInstance(Container parent) { return new PositionMsg(this) { Parent = parent }; }
        public TString Name;
        public TLong Latitude;
        public TLong Longitude;
    }
    public class PositionMsgMetadata : ObjMetadata {
        public PositionMsgMetadata(Json obj, TJson template) : base(obj, template) { }
        public new PositionMsg App { get { return (PositionMsg)base.App; } }
        public new PositionMsg.TPositionMsg Template { get { return (PositionMsg.TPositionMsg)base.Template; } }
        public StringMetadata Name { get { return __p_Name ?? (__p_Name = new StringMetadata(App, App.Template.Name)); } }
        private StringMetadata __p_Name;
        public LongMetadata Latitude { get { return __p_Latitude ?? (__p_Latitude = new LongMetadata(App, App.Template.Latitude)); } }
        private LongMetadata __p_Latitude;
        public LongMetadata Longitude { get { return __p_Longitude ?? (__p_Longitude = new LongMetadata(App, App.Template.Longitude)); } }
        private LongMetadata __p_Longitude;
    }
}
