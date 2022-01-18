
//I need to hide some CategoryAttribute in the propertygrid, 
//and only show some of them. The objects that I have to display in the propertygrid 
//are objects that I have derived from existing objects, but of these I have to display 
//only some properties that are in the categories set by me.
//This is the way!!!


//my object
public class MyTextBox : TextBox 
{
    public MyProperties MyProperties { get; set; }
    public MyTextBox() 
    {
        MyProperties = new MyProperties();
    }

}


//properties of the object
public class MyProperties 
{
    [Browsable(true)]
    [ReadOnly(false)]
    [Category("MyCategory")]
    [DisplayName("MyName")]
    public double MyProp { get; set; } = 1;
}


//show in propertygrid only my object's properties
MyTextBox myTextBox = new MyTextBox();
this.propertyGridControl.SelectedObject = myTextBox.MyProperties;







