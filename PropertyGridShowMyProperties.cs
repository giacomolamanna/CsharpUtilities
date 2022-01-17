public class MyTextBox : TextBox {
    public MyProperties MyProperties { get; set; }
    public MyTextBox() {
        MyProperties = new MyProperties();
    }

}
public class MyProperties {
    [Browsable(true)]
    [ReadOnly(false)]
    [Category("MyCategory")]
    [DisplayName("MyName")]
    public double MyProp { get; set; } = 1;
}

MyTextBox myTextBox = new MyTextBox();
this.propertyGridControl.SelectedObject = myTextBox.MyProperties;
