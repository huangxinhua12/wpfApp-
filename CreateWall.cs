using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [Transaction(TransactionMode.Manual)]
    class CreateWall : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                Document doc = commandData.Application.ActiveUIDocument.Document;
                MainWindow mainWindows = new MainWindow();
                mainWindows.ShowDialog();
                var selectedItem = mainWindows.myComboBox.SelectedItem;
                double height = 0;
                if (selectedItem is double selectedString)
                {
                    TaskDialog.Show("选中:", selectedString.ToString());
                    mainWindows.textBox.Text = selectedString.ToString();
                    //height = selectedString/0.3048;
                    height = Convert.ToDouble(mainWindows.textBox.Text) / 0.3048; // 假设这是以英尺为单位的高度，转换为Revit的内部单位（假设为英尺）  
                    // 使用 selectedString  
                }

                // 获取墙类型和标高  
                WallType wallType = GetElementOfType<WallType>(doc, "CW 102-50-100p");
                Level level = GetElementOfType<Level>(doc, "标高 1");
                Wall wall = GetElementOfType<Wall>(doc, "CW 102-50-100p");

                if (wallType == null || level == null)
                {
                    message = "指定的墙类型或标高不存在。";
                    return Result.Failed;
                }

                // 修改坐标以使其在Revit视图中可见  
                XYZ start = new XYZ(0, 0, 0); // 修改为合适的起点  
                XYZ end = new XYZ(304.8, 0, 0); // 修改为合适的终点，这里假设10单位应该是英尺，所以转换为毫米  

                // 使用有界的线来创建墙  
                Line geomLine = Line.CreateBound(start, end);


                double offset = 0; // 偏移量，根据需要调整  

                using (Transaction transaction = new Transaction(doc, "创建墙01"))
                {
                    transaction.Start();
                    Wall.Create(doc, geomLine, wallType.Id, level.Id, height, offset, false, false);
                    transaction.Commit();
                }

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = $"发生异常: {ex.Message}";
                return Result.Failed;
            }
        }

        private T GetElementOfType<T>(Document doc, string name) where T : Element
        {
            return new FilteredElementCollector(doc)
                .OfClass(typeof(T))
                .FirstOrDefault(x => x.Name.Equals(name)) as T;
        }
    }
}