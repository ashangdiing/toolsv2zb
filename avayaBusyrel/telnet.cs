using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace avayaBusyrel
{
    public class telnet
    {

        TcpClient telnet_tcp_client;

        public string strhost;      // IP 地址  
        public string strusername;  // username  
        public string strpassword;  // password  
        public string pin;  // password  
        public string model;  // password  
        private int ilogin_wait_time = 10000; //网络延迟等待时间  
        private int irecv_wait_time = 5000; //网络延迟等待时间  
        private int port;


        //Telnet protocal key  
    enum Verbs  
    {  
        EOF=236,//文件结束符 
        SUSP = 237,//挂起当前进程（作业控制）
        ABORT = 238,//异常中止进程 
        EOR = 239,//记录结束符i 
        SE = 240,//自选项结束 
        NOP = 241,//无操作
        DM =242, //数据标记 
        BRK = 243,//中断
        IP = 244,//中断进程
        AO =245,//异常中止输出
        AYT = 246,//对方是否还在运行？ 
        EC =247,//转义字符 
        EL = 248,//删除行 
        GA = 249,//继续进行 
        SB =250,//子选项开始
        WILL = 251,  //同意启动（enable）选项
        WONT = 252,  //拒绝启动选项 
        DO = 253,  //认可选项请求 
        DONT = 254,  //拒绝选项请求
        IAC = 255  
    }
    public telnet(string hostIP, string username,string password,int ports ,string pinm)  
    {
        strhost = hostIP; strusername = username; strpassword = password; pin = "dadmin01"; model = "w2ktt"; port=ports;
        open_connect();
    }

    public telnet()
    {
    }  
    /** 
     * Telnet 关闭连接 
     */  
    public void close_telnet()  
    {  
        try   
        {  
            if (telnet_tcp_client == null)  
            {  
                return;  
            }  
            if (telnet_tcp_client.Connected)  
            {  
                telnet_tcp_client.Close();  
            }  
        }  
        catch (Exception ex)  
        {
            log.writeLine("异常" + ex);  
        }  
    }  
  
    /** 
     * Telnet连接到服务器 
     */  
    public bool open_connect()  
    {  
        bool blresult;  
        string strtemp;  
  
        blresult = true;  
  
        try  
        {  
            // new socket  
            telnet_tcp_client = new TcpClient(this.strhost, port);  
   
            // read host info data  
            strtemp = recv_data_from_host();
            log.writeLine("连接读取：" + strtemp);
            blresult = strtemp.TrimEnd().EndsWith(":");
            strtemp = recv_data_from_host();
            log.writeLine("连接读取5：" + strtemp);
            send_data_to_host(this.strusername + "/r/n");
            log.writeLine("连接读取5：" + strtemp);
            send_data_to_host(this.strusername + "/n/r");
            log.writeLine("连接读取6：" + strtemp);
            strtemp = recv_data_from_host();
            log.writeLine("连接读取7：" + strtemp);
            strtemp = recv_data_from_host();
            strtemp = recv_data_from_host();
            while (!blresult) {
                send_data_to_host(this.strusername + "/n/r");  
                strtemp = recv_data_from_host();
                log.writeLine("连接读取2：" + strtemp);
            }
            if (blresult == false)  
            {
                log.writeLine("等待输入用户名1：");
                System.Threading.Thread.Sleep(10000);  
              //  return blresult;  
            }
           

            // username send to host  
            blresult = send_data_to_host(this.strusername + "/n/r");  
            if (blresult == false)  
            {
                log.writeLine("username send error");
                System.Threading.Thread.Sleep(ilogin_wait_time);   
            }  
  
            System.Threading.Thread.Sleep(ilogin_wait_time);  
            strtemp = recv_data_from_host();
            log.writeLine("获取输入密码信息：" + strtemp);
            blresult = strtemp.TrimEnd().EndsWith(":");  
            if (blresult == false)  
            {
                System.Threading.Thread.Sleep(ilogin_wait_time);  
            }  
  
            // password send to host  
            blresult = send_data_to_host(this.strpassword + "/n/r");  
            if (blresult == false)  
            {
                System.Threading.Thread.Sleep(ilogin_wait_time); 
            }
            strtemp = recv_data_from_host();
            log.writeLine("获取输入pin信息：" + strtemp);
            //pin
            blresult = strtemp.TrimEnd().EndsWith(":");
            if (blresult == false)
            {
                System.Threading.Thread.Sleep(ilogin_wait_time);
            }
            blresult = send_data_to_host("dadmin01" + "/n/r");


            System.Threading.Thread.Sleep(ilogin_wait_time);

            if (blresult == false)
            {
                System.Threading.Thread.Sleep(ilogin_wait_time);
            }
            strtemp = recv_data_from_host();
            log.writeLine("获取输入mod信息：" + strtemp);
            //model
            blresult = strtemp.TrimEnd().EndsWith("]");
            if (blresult == false)
            {
                System.Threading.Thread.Sleep(ilogin_wait_time);
            }
            blresult = send_data_to_host("w2ktt" + "/n/r");  



            System.Threading.Thread.Sleep(ilogin_wait_time);  
            strtemp = recv_data_from_host();  
            if ((strtemp.Trim().LastIndexOf("#") > -1) ||  
                (strtemp.Trim().LastIndexOf("$") > -1) ||  
                (strtemp.Trim().LastIndexOf(">") > -1))  
            {  
                blresult = true;  
            }  
            else  
            {  
                blresult = false;  
            }  
        }  
        catch (Exception ex)  
        {  
            blresult = false;  
        }  
        return blresult;  
    }  
  
    /** 
     * 执行命令 
     */  
    public bool exec_command(string strcmd)  
    {  
        bool blresult;  
        string strprompt;  
  
        blresult = false;  
        strprompt = "";  
  
        if (telnet_tcp_client.Connected)  
        {  
            blresult = send_data_to_host(strcmd + "/n/r");  
            if (blresult == false)  
            {  
                return false;  
            }  
            strprompt = "";  
  
            strprompt = recv_data_from_host();  
  
            if ((strprompt.Trim().LastIndexOf("#") > -1) ||   
                (strprompt.Trim().LastIndexOf("$") > -1) ||  
                (strprompt.Trim().LastIndexOf(">") > -1))  
            {  
                blresult = true;  
                return blresult;  
            }  
        }  
        return blresult;  
    }  
  
    /** 
     * telnet向主机发送数据 
     */  
    public bool send_data_to_host(string strcmd)  
    {  
        try  
        {  
            // socket error时、return  
            if (!telnet_tcp_client.Connected)  
            {  
                return false;  
            }  
  
            byte[] bbuf = System.Text.ASCIIEncoding.ASCII.GetBytes(strcmd.Replace("/0xFF", "/0xFF/0xFF"));  
  
            telnet_tcp_client.GetStream().Write(bbuf, 0, bbuf.Length);  
        }  
        catch(Exception ex)  
        {  
            return false;  
        }  
        return true;  
    }  
  
    /** 
     * Telnet从主机接受数据 
     */  
    public string recv_data_from_host()  
    {  
        int iinput_data;    //data  
        int inputverb;  
        int inputoption;  
        StringBuilder sbtemp;  
        NetworkStream ns_temp;  
        byte[] bread_buffer;  
        StringBuilder sbcomplete_message;  
        int iread_bytes_num;  
  
        sbtemp = new StringBuilder();
        log.writeLine("--------------------------");
        // socket没有连接的时候，返回空  
        if (!telnet_tcp_client.Connected)  
        {  
            return null;  
        }  
  
        do  
        {  
            // read 1 byte  
            iinput_data = telnet_tcp_client.GetStream().ReadByte();
            log.writeLine("date: " + iinput_data);
            switch (iinput_data)  
            {  
                case -1:  
                    break;  
                case (int)Verbs.IAC: // 接受的数据有keyword  
  
                    // read 1 byte  
                    inputverb = telnet_tcp_client.GetStream().ReadByte();  
                    if (inputverb == -1) break;  
                    switch (inputverb)  
                    {  
                        case (int)Verbs.IAC:  
                            sbtemp.Append(inputverb);  
                            break;  
                        case (int)Verbs.DO:  
                        case (int)Verbs.DONT:  
                        case (int)Verbs.WILL:  
                        case (int)Verbs.WONT:  
                            inputoption = telnet_tcp_client.GetStream().ReadByte();  
                            if (inputoption == -1) break;  
                            telnet_tcp_client.GetStream().WriteByte((byte)Verbs.IAC);  
                            telnet_tcp_client.GetStream().WriteByte(inputverb ==   
                            (int)Verbs.DO ? (byte)Verbs.WONT : (byte)Verbs.DONT);  
                            telnet_tcp_client.GetStream().WriteByte((byte)inputoption);  
                            break;  
                        default:  
                            break;  
                    }  
                    break;  
                default:  
                    sbtemp.Append((char)iinput_data);  
                    bread_buffer = new byte[8192];  
                    sbcomplete_message = new StringBuilder();  
                    iread_bytes_num = 0;  
                    ns_temp = telnet_tcp_client.GetStream();  
                    if (ns_temp.CanRead)  
                    {  
                        System.Threading.Thread.Sleep(ilogin_wait_time);  
                        iread_bytes_num = ns_temp.Read(bread_buffer, 0, bread_buffer.Length);  
                        sbtemp.AppendFormat("{0}", Encoding.ASCII.GetString(bread_buffer,   
                                            0, iread_bytes_num));  
                    }  
                    break;  
            }  
              
            // timeout  
            System.Threading.Thread.Sleep(irecv_wait_time);  
        } while (telnet_tcp_client.Available > 0);  
  
        // 返回接受的数据  
        return sbtemp.ToString();  
    }  



    }
}