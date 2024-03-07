// 引入必要的命名空间  

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1
{
    // 定义一个名为 MyDataModel 的类，该类实现了 INotifyPropertyChanged 接口  
    public class MyDataModel : INotifyPropertyChanged
    {
        // 定义私有字段 _comboBoxSelectedItem，用于存储 ComboBox 选中的项  
        private string _comboBoxSelectedItem;

        // 定义私有字段 _textBoxText，用于存储 TextBox 的文本  
        private string _textBoxText;

        // 定义一个 ObservableCollection<string> 类型的公有属性 AvailableItems  
        // 该属性存储了下拉列表可选项的集合  
        public ObservableCollection<string> AvailableItems { get; set; }

        // 定义类的构造函数  
        public MyDataModel()
        {
            // 初始化 AvailableItems 集合  
            // 并添加几个示例项  
            AvailableItems = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3"
                // 这里可以添加更多的项  
            };

            // 在初始化后再向 AvailableItems 集合添加一个项  
            // 这一步可以合并到上面的集合初始化器中  
            AvailableItems.Add("Item 4");
        }

        // 定义公有属性 ComboBoxSelectedItem，包含 get 和 set 访问器  
        public string ComboBoxSelectedItem
        {
            // 获取属性值  
            get { return _comboBoxSelectedItem; }

            // 设置属性值，并触发 OnPropertyChanged 事件  
            set
            {
                // 检查新值是否和当前值不同  
                if (value != _comboBoxSelectedItem)
                {
                    // 如果不同，更新私有字段的值  
                    _comboBoxSelectedItem = value;

                    // 触发 PropertyChanged 事件，指明哪个属性发生了改变  
                    OnPropertyChanged(nameof(ComboBoxSelectedItem));

                    // 这里假设我们想要在 ComboBox 选中项变化时  
                    // 更新 TextBoxText 的值  
                    TextBoxText = value;
                }
            }
        }

        // 定义公有属性 TextBoxText，包含 get 和 set 访问器  
        public string TextBoxText
        {
            // 获取属性值  
            get { return _textBoxText; }

            // 设置属性值，并触发 OnPropertyChanged 事件  
            set
            {
                // 检查新值是否和当前值不同  
                if (value != _textBoxText)
                {
                    // 如果不同，更新私有字段的值  
                    _textBoxText = value;

                    // 触发 PropertyChanged 事件，指明哪个属性发生了改变  
                    OnPropertyChanged(nameof(TextBoxText));
                }
            }
        }

        // 定义 PropertyChanged 事件，它符合 INotifyPropertyChanged 接口的要求  
        public event PropertyChangedEventHandler PropertyChanged;

        // 定义一个受保护的虚方法 OnPropertyChanged  
        // 该方法用于触发 PropertyChanged 事件  
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // 如果 PropertyChanged 事件有订阅者，则调用事件处理程序  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    // 请注意，当ComboBoxSelectedItem发生变化时，这个示例代码中自动更新了TextBoxText的值。这不是所有情况都需要的行为，
    // 具体是否需要更新应根据实际应用逻辑来确定。如果TextBoxText的更新不应当依赖于ComboBoxSelectedItem的变化，
    // 则应该从ComboBoxSelectedItem的setter中移除TextBoxText = value;这一行。
    // 另外，在实际开发中，如果AvailableItems需要在类外部进行修改（如添加或删除元素），通常会通过一个方法或者一个额外的属性来实现，
    // 以确保线程安全和数据完整性。但在这个例子中，AvailableItems直接被初始化为一个具有四个字符串元素的ObservableCollection<string>，
    // 并且没有提供任何额外的方法来修改这个集合。如果需要，可以通过添加一个方法或者公开一个修改该集合的接口来扩展这个类。
}