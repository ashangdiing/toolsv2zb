using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.callOut
{
    class Evaluation
    {
        public string taskID="0000";
        public string name="您";
        public string phoneNumber = "910000";
        public string dateTime="2015-01-01 01:01:01";
        public string department="城管";
        public string accidentAddress="大街";
        public string evaluationResult="-1";
        public string state="1";//0,未创建，-1已删除,-2可以删除
        public string lastUpdateTime = "1901-01-01 01:01:01";
         public string context="噪音扰民";
         public string toIVRTime(string time) {
           //  tools.log.Debug(dateTime);
             string yy, mm, dd,hh,mi,ss;
             DateTime dt = Convert.ToDateTime(time);
            yy= dt.Year.ToString();//2005
             hh=dt.Hour.ToString();//13 
           dd=dt.Day.ToString();
            mi= dt.Minute.ToString();//30 
            mm= dt.Month.ToString();//11 
           ss=dt.Second.ToString();//28 
             return yy+"年"+mm+"月"+dd+"日" +hh+"时"+mi+"分"+ss+"秒";
         }
         public string toIVRHour(string time)
         {
             //  tools.log.Debug(dateTime);
             string yy, mm, dd, hh, mi, ss;
             DateTime dt = Convert.ToDateTime(time);
             yy = dt.Year.ToString();//2005
             hh = dt.Hour.ToString();//13 
             dd = dt.Day.ToString();
             mi = dt.Minute.ToString();//30 
             mm = dt.Month.ToString();//11 
             ss = dt.Second.ToString();//28 
             return yy + "年" + mm + "月" + dd + "日" + hh;
         }
         public string toIVRDay(string time)
         {
             //  tools.log.Debug(dateTime);
             string  dd;
             DateTime dt = Convert.ToDateTime(time);
             dd = dt.Day.ToString();
             return dd;
         }
         public string toTTSDay(string time)
         {
             //  tools.log.Debug(dateTime);
             string dd;
             DateTime dt = Convert.ToDateTime(time);
             dd = dt.Day.ToString();
             return dd;
         }
         public string toIVRMM(string time)
         {
             string mm;
             DateTime dt = Convert.ToDateTime(time);
             mm = dt.Month.ToString();//11 
             return mm;
         }

         public string toTTSMM(string time)
         {
             string mm;
             DateTime dt = Convert.ToDateTime(time);
             mm = dt.Month.ToString();//11 
             return mm;
         }
        public string toString(){
            return "id ： "+taskID + "名字：" + name + "时间 ; "+dateTime + "部门： "+department + 
                "发生地点："+accidentAddress + "评论结果："+evaluationResult + "当前状态:" + state + "最后更新时间:"+lastUpdateTime;
        }

    }
}
