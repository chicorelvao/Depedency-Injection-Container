namespace container;


public class MainProgram
{
    public static void Main(String[] args)
    {
        DIContainer.addService<ServiceAImpl>();
        DIContainer.addService<ServiceBImpl>();

        DIContainer containerInstance = new DIContainer();
        
        DomainLogic(containerInstance);

    }
    
    private static void DomainLogic(DIContainer container)
    {
        ServiceA serviceA = container.getServiceInstance<ServiceA>();
        ServiceB serviceB = container.getServiceInstance<ServiceB>();

        Console.WriteLine(serviceA.jobA());
        Console.WriteLine(serviceB.jobB());
    }


} 