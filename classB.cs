namespace container;


class ServiceBImpl : ServiceB
{
    private ServiceA _serviceA;
    
    public ServiceA PropServiceA
    {
        get { return _serviceA; }
        set { _serviceA = value; }
    }
    public string jobB()
    {
        return "jobB()";
    }
}
