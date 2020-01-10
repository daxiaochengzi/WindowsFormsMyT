using Excel;
using MJ.Ui.MJenums;
using MJ.Ui.MJMessageBox;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsMyT.database;
using WindowsFormsMyT.InterfaceEg;
using WindowsFormsMyT.Logger;
using WindowsFormsMyT.model;
using WindowsFormsMyT.NinjectEG;

namespace WindowsFormsMyT
{
    public partial class Form1 :MJ.Ui.MJForms.MJForm
    {
        public Form1()
        {
            InitializeComponent();
            MJ.Ui.MJHelpers.MJColorbox.Colorbox = this.Style.ToString();
            
        }

        private void btb1_Click(object sender, EventArgs e)
        {
            MyClass<int> myClass = new MyClass<int>();//带参数
            myClass.MyMethod<string>("123");//传参数
            myClass.MyMethod("123", "555");//传参数
            myClass.MyMethod<int>();//不传参数
            //MyClass myClass = new MyClass();//(1)不带参数
            //myClass.MyMethod<int>(7);
            MyClass1<string> my1 = new MyClass1<string>();
            my1.MyMethod<string>("我去","55");
            MyClass1<int> mys = new MyClass1<int>();
            mys.MyMethod<string>("我去",33);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void mjButton1_Click(object sender, EventArgs e)
        {
            MyClass2 ff = new MyClass2();
            ff.SomeMethod<int>(2);
            ff.SomeMethod2<long>(1, 2);
            
        }

        private void mjButton2_Click(object sender, EventArgs e)
        {
            MyClass3<int> obj = new MyClass3<int>();
            MyClass3<int>.GenericDelegate del;
            //委托推理
            del = obj.SomeMethod;
            del(3);
           
        }

        private void mjButton3_Click(object sender, EventArgs e)
        {
            //int i;
            DefaultTest<string> Test = new DefaultTest<string>();
           // i=Test.Main(123);
            // MessageBox.Show( Convert.ToString(i));
            var ff = Test.Main("123");
         
        }

        private void mjButton4_Click(object sender, EventArgs e)
        {
            mjButton4.Text = "Clicked!!";
            Button newbutton = new Button();
            newbutton.Text = "点我";
            newbutton.Click += new EventHandler(newbutton_Click1);
//       EventHandler就是个事件和委托的关系，newbutton.Click += new EventHandler(newbutton_Click)
    //这句的意思就是给newbutton按钮的点击绑定一个newbutton_Click事件，这时候你后台的 protected void newbutton_Click(object sender, EventArgs e)点击事件才能触发
            Controls.Add(newbutton);
        }
        private void newbutton_Click1(object sender, EventArgs e)
        {
            ((Button)sender).Text = "点击成功";
        }
        public delegate int MyDelegateEventHandler(string parm); //定义委托
        public int MyMethod1(string parm)
        {
         
            return 3;
        }
        public int MyMethod3(string parm) 
        {
         
            MessageBox.Show("先执行一");
            return 2;
        }
        private void mjButton5_Click(object sender, EventArgs e)
        { string Is_Delegate_name ;
            MyDelegateEventHandler myDelegate;
            myDelegate = new MyDelegateEventHandler(MyMethod3);
            myDelegate += new MyDelegateEventHandler(MyMethod1);//合并第二个方法
            //--------委托索引
            if (myDelegate != null) 
            {
                System.Delegate[] dels = myDelegate.GetInvocationList();
                for (int i = 0; i < dels.Length; i++)
                {
                    Is_Delegate_name = Convert.ToString(dels[i].Method);
                }
     
            }
            var send = myDelegate("123");//调用委托
            MessageBox.Show(Convert.ToString(send));  
        }
        //  Action 表示无参，无返回值的委托
        //Action<int,string> 表示有传入参数int,string无返回值的委托
        //Action<int,string,bool> 表示有传入参数int,string,bool无返回值的委托
        //Action<int,int,int,int> 表示有传入4个int型参数，无返回值的委托
        public void Test<T>(Action<T> action, T p)
        {
            action(p);
        }
        private void Action(string s)
        {
            MessageBox.Show(s);  
        }
        private void mjButton6_Click(object sender, EventArgs e)
        {
            Test<string>(Action, "wyl");
          
        }
       //Func是无返回值的泛型委托
       // Func<int> 表示无参，返回值为int的委托
       // Func<object,string,int> 表示传入参数为object, string 返回值为int的委托
       // Func<object,string,int> 表示传入参数为object, string 返回值为int的委托
       // Func<T1,T2,,T3,int> 表示传入参数为T1,T2,,T3(泛型)返回值为int的委托
        //1.4.1.predicate 是返回bool型的泛型委托;
        //1.4.2.predicate<int> 表示传入参数为int 返回bool的委托;
        //1.4.3.Predicate有且只有一个参数，返回值固定为bool;
        public int Test<T1, T2>(Func<T1, T2, int> func, T1 a, T2 b)
        {
         return func(a, b);
        }
        private int Fun(int a, int b)
        {
            
            MessageBox.Show(Convert.ToString(a));  
          return 1;
        }

        private void mjButton7_Click(object sender, EventArgs e)
        {
            Test<int, int>(Fun, 100, 200);//调用
        }

        private void mjButton8_Click(object sender, EventArgs e)
        {
          
           
            MJMessageBox.Show(this, "This is a sample MetroMessagebox `OK` only button", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
        }

        private void mjButton9_Click(object sender, EventArgs e)
        {
            MJMessageBox.Show(this, "This is a sample MetroMessagebox `OK` and `Cancel` button", "MetroMessagebox", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void mjButton10_Click(object sender, EventArgs e)
        {
            MJMessageBox.Show(this, "This is a sample MetroMessagebox `Yes` and `No` button", "MetroMessagebox", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void mjButton11_Click(object sender, EventArgs e)
        {
            MJMessageBox.Show(this, "This is a sample MetroMessagebox `Yes`, `No` and `Cancel` button", "MetroMessagebox", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        private void mjButton12_Click(object sender, EventArgs e)
        {
            MJMessageBox.Show(this, "This is a sample `default` MetroMessagebox ", "MetroMessagebox");
        }

        private void mjButton13_Click(object sender, EventArgs e)
        {
            MJMessageBox.Show(this, "This is a sample MetroMessagebox `Retry` and `Cancel` button.  With warning style.", "MetroMessagebox", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
        }

        private void mjButton14_Click(object sender, EventArgs e)
        {
          
            MJMessageBox.Show(this, "This is a sample MetroMessagebox `Abort`, `Retry` and `Ignore` button.  With Error style.", "MetroMessagebox", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        }

        private void mjButton15_Click(object sender, EventArgs e)
        {
            string Colorbox;
            var m = new Random();
            int next = m.Next(0, 13);
            this.Style = (MJColorStyle)next;
            Colorbox = this.Style.ToString();
            mjStyleManager1.Style = (MJColorStyle)next;
            // = Color.FromArgb(209, 17, 65);
            MJ.Ui.MJHelpers.MJColorbox.Colorbox = Colorbox;
        }

        private void mjButton17_Click(object sender, EventArgs e)
        {
           // ShoppingCart shoppingCart = new ShoppingCart(new CommoditySumValuation());
             ShoppingCart shoppingCart =new ShoppingCart(new CommoditySumValuation(new DisCount()));
            MJMessageBox.Show(this, shoppingCart.CommodityTotalPrice().ToString(), "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void mjButton16_Click(object sender, EventArgs e)
        {
            //#region IoC框架功能(一)
            //IKernel kernel = new StandardKernel();
            //kernel.Bind<IValuation>().To<CommoditySumValuation>();
            //IValuation valuation = kernel.Get<IValuation>();
            //#endregion
            IKernel kernel = new StandardKernel();//(二)
            kernel.Bind<IValuation>().To<CommoditySumValuation>();
            kernel.Bind<IValuationDisCount>().To<DisCount>();
            IValuation valuation = kernel.Get<IValuation>();

            ShoppingCart shoppingCart = new ShoppingCart(valuation);
         
            MJMessageBox.Show(this, shoppingCart.CommodityTotalPrice().ToString(), "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mjButton18_Click(object sender, EventArgs e)
        {
                //   public class Module1 {  
                //      public override  void Load() { ... }  
                //}  
  
                //public class Module2 {  
                //      public override  void Load() { ... }  
                //}  
  
                //class Program {  
                //      public static void Main()  
                //      {  
                //            IKernel kernel = new StandardKernel(new Module1(), new Module2(), ...);  
                //            ...  
                //      }  
                  //}  多个案例
            IKernel kernal = new StandardKernel(new WarriorModule());
            Samurai1 s1 = new Samurai1(kernal.Get<IWeapon>()); // 构造函数注入  
            Samurai1 s = kernal.Get<Samurai1>();
            s.Attack("enemy");
            MJMessageBox.Show(this, "温馨提示", s.Attack("构造函数注入"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mjButton19_Click(object sender, EventArgs e)
        {
            IKernel kernal = new StandardKernel(new WarriorModule());
            Samurai s = new Samurai() { Weapon = kernal.Get<IWeapon>() };// 属性注入  
            MJMessageBox.Show(this, "温馨提示", s.Attack("属性注入") , MessageBoxButtons.OK, MessageBoxIcon.Information); 
            
        }

        private void mjButton20_Click(object sender, EventArgs e)
        {
             IKernel kernel = new StandardKernel(new MyModule());
             ILogger logger = kernel.Get<ILogger>();//获取的是ILogger
             ILogger loggers = kernel.Get<FileLogger>();//获取的是FileLogger 
            
             MJMessageBox.Show(this, "温馨提示", loggers.Write("测试一下哟1"), MessageBoxButtons.OK, MessageBoxIcon.Information); 
             MJMessageBox.Show(this, "温馨提示", logger.Write("测试一下哟2"), MessageBoxButtons.OK, MessageBoxIcon.Information); 

            //用到的方法
           //(1) Bind<T1>().To<T2>()
            //其实就是接口IKernel的方法，把某个类绑定到某个接口，T1代表的就是接口或者抽象类，
            //而T2代表的就是其实现类
             //IKernel ninjectKernel = new StandardKernel();
            // ninjectKernel.Bind<ILogger>().To<FileLogger>();
            //(2） Get<ISomeInterface>（）
            //其实就是得到某个接口的实例，例如下面的例子就是得到ILogger的实例FileLogger：
             //ILogger myLogger = ninjectKernel.Get<ILogger>();
            //（3） Bind<T1>().To<T2>(). WithPropertyValue("SomeProprity", value);
            //其实就是在绑定接口的实例时，同时给实例NinjectTester的属性赋值，例如：
             //ninjectKernel.Bind<ITester>().To<NinjectTester>().WithPropertyValue("_Message", "这是一个属性值注入");
           // (5）Bind<T1 >() .ToConstant ()
            //这个方法的意思是绑定到某个已经存在的常量，例如
             //   StudentRepository sr = new StudentRepository();
          // ninjectKernel.Bind<IStudentRepository>().ToConstant(sr);
           //(6) Bind<T1 >() .ToSelf()
           // 这个方法意思是绑定到自身，但是这个绑定的对象只能是具体类，不能是抽象类；
            //为什么要自身绑定呢？其实也就是为了能够利用Ninject解析对象本身而已。例如：
            // ninjectKernel.Bind<StudentRepository>().ToSelf();
             //StudentRepository sr = ninjectKernel.Get<StudentRepository>();
            //(7）Bind<T1>().To<T2>().WhenInjectedInto<instance>()
            //这个方法是条件绑定，就是说只有当注入的对象是某个对象的实例时才会将绑定的接口进行实例化
            // ninjectKernel.Bind<IValueCalculater>().To<IterativeValueCalculatgor>().WhenInjectedInto<LimitShoppingCart>();
        }

        private void mjButton21_Click(object sender, EventArgs e)
        {
            IKernel kernal = new StandardKernel(new WarriorModule());
            Samurai s = new Samurai();
            s.Arm(kernal.Get<IWeapon>()); // 方法注入  
            MJMessageBox.Show(this, "温馨提示", s.Attack("方法注入"), MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void mjButton22_Click(object sender, EventArgs e)
        {
            IKernel kernal = new StandardKernel(new WarriorModule());
            Samurai2 s = new Samurai2();
            s._weapon = kernal.Get<IWeapon>(); // 需将Samurai类中字段_weapon修饰符改为public才可以访问  
            MJMessageBox.Show(this, "温馨提示", s.Attack("属性注入"), MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void mjTextBox1_Click(object sender, EventArgs e)
        {
           //  IDataAccessor da = DataAccessorFactory.Instance.GetDataAccessor(DataAccessorFactory.AccessorType.SqlServer);
            IDataAccessor da = new SqlDataAccessor();
        test2 t = new test2();//任何实体都可以
        //t.name = rnd.Next().ToString() + i.ToString();
            da.InsertEntity(t);
        }

        private void mjButton23_Click(object sender, EventArgs e)
        {
            person pro = new person();//实例化类对象


            ITeacher iteach = pro;      //使用派生类对象实例化接口ITeacher
            iteach.Name = "橙子";
            iteach.Sex = "男";
            MJMessageBox.Show(this, "温馨提示", iteach.teach().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            IStudent istu = pro;        //使用派生类对象实例化接口IStudent
            istu.Name = "C#";
            MJMessageBox.Show(this, "温馨提示", istu.study().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mjButton24_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:26281/api/Account/Login";
            string param = "{\"username\":\"admin\",\"password\":\"123456\",\"rememberme\":\"true\"}";
            //string paramData = "{username:'admin',password:'123456',rememberme=true}";
            PostWebRequest(url, param);

        }
/// <summary>
/// Post提交数据
/// </summary>
/// <param name="postUrl">URL</param>
/// <param name="paramData">参数</param>
/// <returns></returns>
private string PostWebRequest(string postUrl, string paramData)
{
    string ret = string.Empty;
    try
    {
        if (!postUrl.StartsWith("http://"))
            return "";
 
        byte[] byteArray = Encoding.Default.GetBytes(paramData); //转化
        HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
        webReq.Method = "POST";
        webReq.ContentType = "application/json";
        webReq.ContentLength = byteArray.Length;
        Stream newStream = webReq.GetRequestStream();
        newStream.Write(byteArray, 0, byteArray.Length);//写入参数
        newStream.Close();
        HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
        StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        ret = sr.ReadToEnd();
        sr.Close();
        response.Close();
        newStream.Close();
    }
    catch (Exception ex)
    {
       return ex.Message;
    }
    return ret;
}

private void mjButton25_Click(object sender, EventArgs e)
{

    var iteach = Description(TaskType.Pipe);
    MJMessageBox.Show(this, "温馨提示", iteach, MessageBoxButtons.OK, MessageBoxIcon.Information);
}
/// <summary>
/// 获取枚举描述
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="en"></param>
/// <returns></returns>
public string Description<T>(T en)
{


    Type type = en.GetType();
    MemberInfo[] memInfo = type.GetMember(en.ToString());
    if (memInfo != null && memInfo.Length > 0)
    {
        object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attrs != null && attrs.Length > 0)
            return ((DescriptionAttribute)attrs[0]).Description;
    }
    return en.ToString();
}

private void mjButton26_Click(object sender, EventArgs e)
{
    string str_TaskType = "Pipe";
    //var dd = Enum.GetNames(typeof(TaskType.Pipe));
    var getType = (TaskType)Enum.Parse(typeof(TaskType), str_TaskType);
    var values = getType.GetHashCode().ToString();
    MJMessageBox.Show(this, "温馨提示", values, MessageBoxButtons.OK, MessageBoxIcon.Information);
}

private void button1_Click(object sender, EventArgs e)
{
    var dd1 = Convert.ToDouble(1);
    var dd22 = Convert.ToDouble(3);
    var ddd = Convert.ToInt16(Math.Round(dd1 / dd22 * 100, MidpointRounding.AwayFromZero));
            Int32 stmonth, stday, styear, sthour;
    Int32 endmonth, endday, endyear, endhour;  
    string strstrart = "2017-11-09 17:11";
    string strend = "2017-11-09 20:11";
    var strdate = strstrart.Substring(0, 10);
    var enddate = strend.Substring(0, 10);
    string[] strArray = strdate.Split('-');
    styear = Convert.ToInt32(strArray[0].ToString());
    stmonth = Convert.ToInt32(strArray[1].ToString());
    stday = Convert.ToInt32(strArray[2].ToString());
    string[] endArray = enddate.Split('-');
    styear = Convert.ToInt32(endArray[0].ToString());
    stmonth = Convert.ToInt32(endArray[1].ToString());
    stday = Convert.ToInt32(endArray[2].ToString());
    sthour = Convert.ToInt32(strstrart.Substring(11, 2));
    endhour = Convert.ToInt32(strend.Substring(11, 2));
  
}

private void mjButton28_Click(object sender, EventArgs e)
{

}

private void mjButton30_Click(object sender, EventArgs e)
{
    var listdd = new List<Tests>();
    listdd.Add(new Tests {Name="a",Code="1" });
    listdd.Add(new Tests { Name = "a", Code = "1" });
    listdd.Add(new Tests { Name = "b", Code = "2" });
    listdd.Add(new Tests { Name = "b", Code = "1" });
    listdd.Add(new Tests { Name = "c", Code = "3" });

    var ddd = listdd.DistinctBy(p =>  p.Name ).ToList();
    var distinctData = listdd.GroupBy(p => new { p.Name }).Select(g => g.First()).ToList(); 
}

private void mjButton31_Click(object sender, EventArgs e)
{
    var listdd = new List<Tests>();
    listdd.Add(new Tests { Name = "a", Code = "1" });
    listdd.Add(new Tests { Name = "a", Code = "1" });
    listdd.Add(new Tests { Name = "b", Code = "2" });
    listdd.Add(new Tests { Name = "b", Code = "1" });
    listdd.Add(new Tests { Name = "c", Code = "3" });
    var strlistdd = new List<string>();
    strlistdd.Add("a");
    strlistdd.Add("b");
    listdd.RemoveAll(x => strlistdd.Contains(x.Name));

}

        private void button2_Click(object sender, EventArgs e)
        {
            string strsql = "select top 100 WaterMeterAddress,RechargeCount,CreateUserName,CreateTime from [dbo].[MeiShan_Install_WaterUserMeter]";
            var data = GetDataTable(strsql);
            string path = @"D:\" + "欠费" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".xlsx";
            ExcelHelp.TableToExcelForXLSX(data, path);
          
         
        }
        public DataTable GetDataTable(string strsql)
        {

            //Data Source=47.106.197.173;User ID=meishan;Password=SQL2016!@#;Initial Catalog=SaiLing.MeiShan.Marketing.Core;MultipleActiveResultSets=true;Connection Timeout=120000;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=PC-201901071144\\SQL2008;User ID=sa;Password=123456;Initial Catalog=dwmskcs;Connection Timeout=120000;";
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            com.CommandText = strsql;
            DataTable dt = new DataTable();
            try
            {
                SqlDataReader dr = com.ExecuteReader();//执行SQL语句
                dt.Load(dr);
                dr.Close();//关闭执行
                con.Close();//关闭数据库



            }
            catch (Exception ex)
            {

                //Write("执行sql出错！原因：" + ex.Message);

            }
            return dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
       
            string strsql = "SELECT * FROM dbo.t_sys_error_info";
            var data = GetDataTable(strsql);
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
            var ddd = Guid.Empty;
            var stateList=new List<string>();
            stateList.Add("2019-04-08~2019-04-08");
            stateList.Add("2019-04-08~2019-04-07");
            stateList.Add("2019-04-07~2019-04-07");
            stateList.Add("2019-04-07~2019-04-07");
            stateList.Add("2019-04-08~2019-04-08");
            stateList.Add("2019-04-05~2019-04-08");
            var stateListGroup = stateList.GroupBy(c => c).Select(d => d.First()).ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var data = GetCuringTime("2019-04");
        }

        public BaseTime GetCuringTime(string timeData)
        {
            var result = new BaseTime();
            var time = DateTime.Now;
            var timeNew = DateTime.Now;
            if (timeData.Length == 4)
            {
                timeNew = time.AddYears((Convert.ToInt16(timeData) - time.Year));
                result.StartTime = new DateTime(timeNew.Year, 1, 1);
                result.EndTime = result.StartTime.Value.AddYears(1).AddDays(-1);
            }
            if (timeData.Length > 4)
            {
                timeNew = Convert.ToDateTime(timeData + "-01 00:00:00");
                result.StartTime = new DateTime(timeNew.Year, timeNew.Month, 1);
                result.EndTime = result.StartTime.Value.AddMonths(1).AddDays(-1);
            }
            return result;
        }
        public delegate int addNumDelegate(int a,int b);
        private void button6_Click(object sender, EventArgs e)
        {
            addNumDelegate sd = addNum;
           var  ddc  = sd.Invoke(2, 1);
        }
      
        public   int addNum(int a, int b)
        {
            return a + b;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a, b,c;
            a = b = c = 0;

            Action<int,int> Method = (int d, int f) =>
            {
                c = d + f;
            };
            Method(8, 9);
            //var data=new Func((int a, int b, int c) => { c = a + b; });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double a = 1;
            double b = 2;
         var Result= Calculate(a, b, Add);
         var data = Calculate(a, b, Subtract);
        }
        public delegate double CalculateDelegate(double a, double b);
        //public static double Calculate(double a, double b, Operator o)
        //{
        //    switch (o)
        //    {
        //        case Operator.Add:
        //            return Add(a, b);
        //        case Operator.Subtract:
        //            return Subtract(a, b);
        //        case Operator.Multiply:
        //            return Multiply(a, b);
        //        case Operator.Divide:
        //            return Divide(a, b);
        //        default:
        //            return 0;
        //    }
        //}
        /// <summary>
        /// 委托替代Calculate 取消switch判断
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="cd"></param>
        /// <returns></returns>
        public double Calculate(double a, double b, CalculateDelegate cd)
        {
            double result = 0;
             result= cd.Invoke(a, b);
       
            return result;
        }
        public  double Add(double a, double b)
        {
            return a + b;
        }
        public  double Subtract(double a, double b)
        {
            return a - b;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            long? result ;
            string dd= "5412.54";
            if (IsNumber(dd))
                result = Convert.ToInt64(Math.Round(Convert.ToDecimal(dd), MidpointRounding.AwayFromZero)) ;
                result = 0;
        }
        public static bool IsNumber(string value)
             {
                if (string.IsNullOrWhiteSpace(value)) return false;
                return   Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$"); ;
            }

        private void button10_Click(object sender, EventArgs e)
        {
            Test(27);
            var ddd=new Tests();
            ddd.Code = "123";
            ddd.Name=new tets().Add();
        }

        public void Test(int id)
        {
            if (id <= 15 || id == 27 || id == 28)
            {
            }
            else
            {
                
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
        //  4.1.委托类似于 C++ 函数指针。

        //4.2.委托允许将方法作为参数进行传递。

        //4.3.委托可用于定义回调方法。

        //4.4.委托可以链接在一起；多播。

        //4.5.方法不必与委托签名完全匹配。
    }
}
