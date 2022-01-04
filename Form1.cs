using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;
using dllCheck;
using System.Net;
using System.Diagnostics;
using EditConfigForm;
using System.Data;
using Newtonsoft.Json;
using Microsoft.Win32;
using WindowsFormsApp1;

namespace 工具
{
    public partial class Form1 : Form
    {
        // 放入详细信息
        string detail=null;

        // 放安装包的3条url
        List<string> PackageURL = new List<string>();

        // 放规则的3条url
        List<string> RuleURL = new List<string>();


        // 请求失败的列表
        List<string> failureList = new List<string>();

        // URL的路径
        string URLpath= currentDic + @"\config\urlConfig.json";

        bool canShowSave = false;

        // 从Json获取到的多条结果  双向同步的步骤为 1.改JsonList 2.执行UpdateConfig方法
        List<JsonInfo> JsonList = new List<JsonInfo>();

        // 存放DLL结果 结构为 appKey:<JKey:JValue>
        Dictionary<string,List<Dictionary<string, string>>> DLLList = new Dictionary<string, List<Dictionary<string, string>>>();

        static string currentDic = System.Environment.CurrentDirectory;

        // moren config路径
        string JsonPath = currentDic+@"\config\Config.json";
        // 建立数据表
        DataTable dt = new DataTable();

        // 决定url
        string urltxt = null;

        // 绑定查询信息
        BindingSource JsonInfoBind = new BindingSource();

        // URL的JToken 用于提取URL进行搜索
        JObject URLjObj;

        // 初始化
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(JsonPath))
            {
                MessageBox.Show(JsonPath+"不存在");
            }
            
            else {
               
                string jsonText = File.ReadAllText(JsonPath);
                // 初始化JsonList
                LoadJson(jsonText);
                dateshow.Text = "今天的日期是：" + DateTime.Now;

                configPathtxt.Text = JsonPath; //配置表路径

                // Result DGV列头
                dt.Columns.Add("sortkey", typeof(int));
                dt.Columns.Add("appKey", typeof(string));
                dt.Columns.Add("fileName", typeof(string));
                dt.Columns.Add("type", typeof(string));
                dt.Columns.Add("engineVersion", typeof(string));
                dt.Columns.Add("md5", typeof(string));
                dt.Columns.Add("git_version", typeof(string));
                dt.Columns.Add("version", typeof(string));
                dt.Columns.Add("downloadUrl", typeof(string));
            }


            if (!File.Exists(URLpath))
            {
                MessageBox.Show("URL目录不存在");
            }
            else
            {
                string URLstring = File.ReadAllText(URLpath);   // 读取URL的配置文件
                URLjObj = JObject.Parse(URLstring);


                // 将URL写入Package的List
                foreach (JProperty item in URLjObj.SelectToken("Packages"))
                {
                    PackageURL.Add(item.Value.ToString());
                }
                // 将URL写入Rule规则的List
                foreach (JProperty item in URLjObj.SelectToken("Rule"))
                {
                    RuleURL.Add(item.Value.ToString());
                }

            }






            // 设置归属
            for (int i = 0; i < JsonList.Count; i++)
            {
                var item = JsonList[i];
                string result = FindWhichEnvirment(item.URL);
                item.BeLong = result;

            }

            // 初始化数据源 双向绑定
            JsonInfoBind.DataSource = JsonList;
            Config_dgv.DataSource = JsonInfoBind;


            // 新增后面的功能
            addButton();

            UpdateConfig();
            
