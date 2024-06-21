using System.Reflection;
using UpdateObjectByProperties;

var oldObj = new ObjectTest(){ID = 10, MyProperty = "MyProperty 01", objectSon = new() {OtherPropertySon = "Other Property 01", MyPropertySon = "My Property Son 01" }};
var newObj = new ObjectTest(){ID = 10, MyProperty = "MyProperty 02", objectSon = new() {OtherPropertySon = "Other Property 02", MyPropertySon = "" }};

System.Console.WriteLine(oldObj.MyProperty);
System.Console.WriteLine(oldObj.objectSon.MyPropertySon);
System.Console.WriteLine(oldObj.objectSon.OtherPropertySon);

UpdateObject(oldObj, newObj);

System.Console.WriteLine("-------------------------------------");

System.Console.WriteLine(oldObj.MyProperty);
System.Console.WriteLine(oldObj.objectSon.MyPropertySon);
System.Console.WriteLine(oldObj.objectSon.OtherPropertySon);

void UpdateObject<T>(T oldObject, T newObject)
{
    PropertyInfo[] properties = typeof(T).GetProperties();

    foreach (PropertyInfo property in properties)
    {
        var oldValue = property.GetValue(oldObject);
        var newValue = property.GetValue(newObject);

        var teste = property.PropertyType;

        if (property.PropertyType == typeof(string))
        {
            if (!string.IsNullOrEmpty((string)newValue))
            {
                property.SetValue(oldObject, newValue);
            }
        }
        else if (property.PropertyType.IsClass && !property.PropertyType.IsPrimitive && property.PropertyType != typeof(string))
        {
            if (oldValue != null && newValue != null)
            {
                if (property.PropertyType == typeof(ObjectSon))
                    UpdateObject((ObjectSon)oldValue, (ObjectSon)newValue);
            }
            else if (oldValue == null && newValue != null)
            {
                property.SetValue(oldObject, newValue);
            }
        }
        else if (!Equals(oldValue, newValue))
        {
            property.SetValue(oldObject, newValue);
        }
    }
}
