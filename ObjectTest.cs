namespace UpdateObjectByProperties
{
    public class ObjectTest
    {
        public int ID { get; set; }
        public string MyProperty { get; set; }
        public ObjectSon objectSon { get; set;}
    }

    public class ObjectSon
    {
        public string MyPropertySon { get; set; }
        public string OtherPropertySon { get; set; }
    }
}