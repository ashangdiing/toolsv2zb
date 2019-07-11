using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace tools.appConfig
{
   public  class appconfigUpdate
    {

       /**
        *  public  static string ApplicationPath = Directory.GetCurrentDirectory().ToString();
        *       tools.appConfig.appconfigUpdate.addOrUpdateAppconfigAppSetting(getProperty.ApplicationPath + "\\App.config", "lea", "aaaa");
          tools.appConfig.appconfigUpdate.addOrUpdateAppconfigAppSetting(getProperty.ApplicationPath+"\\App.config", "cc", "c:\\ddddd>>>>>");
        *  
        * tools.appConfig.appconfigUpdate.removeAppconfigAppSetting(getProperty.ApplicationPath + "\\App.config", "RecordPath");
    
        */
       public static void addOrUpdateAppconfigAppSetting(string path, string key, string value)
       {
           System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
           xDoc.Load(path);

           System.Xml.XmlNode xNode;
           System.Xml.XmlElement xElem1;
           System.Xml.XmlElement xElem2;
           xNode = xDoc.SelectSingleNode("//appSettings");
           xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + key + "']");
           if (xElem1 != null) xElem1.SetAttribute("value", value);
           else
           {
               xElem2 = xDoc.CreateElement("add");
               xElem2.SetAttribute("key", key);
               xElem2.SetAttribute("value", value);
               xNode.AppendChild(xElem2);
           }
           xDoc.Save(path);
       }
       public static void removeAppconfigAppSetting(string path, string key)
       {
           System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
           xDoc.Load(path);

           System.Xml.XmlNode xNode;
           System.Xml.XmlElement xElem1;           
           xNode = xDoc.SelectSingleNode("//appSettings");
           xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + key + "']");        
           if (xElem1== null) return;
           xNode.RemoveChild(xElem1);        
           xDoc.Save(path);
       }
    }
}
