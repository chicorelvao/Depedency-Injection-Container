namespace container;
class ServiceAImpl : ServiceA 
{
    private ServiceB _serviceB;

    public ServiceB PropServiceB
    {
        get { return _serviceB; }
        set { _serviceB = value; }
    }

    public string jobA()
    {
        return "jobA(" + _serviceB.jobB() + ")";
    }
}