            //设置填充格式
            Config_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            

        }

        // 删除按钮
        DataGridViewButtonColumn btnDelete;
        // 选择环境
        DataGridViewComboBoxColumn cmbEnvirment;
        // 选择工具
        DataGridViewComboBoxColumn cmbTool;
        // 进度条
        progressForm progress;
        private void addButton()
        {

            // 删除按钮
            btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "是否删除";
            btnDelete.Name = "delete";
            btnDelete.SortMode = DataGridViewColumnSortMode.NotSortable;
            btnDelete.DefaultCellStyle.NullValue = "删除";
            // 添加按钮
            Config_dgv.Columns.Add(btnDelete);





            // 更改工具
            cmbTool = new DataGridViewComboBoxColumn();
            cmbTool.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            cmbTool.Name = "cmbTool";
            cmbTool.HeaderText = "哪一个工具";
            cmbTool.DefaultCellStyle.NullValue = "请选择...";
            foreach (var item in chooseToolCbx.Items)
            {
                cmbTool.Items.Add(item);

            }
            Config_dgv.Columns.Add(cmbTool);


            // 更改环境
            cmbEnvirment = new DataGridViewComboBoxColumn();
            cmbEnvirment.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            cmbEnvirment.Name = "cmbEnvirment";
            cmbEnvirment.HeaderText = "哪一个环境";
            cmbEnvirment.DefaultCellStyle.NullValue = "请选择...";
            
            foreach (var item in chooseEnviromentCbx.Items)
            {
                cmbEnvirment.Items.Add(item);

            }

            Config_dgv.Columns.Add(cmbEnvirment);

          

        }

        // 用于找到这条URL来自哪个工具  安装包还是规则  再将结果返回
        string FindWhichEnvirment(string url) {
            string tool = "Rule";
            foreach (string item in PackageURL)
            {
                // 得去空格保证相等
                if (item.Trim() == url.Trim())
                {
                    tool = "Packages";
                }
            }

            foreach (JProperty item in URLjObj[tool])
            {
                // 转中文 Rule 规则    Packages  安装包
                if (tool == "Rule")
                {
                    tool = "规则";
                }
                else if (tool == "Packages") {
                    tool = "安装包";
                }

                //1.测试环境
                //2.正式环境
                //3.外网环境

                if (item.Value.ToString().Trim() == url.Trim())
                {
                    string EnvirmentName="未知环境";
                    if (item.Name.Contains("test"))
                    {
                        EnvirmentName = "测试环境";
                    }
                    else if (item.Name.Contains("formal"))
                    {
                        EnvirmentName = "正式环境";
                    }
                    else if (item.Name.Contains("outer"))
                    {
                        EnvirmentName = "外网环境";
                    }
                    return tool+"_"+ EnvirmentName;
                }
            }
            return "未知环境";
        }


        // 将dgv数据同步写入配置表
        private void UpdateConfig()
        {
            string jsonText = JsonConvert.SerializeObject(JsonList);

            // 新增
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonText);
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonPath, output);

        }

        // 检查空
        bool NullCheck()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is ComboBox)
                {
                    // 未选中返回-1
                    if ((c as ComboBox).SelectedIndex == -1)
                    {
                        MessageBox.Show("请正确填写信息");
                        return false;
                    }
                }
                
                // 检查TextBox是否为空
                if (c is TextBox)
                {
                        if (string.IsNullOrEmpty((c as TextBox).Text))
                        {
                            MessageBox.Show("请正确填写信息");
                            return false;
                        }
                    
                    
                }
            }
            return true;
        }


        // 此次请求的次数
        int Projectcount;
        string jsonText;
        showDetail show = new showDetail();
        string path = currentDic + $@"\AutoSave\{DateTime.Now.Month}{DateTime.Now.Day}.txt";
        FileInfo fileInfo;
        // 点击查询功能
        private void button1_Click(object sender, EventArgs e)
        {
            bool noChecks = false;

            #region 查询过程
            failureList.Clear();
            Projectcount = 0;
            JsonList.Clear();
            jsonText = File.ReadAllText(JsonPath);
            LoadJson(jsonText);
            foreach (var item in JsonList)
            {
                if (item.Ischecked)
                {
                    Projectcount++;
                    noChecks = true;
                }
            }
            // 检查是否一个都没选中
            if (noChecks)
            {
                canShowSave = false;
                dateshow.Text = "此次查询的时间是：" + DateTime.Now;
                CheckstatusLabel.Visible = false;
                detail = "";
              
                DLLList.Clear();
                dt.Clear();
                show.ShowDetail(detail);
                progress = new progressForm(Projectcount);
                progress.Show();
                

                // 发送请求,并将结果放入DLLInfo这个字典中 以appKey ： DLLInfo的形式放置
                for (int i = 0; i < JsonList.Count; i++)
                {
                    JsonInfo Jsonitem = JsonList[i];
                    string appKey = SendRequest(Jsonitem.URL, Jsonitem.appKey, Jsonitem.engineVersion, Jsonitem.Ischecked);
                    
                    
                    try
                    {
                        // 遍历DLL里面的属性到 显示详细窗口
                        if (DLLList.Count > 0 && appKey!=null)
                        {
                            for (int a = 0; a < DLLList[appKey].Count; a++)
                            {

                                foreach (var item in DLLList[appKey][a])
                                {
                                    detail += item.ToString()+ System.Environment.NewLine;
                                }
                                detail += System.Environment.NewLine;

                            }
                        }

                    }
                    catch (Exception)
                    {
                        // 有报错的appkey就记录下来
                        failureList.Add(appKey);
                    }

                  
                  
                    try
                    {
                        if (DLLList.Count > 0 && appKey != null)
                        {
                            // 一个查询结束 时自动保存结果到AutoSave 默认以日期保存一个文件
                            if (AutoSave.Checked)
                            {
                                
                                canShowSave = true;
                                string str = null;
                                str += System.Environment.NewLine
                                       + "以下是" + DateTime.Now + $"对{appKey}查询的结果"
                                       + System.Environment.NewLine;
                                for (int a = 0; a < DLLList[appKey].Count; a++)
                                {
                                    str += $"{appKey}:" + DLLList[appKey].ToString() + System.Environment.NewLine; // 存疑
                                }

                                if (!File.Exists(path))
                                {
                                    FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                                    StreamWriter sw = new StreamWriter(fs);
                                    sw.Write(str);
                                    sw.Flush();
                                    sw.Close();
                                }
                                else
                                {
                                    FileStream fs = new FileStream(path, FileMode.Append);
                                    //文本写入
                                    StreamWriter sw = new StreamWriter(fs);
                                    sw.Write(str);
                                    sw.Flush();
                                    sw.Close();
                                }

                               
                            }
                            DLLList[appKey].Clear();
                        }
                    }
                    catch (Exception egg)
                    {
                        MessageBox.Show(egg.ToString(),"自动保存失败");
                    }
                }
               
                
                progress.Close();
                fileInfo = new FileInfo(path);

                // sortkey隐藏
                if (Result_dgv.Columns.Count > 0)
                {
                    Result_dgv.Columns[0].Visible = false;  
                }
                // 文件大于10mb时报警
                if (fileInfo.Length > (1024*1024 * 10))
                {
                    MessageBox.Show("自动保存的文件已经10mb以上了");
                }

                CheckstatusLabel.Visible = true;    // 提示查询成功


                //for (int i = 0; i < this.Result_dgv.Columns.Count; i++)
                //{
                // //将每一列都调整为自动适应模式
                // this.Result_dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);

                //}

                //for (int i = 0; i < this.Config_dgv.Columns.Count; i++)
                //{
                //    if (Config_dgv.Columns[i].Name!="URL")
                //    {
                //        //将每一列都调整为自动适应模式(除了URL)
                //        this.Config_dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //    }
                   


                //}

                // 开启新窗口显示详细信息
                show.ShowDetail(detail);
                show.Refresh();
            }
            else
            {
                MessageBox.Show("没有选中任何项");
            }
            if (failureList.Count>0)
            {
                foreach (var item in failureList)
                {
                    MessageBox.Show(item,"查询失败列表,请检查配置文件");
                }
            }
            #endregion
        }



        // 测试传入的Json字符串
        private void LoadJson(string jsonPath)
            {
            
            JArray jArray = JArray.Parse(jsonPath);
            JsonInfo info;
                for (int i = 0; i < jArray.Count; i++)
                {
                    info = new JsonInfo();
                    JObject tempo = JObject.Parse(jArray[i].ToString());
                    if (!tempo.ContainsKey("appKey"))
                    {
                        MessageBox.Show( "缺少appKey");
                        
                    }
                    else if (!tempo.ContainsKey("URL"))
                    {
                        MessageBox.Show( "缺少URL");
                        
                    }
                    else if (!tempo.ContainsKey("engineVersion"))
                    {
                        MessageBox.Show( "缺少engineVersion");
                        
                    }

                    // 从配置表中取出数据并赋值给JsonList
                    else {

                        info.Ischecked = (bool)tempo["Ischecked"];
                        info.URL = tempo["URL"].ToString();
                        info.appKey = tempo["appKey"].ToString();
                        info.engineVersion = tempo["engineVersion"].ToString();
                        info.BeLong= tempo["BeLong"].ToString();

                }
                    //  将数据存到JsonList
                    JsonList.Add(info);


                }

               

            
        }



        // 排序标记
        int mark = 1;
        DLLInfo info;
        Dictionary<string, string> parmas;
        HttpWebRequest request = null;
        // 发送请求
        public string SendRequest(string URL, string appKey, string engineVersion,bool Ischecked)
        {
            // 被选中才查
            if (Ischecked)
            {
                
                info = new DLLInfo();
                parmas = new Dictionary<string, string>();
                parmas.Add("appKey", appKey);
                parmas.Add("engineVersion", engineVersion);
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(URL);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                // 设置网络请求
                if (request != null)
                {
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Timeout = 5000;
                    
                    #region 添加Post参数
                    StringBuilder builder = new StringBuilder();
                    int i = 0;
                    foreach (var item in parmas)
                    {
                        if (i > 0)
                        {
                            // 每个参数之间增加&
                            builder.Append("&");
                        }
                        //链接键值对
                        builder.AppendFormat("{0}={1}", item.Key, item.Value);
                        i++;
                    }
                    // 将后面参数改成二进制形式传入
                    byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
                    request.ContentLength = data.Length;

                    try
                    {
                        using (Stream reqStream = request.GetRequestStream())
                        {
                            reqStream.Write(data, 0, data.Length);
                            reqStream.Close();
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("请检查网络设置");
                        Application.Restart();
                    }
                    #endregion
                    HttpWebResponse resp;
                    Stream stream = null;
                    // 处理请求失败
                    try
                    {

                        resp = (HttpWebResponse)request.GetResponse();
                        stream = resp.GetResponseStream();   // 创建流
                    }
                    catch (Exception)
                    {
                       
                        progress.statusInfo = $"网络缓慢,正在尝试重新查询{appKey}...";
                        progress.Refresh();
                        try
                        {
                            request.ContentLength = data.Length;
                            using (Stream reqStream = request.GetRequestStream())
                            {
                                reqStream.Write(data, 0, data.Length);
                                reqStream.Close();
                            }
                        }
                        catch (Exception exc)
                        {

                            MessageBox.Show(exc.ToString(),"重试失败");
                            
                        }
                      
                        
                    }

                    try
                    {
                        //获取响应内容
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {

                            JObject thisObj = JObject.Parse(reader.ReadToEnd());
                            if (thisObj.SelectToken("result") == null)
                            {
                                MessageBox.Show(appKey + "查询结果： " + thisObj["msg"].ToString());
                            }
                            else
                            {

                                JArray jArray = JArray.Parse(thisObj["result"]["data"].ToString());
                                List<Dictionary<string, string>> jTokenList = new List<Dictionary<string, string>>(); // 再将转化后的字典打包成list

                                for (int index = 0; index < jArray.Count; index++)
                                {
                                    Dictionary<string, string> jToken = new Dictionary<string, string>(); // 需要将JToken转化为字典 从请求结果提取数据转化
                                    jToken.Add("appKey", appKey);
                                    jToken.Add("downloadUrl", jArray[index]["downloadUrl"].ToString());
                                    jToken.Add("engineVersion", jArray[index]["engineVersion"].ToString());
                                    jToken.Add("fileName", jArray[index]["fileName"].ToString());
                                    jToken.Add("git_version", jArray[index]["git_version"].ToString());
                                    jToken.Add("md5", jArray[index]["md5"].ToString());
                                    jToken.Add("type", jArray[index]["type"].ToString());
                                    jToken.Add("version", jArray[index]["version"].ToString());
                                    // 当前appKey的所有DLL信息
                                    jTokenList.Add(jToken);



                                }
                                // 处理相同键多次查询情况
                                try
                                {
                                    if (DLLList.ContainsKey(appKey))
                                    {
                                        appKey += "_another";
                                        DLLList.Add(appKey, jTokenList);
                                    }
                                    else
                                    {
                                        // List再保存字典  appKey ：List
                                        DLLList.Add(appKey, jTokenList);
                                    }
                                }
                                catch (Exception)
                                {

                                    
                                }

                                   
                                


                                // 
                                for (int i1 = 0; i1 < DLLList[appKey].Count; i1++)
                                {

                                    Dictionary<string, string> item = DLLList[appKey][i1];
                                    DataRow dr = dt.NewRow();
                                    dr["sortkey"] = mark;
                                    dr["appKey"] = item["appKey"].ToString();
                                    dr["fileName"] = item["fileName"].ToString();
                                    dr["type"] = item["type"].ToString();
                                    dr["engineVersion"] = item["engineVersion"].ToString();
                                    dr["md5"] = item["md5"].ToString();
                                    dr["git_version"] = item["git_version"].ToString();
                                    dr["version"] = item["version"].ToString();
                                    dr["downloadUrl"] = item["downloadUrl"].ToString();

                                    dt.Rows.Add(dr);


                                }
                                // 标记增加控制颜色
                                mark++;
                                // 进度条
                                progress.AddProgress();
                                // 渲染
                                Result_dgv.DataSource = dt;

                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());

                    }

                      


                    
                   

                   
                }
                
                //MessageBox.Show("此次请求时间：" + Stopwatch.ElapsedMilliseconds.ToString());
                return appKey;
            }

            return null;
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            bool IsOpen = false;
            if (detail == null)
            {
                MessageBox.Show("还没有写入查询信息");
            }
            else {

                foreach (Form item in Application.OpenForms)
                {
                    if (item.Name == "showDetail")
                    {
                        IsOpen = true;
                    }
                }

                if (!IsOpen)
                {
                    if (show.IsDisposed)//如果已经销毁，则重新创建子窗口对象
                    {
                        show = new showDetail();//此为你双击打开的FORM
                        show.ShowDetail(detail);
                        show.Show();
                        show.Focus();
                    }
                    show.Show();
                }
                else
                {
                    show.Focus();
                }
               
            }
           
        }



        string vscodePath = null;
        string[] tmp = System.Environment.GetEnvironmentVariable("path").Split(';');
        List<string> pathList = new List<string>();
        // VsCode打开配置文件
        private void OpenConfigBtn_Click(object sender, EventArgs e)
        {
            foreach (string item in tmp)
            {
                pathList.Add(item);
            }
            foreach (var item in pathList)
            {
                if (item.Contains("Microsoft VS Code"))
                {
                    vscodePath = item.Replace(@"\bin",@"\Code.exe");
                    
                }
            }

            if (vscodePath==null)
            {
                MessageBox.Show("若要使用Vscode请在path配置环境变量");
                System.Diagnostics.Process.Start("notepad.exe", JsonPath);
            }
            else
            {
                System.Diagnostics.Process.Start(vscodePath, JsonPath);
                
            }

        }


        bool AllChecked = false;
        // 全选/全不选
        private void SwitchMode_Click(object sender, EventArgs e)
        {
            AllChecked = !AllChecked;
            if (AllChecked)
            {
                // 全选
                for (int i = 0; i < Config_dgv.Rows.Count; i++)
                {
                    if ((Convert.ToBoolean(Config_dgv.Rows[i].Cells[0].Value) == false))
                    {
                        Config_dgv.Rows[i].Cells[0].Value = true;
                        JsonList[i].Ischecked = true;
                    }
                    else
                        continue;
                }
            }
            else {
                // 全不选
                for (int i = 0; i < Config_dgv.Rows.Count; i++)
                {
                    if ((Convert.ToBoolean(Config_dgv.Rows[i].Cells[0].Value) == true))
                    {
                        Config_dgv.Rows[i].Cells[0].Value = false;
                        JsonList[i].Ischecked = false;
                    }
                    else
                        continue;
                }
            }

            UpdateConfig();
            
        }

        // 绑定完成
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView curDgv = (DataGridView)sender;
            foreach (DataGridViewRow Row in curDgv.Rows)
            {
                if (Row != null)
                {
                    foreach (DataGridViewCell cell in Row.Cells)
                    {
                        if (curDgv.Columns[cell.ColumnIndex].DataPropertyName.Equals("sortkey"))
                        {
                            if ((int)cell.Value%2!=0)
                            {
                                Row.DefaultCellStyle.BackColor = Color.LightGray;
                            }
                            else
                            {
                                Row.DefaultCellStyle.BackColor = Color.LightBlue;
                            }
                        }
                    }
                }
            }
        }

        private void addConfigBtn_Click(object sender, EventArgs e)
        {
            // 先检查是否填写
            if (NullCheck())
            {
                // 对号入座
                if (chooseToolCbx.SelectedIndex == 0)
                {
                    // 0 安装包
                    urltxt = PackageURL[chooseEnviromentCbx.SelectedIndex];
                }
                else if (chooseToolCbx.SelectedIndex == 1)
                {
                    // 1 规则
                    urltxt = RuleURL[chooseEnviromentCbx.SelectedIndex];
                }
                string url = urltxt;
                string appKey = appKeyTxt.Text;
                string engine = EngineTxt.Text;
                //初始化Peoples对象。
                JsonInfo info = new JsonInfo
                {
                    URL = url.Trim(),
                    appKey = appKey,
                    engineVersion = engine,
                    Ischecked = false,
                    BeLong = FindWhichEnvirment(url)
                   
                };

                JsonList.Add(info);
                // 先删除按钮
                Config_dgv.Columns.Remove(btnDelete);
                Config_dgv.Columns.Remove(cmbEnvirment);
                Config_dgv.Columns.Remove(cmbTool);

                // 更新dgv 并 写入json
                UpdateConfig();
                // 这里要先取下数据源，再重新接上才能让配置表的dgv更新
                Config_dgv.DataSource = null;
                Config_dgv.DataSource = JsonInfoBind;
                addButton();


            }

        }

        private void Config_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // 删除按钮功能
            if (Config_dgv.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
            {
                       
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult DResult = MessageBox.Show(string.Format("你真的要删除吗?"), "是否删除", messButton);

                if (DResult == DialogResult.OK)
                {
                    Config_dgv.Rows.RemoveAt(e.RowIndex);
                    UpdateConfig();
                }
                
            }



            // 是否勾选 列
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                
                if ((bool)Config_dgv.Rows[e.RowIndex].Cells[0].EditedFormattedValue)
                {
                    //checkbox功能
                    Config_dgv.Rows[e.RowIndex].Cells[0].Value = (bool)Config_dgv.Rows[e.RowIndex].Cells[0].EditedFormattedValue;
                   
                    for (int i = 0; i < Config_dgv.Rows.Count; i++)
                    {
                        DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)Config_dgv.Rows[i].Cells["Configchecked"];
                        bool flag = Convert.ToBoolean(checkCell.Value);
                        JsonList[i].Ischecked = flag;
                    }
                    UpdateConfig();
                }
                else
                {
                    JsonList[e.RowIndex].Ischecked = false;
                    UpdateConfig();
                }
                
            }
        }

        // 修改按钮
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (JsonList.Count>0 && Config_dgv.Rows.Count>0)
            {
                for (int i = 0; i <Config_dgv.Rows.Count; i++)
                {
                    if (Config_dgv.Rows[i].Cells["cmbTool"].Value != null && Config_dgv.Rows[i].Cells["cmbEnvirment"].Value != null)
                    {
                        // 如果是安装包
                        if (Config_dgv.Rows[i].Cells["cmbTool"].Value.ToString() == "安装包分析工具")
                        {
                            int index = chooseEnviromentCbx.Items.IndexOf(Config_dgv.Rows[i].Cells["cmbEnvirment"].Value);
                            JsonList[i].URL = PackageURL[index];
                            JsonList[i].BeLong = FindWhichEnvirment(JsonList[i].URL);
                            MessageBox.Show(FindWhichEnvirment(JsonList[i].URL));
                        }
                        // 如果是检查工具
                        if (Config_dgv.Rows[i].Cells["cmbTool"].Value.ToString() == "规则检查工具")
                        {
                            // 取到当初里面的值
                            int index = chooseEnviromentCbx.Items.IndexOf(Config_dgv.Rows[i].Cells["cmbEnvirment"].Value);
                            JsonList[i].URL = RuleURL[index];
                            JsonList[i].BeLong = FindWhichEnvirment(JsonList[i].URL);
                            MessageBox.Show(FindWhichEnvirment(JsonList[i].URL));
                        }

                    }
                    else
                    {
                        JsonList[i].BeLong = FindWhichEnvirment(Config_dgv.Rows[i].Cells["URL"].Value.ToString());
                    }
                }
            }


            UpdateConfig();
            MessageBox.Show("修改成功!");
        }
        
        private void Config_dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // 动态检测是否被勾选
            for (int i = 0; i < Config_dgv.Rows.Count; i++)
            {
                if (JsonList[i].Ischecked)
                {
                    Config_dgv.Rows[i].Cells["Configchecked"].Value = true;
                }
            }
            
        }
       
        private void Config_dgv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateConfig();
        }
        #region 自适应窗体

        //  自动调整窗体
        AutoSize auto = new AutoSize();

        private void Form1_Load(object sender, EventArgs e)
        {
            auto.controllInitializeSize(this);
        }
        #endregion

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

            auto.controlAutoSize(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
