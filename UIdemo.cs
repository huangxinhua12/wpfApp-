using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    //注意别继承方法 IExternalApplication
    [Transaction(TransactionMode.Manual)]
    class UIdemo : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            throw new NotImplementedException();
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //1.第一步创建一个RibbonTab
            application.CreateRibbonTab("UTTab");
            //RibbonTab中创建UIPanel
            RibbonPanel rp = application.CreateRibbonPanel("UTTab", "UIPanel");
            //指定程序集的名称以及使用的类名
            //string assemblyPath = @"C:\Users\lx\source\repos\ClassLibrary5\bin\Debug\ClassLibrary5.dll";
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string classNameHelloRevitDemo = "WpfApp1.CreateWall";
            //创建PushButton
            PushButtonData pbd = new PushButtonData("NameCreateWall", "TextCreateWall", assemblyPath,
                classNameHelloRevitDemo);
            //将pushButton添加到面板中
            PushButton pushButton = rp.AddItem(pbd) as PushButton;
            //设置按钮图片
            string imgPath = @"D:\Down\应用市场.png";
            //string imgPath = @"pack://application:,,,/ClassLibrary5;component/pic/数字中台.png";
            if (pushButton != null)
            {
                pushButton.LargeImage = new BitmapImage(new Uri(imgPath, UriKind.Absolute));
                pushButton.ToolTip = "TextCreateWall";
            }
            return Result.Succeeded;
        }
    }
}