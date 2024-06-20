using System.Reflection;
using UpdateObjectByProperties;

var oldObj = new ObjectTest(){ID = 10, MyProperty = "Teste 01"};
var newObj = new ObjectTest(){ID = 10, MyProperty = "Teste 02"};

System.Console.WriteLine("Old value: " + oldObj.MyProperty);

UpdateObject(oldObj, newObj);

System.Console.WriteLine("New value: " + oldObj.MyProperty);

void UpdateObject<ObjectTest>(ObjectTest oldOs, ObjectTest os)
{
    PropertyInfo[] property = typeof(ObjectTest).GetProperties();

    foreach (PropertyInfo propriedade in property)
    {
        var oldValue = propriedade.GetValue(oldOs);
        var newValue = propriedade.GetValue(os);

        if (oldValue != null && !oldValue.Equals(newValue))
        {
            propriedade.SetValue(oldOs, newValue);
        }
        else if (oldValue == null && newValue != null)
        {
            propriedade.SetValue(oldOs, newValue);
        }
    }
}
